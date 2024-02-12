using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[System.Serializable]
public class ItemsSoldDictionary {
    [SerializedDictionary("Items sold", "Cost")]
    public SerializedDictionary<ItemSO, int> itemsSoldDict;
    public List<ItemSO> GetAllItems() {
        return (List<ItemSO>) itemsSoldDict.GetKeys();
    }

    public List<int> GetCostOfEachItem() {
        return (List<int>) itemsSoldDict.GetValue();
    }
}

[System.Serializable]
public class WeaponsSoldDictionary {
    [SerializedDictionary("Weapons sold", "Cost")]
    public SerializedDictionary<WeaponSO, int> weaponsSoldDict;
    public List<WeaponSO> GetAllWeapons() {
        return (List<WeaponSO>) weaponsSoldDict.GetKeys();
    }

    public List<int> GetCostOfEachWeapon() {
        return (List<int>) weaponsSoldDict.GetValue();
    }
}


[CreateAssetMenu(fileName = "Shopkeeper SO", menuName = "NPC/Shopkeeper goods", order = 1)]
public class ShopkeeperSO : ScriptableObject {
    public ItemsSoldDictionary itemsSoldDict;
    public WeaponsSoldDictionary weaponsSoldDict;
}
