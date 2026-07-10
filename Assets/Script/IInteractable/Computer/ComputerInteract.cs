using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject computerPanel; 
    
    public void OnInteract()
    {
        if (computerPanel != null)
        {
            computerPanel.SetActive(true);
            PlayerInputController.instance.TurnOffPlayerInput();
        }
        Debug.Log("Computer Interact");
    }
}
