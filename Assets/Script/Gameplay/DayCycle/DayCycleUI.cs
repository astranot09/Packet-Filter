using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DayCycleUI : MonoBehaviour
{
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private TMP_Text timeText;

    private void Start()
    {
        UpdateDayCycleUI();
    }

    public void UpdateDayCycleUI()
    {
        dayText.text = $"Day : {DayCycleManager.instance.DayCount}";
        timeText.text = $"Time : {DayCycleManager.instance.Hour:D2}:{DayCycleManager.instance.Minute:D2}";
    }
}
