using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CaseCategory
{
    Phising,
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
    public List<CaseSO> categoryData;
}


[System.Serializable]
public class CategoryDatas
{
    public CaseCategory caseCategory;
    public List<IndicatorCategory> categoryData; //ganti SO
}


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

    public List<CategoryDatas> caseDatas;
}
