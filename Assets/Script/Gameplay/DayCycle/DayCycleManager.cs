using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    public static DayCycleManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Day")]
    [SerializeField] private int dayCount = 1;
    public int DayCount => dayCount;

    [Header("Time")]
    [SerializeField] private int hour;
    public int Hour => hour;
    [SerializeField] private int minute;
    public int Minute => minute;

    [Header("Converter")]
    [SerializeField] private bool onGameplay;
    [SerializeField] private float secondMaxCountdown = 10f;
    [SerializeField] private float currCountdown;
    [SerializeField] private int minuteGet = 5;

    [Header("NPC")]
    [SerializeField] private List<ShopHour> listShop = new List<ShopHour>();


    [Header("Setting New Day")]
    private bool dayEnd;
    [SerializeField] private int minuteStart;
    [SerializeField] private int hourStart;

    //[Header("Reference")]
    //[SerializeField] private DayCycleUI dayCycleUI;


    //Event
    public event Action onTimeChanged;


    private void Start()
    {
        CheckShopStatus();
    }
    private void Update()
    {
        if (onGameplay && !dayEnd)
        {
            currCountdown += Time.deltaTime;

            if (currCountdown >= secondMaxCountdown)
            {
                currCountdown -= secondMaxCountdown;

                AddMinute(minuteGet);
            }
        }
    }

    public void AddMinute(int value)
    {
        minute += value;
        if(minute >= 60)
        {
            minute -= 60;
            AddHour(1);
        }

        onTimeChanged?.Invoke();
        CheckShopStatus();
    }

    public void AddHour(int value)
    {
        hour += value;
        if (hour >= 24)
        {
            hour = 24;
            dayEnd = true;
        }

        onTimeChanged?.Invoke();
        CheckShopStatus();
    }

    public void NextDay()
    {
        dayCount++;
        dayEnd = false;
        minute = minuteStart;
        hour = hourStart;

        onTimeChanged?.Invoke();

    }


    // ========= CHECK ABOUT NPC ==============

    public void CheckShopStatus()
    {
        foreach(ShopHour shop in listShop)
        {
            Debug.Log("Check");
            if(Hour >= shop.OpenHour && hour < shop.CloseHour)
            {
                shop.ShopOpen();
                Debug.Log("True");
            }
            else
            {
                shop.ShopClose();
                Debug.Log("False");
            }
        }
    }

}
