using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBookButtonScript : MonoBehaviour
{
    [SerializeField] private CaseCategory caseCategory;
    [SerializeField] private CaseAnalyzer caseAnalyzer;
    [SerializeField] private List<CaseSO> caseSOs; //abis itu kalau di klik.. bakal spawn semua

    public void OpenCategory()
    {
        HandbookManager.instance.SetUpHandBookCategory(caseCategory);
    }

    //buat button selanjutnya
    public void OpenCaseAnalyze()
    {
        HandbookManager.instance.SpawnAllCaseAnswer(caseSOs);        
    }

    public void SetUpCaseAnalyzer(CaseAnalyzer caseAnalyzer, List<CaseSO> cases)
    {
        this.caseAnalyzer = caseAnalyzer;
        caseSOs = cases;
    }

}
