using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechWorkShop : ShopHour, IInteractable
{
    public override void ShopOpen()
    {
        base.ShopOpen();
    }

    public void OnInteract()
    {
        if (isOpen)
        {
            Debug.Log("Tech WorkShop Buka");
        }
    }

    public override void ShopClose()
    {
        base.ShopClose();
    }
}