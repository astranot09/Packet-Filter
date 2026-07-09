using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceStore : ShopHour, IInteractable
{
    public override void ShopOpen()
    {
        base.ShopOpen();
    }

    public void OnInteract()
    {
        if (isOpen)
        {
            Debug.Log("Device Store Buka");
        }
    }

    public override void ShopClose()
    {
        base.ShopClose();
    }
}
