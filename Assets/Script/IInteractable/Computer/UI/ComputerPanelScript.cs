using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPanelScript : MonoBehaviour
{
    public void ExitComputer()
    {
        PlayerInputController.instance.TurnOnPlayerInput();
        this.gameObject.SetActive(false);
    }
}
