using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShopData", menuName = "Scriptable Objects/Shop Data")]
public class ShopSO : ScriptableObject
{
    public string shopName;
    public int shopOpenHour;
    public int shopCloseHour;
}
