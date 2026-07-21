using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodShopItem : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private FoodShopSO foodSO;

    [Header("UI")]
    [SerializeField] private Image foodImage;
    [SerializeField] private TMP_Text foodName;
    [SerializeField] private TMP_Text foodPrice;
    [SerializeField] private TMP_Text foodStamina;


    public void SetUpItem(FoodShopSO sO)
    {
        foodSO = sO;
        foodImage.sprite = foodSO.foodIcon;
        foodName.text = foodSO.foodName;
        foodPrice.text = foodSO.foodPrice.ToString();
        foodStamina.text = foodSO.foodStamina.ToString();
    }

    public void BuyFood()
    {
        FoodShopManager.instance.AddItem(foodSO);
    }

}
