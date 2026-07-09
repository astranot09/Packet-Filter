using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private int playerLevel;
    public int PlayerLevel => playerLevel;

    [Header("Experience")]
    [SerializeField] private float currentExperience;
    [SerializeField] private float maxExperience;


    public void AddExperience(float exp)
    {
        currentExperience += exp;
        if(currentExperience >= maxExperience)
        {
            currentExperience -= maxExperience;
            //LevelUp
        }
    }
}
