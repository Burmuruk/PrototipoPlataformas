using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickSystem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int materialsLayer = 21;
    [SerializeField] Vector2 detectionSize = Vector2.one;
    [Space(), Header("Status")]
    [SerializeField] int curLevel = 0;
    [SerializeField] int experience = 0;
    [SerializeField] int maxExperience = 1000;

    public event Action OnlevelUp;

    public int MaxExperience
    {
        get 
        {
            return maxExperience;
        }
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
