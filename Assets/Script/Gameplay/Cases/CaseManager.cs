using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CaseManager : MonoBehaviour
{
    public static CaseManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Category")]
    [SerializeField] private int mailAnalyzerLevel;
    public int PhishingLevel => mailAnalyzerLevel;
    [SerializeField] private int smsAnalyzerLevel;
    public int SmishingLevel => smsAnalyzerLevel;
    [SerializeField] private int voiceAnalyzerLevel;
    public int VishingLevel => voiceAnalyzerLevel;
    [SerializeField] private bool voiceAnalyzerUnlocked= false;
    public bool VoiceAnalyzerUnlocked => voiceAnalyzerUnlocked;

    [Header("Setting")]
    [SerializeField] private int maxCases = 10;
    [SerializeField] private GameObject casePrefab;
    [SerializeField] private Transform caseSpawner;

    [SerializeField] private List<CaseList> currCases;
    [SerializeField] private CaseCategory currentCaseCategory;

    [Header("Application Panel")]
    [SerializeField] private GameObject mailAnalyzerPanel;
    [SerializeField] private GameObject smsAnalyzerPanel;
    [SerializeField] private GameObject voiceAnalyzerPanel;

    private void Start()
    {
        DailyCaseSpawn();
    }

    public void SwitchCaseCategory(CaseCategory caseCategory)
    {
        currentCaseCategory = caseCategory;

        switch (currentCaseCategory)
        {
            case CaseCategory.Phishing:
                //mailAnalyzerPanel.SetActive(true);
                break;
            case CaseCategory.Smishing:
                //smsAnalyzerPanel.SetActive(true);
                break;
            case CaseCategory.Vishing:
                //voiceAnalyzerPanel.SetActive(true);
                break;
        }

    }

    public void DailyCaseSpawn()
    {
        int i = maxCases - currCases.Count;

        for (int j = 0; j < i; j++)
        {
            GameObject x = Instantiate(casePrefab, caseSpawner);
            x.GetComponent<CasePrefabScript>().SetUp(GetRandomCaseCategory());
        }
    }
    private CaseCategory GetRandomCaseCategory()
    {
        if(!VoiceAnalyzerUnlocked)
        {
            return UnityEngine.Random.value > 0.5f ? CaseCategory.Phishing : CaseCategory.Smishing;
        }

        Array values = Enum.GetValues(typeof(CaseCategory));
        return (CaseCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }
}
