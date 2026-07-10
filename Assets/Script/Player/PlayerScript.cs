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

    [Header("Hunger")]
    [SerializeField] private int currentHunger;
    public int Hunger => currentHunger;
    [SerializeField] private int maxHunger;

    public void AddExperience(float exp)
    {
        currentExperience += exp;
        if(currentExperience >= maxExperience)
        {
            currentExperience -= maxExperience;
            PlayerLevelUp();
        }
    }

    public void PlayerLevelUp()
    {
        playerLevel++;
    }

    //========================== HUNGER ============================
    public void AddHunger(int value)
    {
        currentHunger += value;
        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
    }
    public void RemoveHunger(int value)
    {
        currentHunger -= value;
        if (currentHunger < maxHunger)
        {
            currentHunger = 0;
        }
    }
}
