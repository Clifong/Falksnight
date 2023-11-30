using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAndEquipmentGainTempManager : MonoBehaviour
{
    public static ItemAndEquipmentGainTempManager itemAndEquipmentGainTempManager;
    [SerializeField]
    private List<Item> itemGain = new List<Item>();

    private void Awake() {
        if (itemAndEquipmentGainTempManager != null) {
            Destroy(itemAndEquipmentGainTempManager);
        }
        itemAndEquipmentGainTempManager = this;
    }

    public void AddTempItem(List<Item> itemsGained) {
        foreach (Item item in itemsGained)
        {
            itemGain.Add(item);
        }
    }

    public void RemoveTempItem(Item item) {
        itemGain.Remove(item);
    }

    public void DisplayAllTempItem() {
        FinallyAddToInventory();
        WinUIManager.winUIManager.DisplayAllItemAndEquipmentGained(itemGain);
    }

    public void FinallyAddToInventory() {
        InventoryManager.inventoryManager.AddNewItems(itemGain);
    }
}
