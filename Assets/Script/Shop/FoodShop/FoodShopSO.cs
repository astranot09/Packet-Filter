using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Scriptable Objects/Food Data")]
public class FoodShopSO : ScriptableObject
{
    public Sprite foodIcon;
    public string foodName;
    public int foodPrice;
    public int foodStamina;    
}
