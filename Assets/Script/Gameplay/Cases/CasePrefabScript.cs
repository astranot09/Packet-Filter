using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CasePrefabScript : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private List<CaseList> caseData;

    [Header("UI")]
    [SerializeField] private Image profileImage;

    public void SetUp(CaseCategory category)
    {
        caseData = CaseDatabase.instance.GetCaseData(category);
    }
}
