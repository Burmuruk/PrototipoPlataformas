using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PickSystem : MonoBehaviour
{
    [Header("Settings"), Space()]
    [SerializeField] int maxExperience = 1000;
    [Space(), Header("Status")]
    [SerializeField] float curLevel = 0;
    [SerializeField] float experience = 0;
    [SerializeField]
    TextMeshProUGUI txtScore;
    [SerializeField]
    TextMeshProUGUI txtExp;
    [SerializeField]
    Image expBar;

    public event Action OnlevelUp;

    public int MaxExperience
    {
        get 
        {
            return maxExperience;
        }
    }

    public float Level { get => curLevel; }
    public float Experience { get => experience; }

    private void Start()
    {
        OnlevelUp += () => print("Leveled to " + curLevel);
        txtScore.text = txtScore.text + "0";
        //txtExp.text = "Exp: " + experience.ToString();
        expBar.fillAmount = 0;
    }

    private void Update()
    {
        DetectMaterials();
    }

    private void DetectMaterials()
    {
        //var hit = Physics2D.BoxCast(transform.position, Vector2.right, 0, Vector2.zero, .1f);

        //if (hit)
        //{
        //    PickUPMaterial material = null;

        //    if (hit.collider.TryGetComponent(out material))
        //    {
        //        IncreaseExperience(material.Value);

        //        Destroy(hit.collider.gameObject);
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PickUPMaterial material = null;

        if (collision.gameObject.TryGetComponent(out material))
        {
            IncreaseExperience(material.Value);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Hazard"))
        {
            Damage();
            Destroy(collision.gameObject);
        }
    }

    private void LevelUp()
    {
        curLevel++;
        UpdateScore();
        OnlevelUp.Invoke();
    }

    private void Damage()
    {
        if (curLevel > 0)
        {
            print("Upgrade lost! Current level: " + --curLevel);
            UpdateScore();
        }
    }

    private void IncreaseExperience(int exp)
    {
        var newExp = exp + experience;

        if (newExp >= MaxExperience)
        {
            LevelUp();
            experience = newExp - MaxExperience;
        }
        else
        {
            experience = newExp;
        }

        expBar.fillAmount = experience / maxExperience;
        //txtExp.text = "Exp: " + experience.ToString();
    }

    private void UpdateScore()
    {
        var txt = txtScore.text.Substring(0, 7);
        txtScore.text = txt + curLevel;
    }
}
