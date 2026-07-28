using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CasePrefabScript : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private List<CaseList> caseData;
    [SerializeField] private int index;
    [SerializeField] private string npcName;

    [Header("UI")]
    [SerializeField] private Image profileImage;
    [SerializeField] private TMP_Text indexText;
    [SerializeField] private TMP_Text nameText;

    public void SetUp(CaseCategory category)
    {
        caseData = CaseDatabase.instance.GetCaseData(category);
        index = transform.GetSiblingIndex();
        npcName = "John";

        indexText.text = index.ToString();
        nameText.text = npcName.ToString();

        if (indexText != null)
        {
            indexText.text = (index + 1).ToString();
        }
    }
}
