using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodCart
{
    public FoodShopSO food;
    public int quantity;

    public FoodCart(FoodShopSO food, int quantity)
    {
        this.food = food;
        this.quantity = quantity;
    }

}

public class FoodShopManager : MonoBehaviour
{
    public static FoodShopManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [SerializeField] private List<FoodShopSO> allFoodData = new List<FoodShopSO>();
    [SerializeField] private Transform foodSpawner;
    [SerializeField] private GameObject foodPrefab;


    [Header("Cart")]
    [SerializeField] private List<FoodCart> cartFoodData = new List<FoodCart>();
    [SerializeField] private Transform foodCartSpawner;
    [SerializeField] private GameObject foodCartPrefab;

    [Header("UI")]
    [SerializeField] private GameObject shopPanel;

    public void OpenShop()
    {
        ClearCart();
        if (shopPanel.activeSelf)
        {
            PlayerInputController.instance.TurnOnPlayerInput();
        }
        shopPanel.SetActive(!shopPanel.activeSelf);


        if (foodSpawner.childCount > 0) return;

        foreach(var foodShop in allFoodData)
        {
            if (foodShop != null)
            {
                GameObject x = Instantiate(foodPrefab, foodSpawner);
                x.GetComponent<FoodShopItem>().SetUpItem(foodShop);
            }
        }
    }

    public void AddItem(FoodShopSO item)
    {
        if (item == null) return;

        // 1. Check if item already exists in the cart
        FoodCart existingCartItem = cartFoodData.Find(x => x.food == item);

        if (existingCartItem != null)
        {
            // Item exists, just increment quantity
            existingCartItem.quantity++;
        }
        else
        {
            // Item isn't in cart yet, create new entry
            cartFoodData.Add(new FoodCart(item, 1));
        }
        UpdateUICart();
    }

    public void ClearCart()
    {
        cartFoodData.Clear();
        UpdateUICart();
    }

    public void BuyItem()
    {
        int totalCost = ItemPriceCalculation();

        if (cartFoodData.Count == 0)
        {
            Debug.Log("Cart is empty!");
            return;
        }

        if (PlayerScript.instance.CheckCurrency(totalCost))
        {
            PlayerScript.instance.RemoveCurrency(totalCost);
            ClearCart();
            Debug.Log($"Purchased items for total: {totalCost}");
            Debug.Log("Purchase Successful!");
        }
        else
        {
            Debug.Log("Not enough money!");
        }

    }

    public int ItemPriceCalculation()
    {
        int totalPrice = 0;

        foreach (FoodCart cartItem in cartFoodData)
        {
            if (cartItem.food != null)
            {
                // Assumes your FoodShopSO scriptable object has a 'price' variable
                totalPrice += cartItem.food.foodPrice * cartItem.quantity;
            }
        }

        return totalPrice;
    }

    public void UpdateUICart()
    {
        foreach (Transform child in foodCartSpawner)
        {
            Destroy(child.gameObject);
        }

        foreach (FoodCart cartItem in cartFoodData)
        {
            GameObject x = Instantiate(foodCartPrefab, foodCartSpawner);
            x.GetComponent<CartItemPrefab>().SetUpItem(cartItem);
        }
    }
}
