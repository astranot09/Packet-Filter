using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DayCycleUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;

    private void OnEnable()
    {
        if(DayCycleManager.instance != null)
        {
            DayCycleManager.instance.onTimeChanged += UpdateDayCycleUI;
        }
    }
    private void OnDisable()
    {
        if(DayCycleManager.instance != null)
        {
            DayCycleManager.instance.onTimeChanged -= UpdateDayCycleUI;
        }
    }

    private void Start()
    {
        if (DayCycleManager.instance != null)
        {
            DayCycleManager.instance.onTimeChanged += UpdateDayCycleUI;
            UpdateDayCycleUI();
        }
    }

    // Jangan lupa bersihkan event saat UI mati/hancur
    private void OnDestroy()
    {
        if (DayCycleManager.instance != null)
        {
            DayCycleManager.instance.onTimeChanged -= UpdateDayCycleUI;
        }
    }

    public void UpdateDayCycleUI()
    {
        timeText.text = $"{DayCycleManager.instance.Hour:D2}.{DayCycleManager.instance.Minute:D2}";
    }
}
