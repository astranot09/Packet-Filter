using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHour : MonoBehaviour
{
    [SerializeField] private ShopSO shopData;
    public int OpenHour => shopData.shopOpenHour;
    public int CloseHour => shopData.shopCloseHour;

    [SerializeField] protected bool isOpen;

    public virtual void ShopOpen()
    {
        isOpen = true;
    }
    public virtual void ShopClose()
    {
        isOpen = false;
    }
}
