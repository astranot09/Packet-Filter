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
        if (!string.IsNullOrWhiteSpace(inputText))
        {
            // Jika valid, potong spasi di awal/akhir nama agar lebih rapi (opsional)
            string cleanName = inputText.Trim();

            GameManager.instance.SubmitPlayerName(cleanName);
            SceneController.instance.GameScene();
        }
        else
        {
            Debug.LogWarning("Nama tidak boleh kosong atau hanya berisi spasi!");
            return;
        }

    }

}
