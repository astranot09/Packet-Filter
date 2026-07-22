using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShop : ShopHour, IInteractable
{
    public override void ShopOpen()
    {
        base.ShopOpen();
    }

    public void OnInteract()
    {
        if (isOpen)
        {
            Debug.Log("Food Shop Buka");
            FoodShopManager.instance.OpenShop();
            PlayerInputController.instance.TurnOffPlayerInput();
        }
    }

    public override void ShopClose()
    {
        base.ShopClose();
    }

}
