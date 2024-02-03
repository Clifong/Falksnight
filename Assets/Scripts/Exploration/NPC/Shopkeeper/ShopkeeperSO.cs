using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shopkeeper SO", menuName = "NPC/Shopkeeper goods", order = 1)]
public class ShopkeeperSO : ScriptableObject
{
    public List<ItemSO> itemsSold;
    public List<WeaponSO> equipmentSold;
}
