using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        Debug.Log("Computer Interact");
    }
}
