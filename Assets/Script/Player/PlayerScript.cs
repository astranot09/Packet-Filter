using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public static PlayerScript instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }



    [Header("Level")]
    [SerializeField] private int playerLevel;
    public int PlayerLevel => playerLevel;

    [Header("Experience")]
    [SerializeField] private float currentExperience;
    public float CurrentExperience => currentExperience;
    [SerializeField] private float maxExperience;
    public float MaxExperience => maxExperience;

    [Header("Hunger")]
    [SerializeField] private int currentHunger;
    public int Hunger => currentHunger;
    [SerializeField] private int maxHunger;

    [Header("Currency")]
    [SerializeField] private int currentCurrency;
    public int Currency => currentCurrency;


    //Event
    public event Action onHungerChanged;
    public event Action onExperienceChanged;
    public event Action onCurrencyChanged;
    public void AddExperience(float exp)
    {
        currentExperience += exp;
        if(currentExperience >= maxExperience)
        {
            currentExperience -= maxExperience;
            PlayerLevelUp();
        }
        onExperienceChanged?.Invoke();
    }

    public void PlayerLevelUp()
    {
        playerLevel++;
        onExperienceChanged?.Invoke();
    }

    //========================== HUNGER ============================
    public void AddHunger(int value)
    {
        currentHunger += value;
        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
        onHungerChanged?.Invoke();
    }
    public void RemoveHunger(int value)
    {
        currentHunger -= value;
        if (currentHunger < 0)
        {
            currentHunger = 0;
        }
        onHungerChanged?.Invoke();
    }


    //========================== CURRENCY ============================
    public void AddCurrency(int value)
    {
        currentCurrency += value;

        onCurrencyChanged?.Invoke();
    }
    public void RemoveCurrency(int value)
    {
        if(currentCurrency - value < 0) return;

        currentCurrency -= value;

        onCurrencyChanged?.Invoke();
    }
}
