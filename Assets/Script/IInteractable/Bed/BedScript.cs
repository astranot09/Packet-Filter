using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        DayCycleManager.instance.NextDay();
    }
}
