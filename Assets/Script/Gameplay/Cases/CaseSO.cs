using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCase", menuName = "Scriptable Objects/Case Data")]
public class CaseSO : ScriptableObject
{
    public CaseCategory caseCategory;
    public string correctString;
    public List<string> falseString;
}
