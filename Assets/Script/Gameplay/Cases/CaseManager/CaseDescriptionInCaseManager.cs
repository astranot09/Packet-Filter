using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CaseDescriptionInCaseManager : MonoBehaviour
{

    public static CaseDescriptionInCaseManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    [Header("Data")]
    [SerializeField] private List<CaseList> currCase;
    [SerializeField] private CaseCategory currCaseCategory;

    [Header("UI")]
    [SerializeField] private TMP_Text numberCase;
    [SerializeField] private TMP_Text categoryText;
    [SerializeField] private TMP_Text clientNameText;
    [SerializeField] private TMP_Text titleNameText;
    [SerializeField] private TMP_Text statusText;
  
    public void SetUpDrescription(List<CaseList> caseData, CaseCategory category)
    {
        currCaseCategory = category;
        currCase = caseData;
        categoryText.text = category.ToString();
        statusText.text = "Avaiable";
    }

    public void AcceptTaskButton()
    {
        CaseManager.instance.SwitchCaseCategory(currCaseCategory);
    }

}
