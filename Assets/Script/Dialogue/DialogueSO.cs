using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueData
{
    public string name;
    [TextArea(3, 5)]
    public string dialogueText;

    public bool isSpeaker1;
    public Sprite speaker1Sprite;
    public Sprite speaker2Sprite;
}

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Scriptable Objects/Dialogue Data")]
public class DialogueSO : ScriptableObject
{
    public List<DialogueData> dialogueDatas = new List<DialogueData>();
}
