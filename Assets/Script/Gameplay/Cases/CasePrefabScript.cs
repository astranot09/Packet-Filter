using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CasePrefabScript : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private CategoryDatas caseData;

    [Header("UI")]
    [SerializeField] private Image profileImage;

    public void SetUp(CategoryDatas data)
    {
        caseData = data;
    }
}
