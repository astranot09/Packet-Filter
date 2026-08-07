using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandbookManager : MonoBehaviour
{
    public static HandbookManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("CaseAnalyzerButton")]
    [SerializeField] private GameObject caseAnalyzeButtonPrefab;
    [SerializeField] private Transform caseAnalyzeButtonTransform;


    [Header("CategoryButton")]
    [SerializeField] private GameObject phisingButton;
    [SerializeField] private GameObject smishingButton;
    [SerializeField] private GameObject vishingButton;
    bool allCategoryUnlocked = false;


    [Header("UI--Answer")]
    [SerializeField] private GameObject handbookAnswer;
    [SerializeField] private Transform handbookAnswerTransform;

    public void SetUpCategory()
    {
        if(allCategoryUnlocked) return;

        phisingButton.SetActive(true);
        smishingButton.SetActive(true);
        if (CaseManager.instance.VoiceAnalyzerUnlocked)
        {
            phisingButton.SetActive(true);
            allCategoryUnlocked = true;
        }
    }

    // di pasang ke button yang ada handbook buttonnya
    public void SetUpHandBookCategory(CaseCategory category)
    {
        switch (category)
        {
            case CaseCategory.Phishing:
                SpawnAllCaseAnalyzerType(CaseDatabase.instance.phishingData, CaseManager.instance.PhishingLevel);
                break;
            case CaseCategory.Smishing:
                SpawnAllCaseAnalyzerType(CaseDatabase.instance.smishingData, CaseManager.instance.SmishingLevel);
                break;
            case CaseCategory.Vishing:
                SpawnAllCaseAnalyzerType(CaseDatabase.instance.vishingData, CaseManager.instance.VishingLevel);
                break;
        }
    }

    public void SpawnAllCaseAnalyzerType(CategoryDatas caseLists, int level)
    {
        foreach(IndicatorCategory caseList in caseLists.categoryData)
        {
            if(level < caseList.levelUnlocked) return;

            GameObject x = Instantiate(caseAnalyzeButtonPrefab, caseAnalyzeButtonTransform);
            x.GetComponent<HandBookButtonScript>().SetUpCaseAnalyzer(caseList.caseAnalyzer, caseList.categorySO);
        }
    }

    public void SpawnAllCaseAnswer(List<CaseSO> cases)
    {
        foreach (CaseSO x in cases)
        {
            foreach (string falseString in x.falseString)
            {
                GameObject y = Instantiate(handbookAnswer, handbookAnswerTransform);
                //trs setup kayak kasih false string sama x.correct
            }
        }
    }


}
