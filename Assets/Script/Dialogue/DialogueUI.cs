using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{

    public static DialogueUI instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }




    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private DialogueSO dialogueSO;

    [Header("UI References")]
    [SerializeField] private Image speaker1Image;
    [SerializeField] private Image speaker2Image;
    [SerializeField] private TMP_Text speakerNameText;
    [SerializeField] private TMP_Text speakerDialogueText;

    [Header("Effect Reference")]
    [SerializeField] private TypeWriterEffect typeWriterEffect;

    private Coroutine dialogueCoroutine;


    private void Start()
    {
        DialogueSetUp(dialogueSO);
    }

    public void DialogueSetUp(DialogueSO newDialogueSO)
    {
        dialogueSO = newDialogueSO;
        dialoguePanel.SetActive(true);

        // Safely stop any running dialogue before starting a new one
        if (dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
        }

        // FIX: Start the coroutine instead of calling the setup method again
        dialogueCoroutine = StartCoroutine(StepThroughDialogue(dialogueSO));
    }

    private IEnumerator StepThroughDialogue(DialogueSO dialogueSO)
    {
        // FIX: Loop through the actual list of data, node by node
        foreach (DialogueData dialogueData in dialogueSO.dialogueDatas)
        {
            // 1. Set the speaker's name and sprites
            speakerNameText.text = dialogueData.name;
            speaker1Image.sprite = dialogueData.speaker1Sprite;
            speaker2Image.sprite = dialogueData.speaker2Sprite;

            // 2. Visually highlight who is speaking by adjusting image color alpha or tint
            UpdateSpeakerVisuals(dialogueData);

            // 3. FIX: Run the typewriter effect and WAIT for it to finish completely
            yield return typeWriterEffect.Run(dialogueData.dialogueText, speakerDialogueText);

            // 4. NEW: Wait for the player to press a key (e.g., Space or Left Click) before moving to the next line
            yield return WaitForPlayerInput();
        }

        // Dialogue complete! Close the panel
        CloseDialogueBox();
    }

    private void UpdateSpeakerVisuals(DialogueData data)
    {
        // Simple visual feedback: dim the speaker who isn't talking
        // (Assumes you are using the Enum approach, or checking your booleans)
        if (data.speaker1Sprite)
        {
            speaker1Image.color = Color.white;
            speaker2Image.color = new Color(0.5f, 0.5f, 0.5f, 1f); // Dimmed
        }
        else if (data.speaker2Sprite)
        {
            speaker1Image.color = new Color(0.5f, 0.5f, 0.5f, 1f); // Dimmed
            speaker2Image.color = Color.white;
        }
    }

    private IEnumerator WaitForPlayerInput()
    {
        // Holds the code execution right here until Space or Left Mouse Button is pressed
        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
    }

    public void CloseDialogueBox()
    {
        dialoguePanel.SetActive(false);
        dialogueCoroutine = null;
    }
}