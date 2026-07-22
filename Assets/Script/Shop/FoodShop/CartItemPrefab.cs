using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CartItemPrefab : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private FoodCart foodCart;

    [Header("UI")]
    [SerializeField] private TMP_Text foodQuantity;
    [SerializeField] private TMP_Text foodName;
    [SerializeField] private TMP_Text totalPrice;

    public void SetUpItem(FoodCart data)
    {
        foodCart = data;
        foodQuantity.text = foodCart.quantity.ToString();
        foodName.text = foodCart.food.foodName;
        totalPrice.text = $"{foodCart.quantity * foodCart.food.foodPrice}";
    }
}
