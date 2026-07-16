using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    [Header("Currency")]
    [SerializeField] private TMP_Text playerCurrencyUI;

    [Header("Hunger")]
    [SerializeField] private TMP_Text playerHungerUI;

    [Header("Experience")]
    [SerializeField] private TMP_Text playerLevelUI;
    [SerializeField] private Slider playerSliderProgressUI;

    private void OnEnable()
    {
        if(PlayerScript.instance != null)
        {
            PlayerScript.instance.onCurrencyChanged += UpdateCurrencyUI;

            PlayerScript.instance.onExperienceChanged += UpdateExperienceUI;

            PlayerScript.instance.onHungerChanged += UpdateHungerUI;
        }

    }
    private void OnDisable()
    {
        if (PlayerScript.instance != null)
        {
            PlayerScript.instance.onCurrencyChanged -= UpdateCurrencyUI;

            PlayerScript.instance.onExperienceChanged -= UpdateExperienceUI;

            PlayerScript.instance.onHungerChanged -= UpdateHungerUI;
        }

    }

    private void Start()
    {
        if (PlayerScript.instance != null)
        {
            PlayerScript.instance.onCurrencyChanged += UpdateCurrencyUI;

            PlayerScript.instance.onExperienceChanged += UpdateExperienceUI;

            PlayerScript.instance.onHungerChanged += UpdateHungerUI;
        }
        UpdateCurrencyUI();
        UpdateExperienceUI();
        UpdateHungerUI();
    }

    // Jangan lupa bersihkan event saat UI mati/hancur
    private void OnDestroy()
    {
        if (PlayerScript.instance != null)
        {
            PlayerScript.instance.onCurrencyChanged -= UpdateCurrencyUI;

            PlayerScript.instance.onExperienceChanged -= UpdateExperienceUI;

            PlayerScript.instance.onHungerChanged -= UpdateHungerUI;
        }
    }


    public void UpdateExperienceUI()
    {
        playerLevelUI.text = PlayerScript.instance.PlayerLevel.ToString();
        playerSliderProgressUI.maxValue = PlayerScript.instance.MaxExperience;
        playerSliderProgressUI.value = PlayerScript.instance.CurrentExperience;
    }

    public void UpdateHungerUI()
    {
        playerHungerUI.text = PlayerScript.instance.Hunger.ToString();
    }

    public void UpdateCurrencyUI()
    {
        playerCurrencyUI.text = PlayerScript.instance.Currency.ToString();
    }


    IEnumerator EventCoroutine()
    {
        yield return null;
    }
}
