using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickSystem : MonoBehaviour
{
    [Header("Settings"), Space()]
    [SerializeField] int maxExperience = 1000;
    [Space(), Header("Status")]
    [SerializeField] int curLevel = 0;
    [SerializeField] int experience = 0;

    public event Action OnlevelUp;

    public int MaxExperience
    {
        get 
        {
            return maxExperience;
        }
    }

    private void Start()
    {
        OnlevelUp += () => print("Leveled to " + curLevel);
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
    }

    private void LevelUp()
    {
        curLevel++;
        OnlevelUp.Invoke();
    }

    private void IncreaseExperience(int exp)
    {
        var newExp = exp + experience;

        if (newExp > MaxExperience)
        {
            LevelUp();
            experience = newExp - MaxExperience;
        }
        else
        {
            experience = newExp;
        }
    }
}
