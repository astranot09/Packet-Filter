using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CaseCategory
{
    Phishing,
    Smishing,
    Vishing
}

[System.Serializable]
public enum CaseAnalyzer
{
    //Phising
    FakeDomain,
    FakeLink,
    RequestOTP,
    FakeIdentity,

    //Smishing
    UnknownNumber,
    ShortLink,

    //Vishing
    SenseOfUrgency,
    SocialPressure
}


[System.Serializable]
public class IndicatorCategory
{
    public CaseAnalyzer caseAnalyzer;
    public int levelUnlocked;
    public List<CaseSO> categorySO;
}


[System.Serializable]
public class CategoryDatas
{
    public List<IndicatorCategory> categoryData;
}

[System.Serializable]
public class CaseList
{
    public string caseCorrectText;
    public string caseFalseText;
    public CaseAnalyzer caseAnalyzer;
    public bool isCorrect;

    public void InsertList(string correctText, string falseText, CaseAnalyzer analyzer, bool isCorrect)
    {
        caseCorrectText = correctText;
        caseFalseText = falseText;
        caseAnalyzer = analyzer;
        this.isCorrect = isCorrect;
    }

}

public class CaseDatabase : MonoBehaviour
{
    public static CaseDatabase instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public CategoryDatas phishingData;

    public CategoryDatas smishingData;

    public CategoryDatas vishingData;



    public List<CaseList> GetCaseData(CaseCategory category)
    {
        switch (category)
        {
            case CaseCategory.Phishing:
                return ReadAllData(phishingData, CaseManager.instance.PhishingLevel);
            case CaseCategory.Smishing:
                return ReadAllData(smishingData, CaseManager.instance.SmishingLevel);
            case CaseCategory.Vishing:
                return ReadAllData(vishingData, CaseManager.instance.VishingLevel);
            default:
                return new List<CaseList>();
        }
    }

    public List<CaseList> ReadAllData(CategoryDatas datas, int level)
    {
        List<CaseList> resultList = new List<CaseList>();
        if (datas == null || datas.categoryData == null)
            return resultList;

        foreach (IndicatorCategory c in datas.categoryData)
        {
            if (c.levelUnlocked <= level)
            {
                bool isTrue = RandomBool();
                CaseSO caseSO = RandomizeCase(c.categorySO);

                if (caseSO == null) continue; // Skip if no ScriptableObject was found

                string correctText = null;
                string falseText = null;
                if (isTrue)
                {
                    correctText = RandomizeString(caseSO, isTrue);
                }
                else
                {
                    correctText = RandomizeString(caseSO, true);
                    falseText = RandomizeString(caseSO, false);
                }

                // FIX 2: Create a new instance and add it to the list
                CaseList newEntry = new CaseList();
                newEntry.InsertList(correctText, falseText, c.caseAnalyzer, isTrue);

                resultList.Add(newEntry);
            }
        }

        return resultList;
    }

    public bool RandomBool()
    {
        return Random.value > 0.5f;
    }

    public CaseSO RandomizeCase(List<CaseSO> categorySOs)
    {
        if (categorySOs == null || categorySOs.Count == 0)
        {
            Debug.LogWarning("CaseSO list is empty or null!");
            return null;
        }

        // FIX 3: Random.Range(int, int) is exclusive for max, so no '-1' needed
        int randomIndex = Random.Range(0, categorySOs.Count);
        return categorySOs[randomIndex];
    }

    public string RandomizeString(CaseSO caseSO, bool isCorrect)
    {
        if (caseSO == null) return string.Empty;

        if (isCorrect)
        {
            return caseSO.correctString;
        }
        else
        {
            if (caseSO.falseString == null || caseSO.falseString.Count == 0)
            {
                Debug.LogWarning($"False string list is empty on {caseSO.name}, falling back to correct string.");
                return caseSO.correctString;
            }

            // FIX 4: No '-1' needed when indexing into falseString
            int randomIndex = Random.Range(0, caseSO.falseString.Count);
            return caseSO.falseString[randomIndex];
        }
    }

}
