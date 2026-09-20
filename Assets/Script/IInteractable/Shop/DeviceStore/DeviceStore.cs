using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
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
        else
        {
            if(dialogueShopClose != null)
                DialogueUI.instance.DialogueSetUp(dialogueShopClose);
        }
    }

    public override void ShopClose()
    {
        base.ShopClose();
    }
}
