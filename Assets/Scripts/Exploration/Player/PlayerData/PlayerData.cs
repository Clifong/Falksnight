using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public List<ItemSO> inventoryItems;
    public List<WeaponSO> equipmentItems;
    public List<ConfidantItemSO> confidantItems;
}
