using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldGrabber : MonoBehaviour
{
    [SerializeField] private string inputText;

    public void GrabFromInputField (string input)
    {
        inputText = input;
    }

    public void SubmitName()
    {

    }

}
