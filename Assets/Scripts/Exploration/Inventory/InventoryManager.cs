using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public PlayerData playerData;
    public static InventoryManager inventoryManager;
    private static int counter = 0;
    [SerializeField]
    private List<ItemSO> allItems;
    [SerializeField]
    private List<WeaponSO> allEquipment;
    [SerializeField]
    private List<ConfidantItemSO> allConfidantItems;


    // Start is called before the first frame update
    void Start()
    {
        if (InventoryManager.counter >= 1){
            Destroy(this.gameObject);
        }
        inventoryManager = this;
        InventoryManager.counter += 1;
        if (InventoryManager.counter == 10){
            InventoryManager.counter = 1;
        }
        allItems = playerData.inventoryItems;
        allEquipment = playerData.equipmentItems;
        allConfidantItems = playerData.confidantItems;
    }

    public void RemoveItem(ItemSO item) {
        allItems.Remove(item);
        playerData.inventoryItems = allItems;
    }

    public void RemoveConfidantItem(ConfidantItemSO confidantItemSO) {
        allConfidantItems.Remove(confidantItemSO);
        playerData.confidantItems = allConfidantItems;
    }

    public void AddNewItems(List<ItemSO> newItems){
        foreach (ItemSO item in newItems)
        {
            allItems.Add(item);
        }
        playerData.inventoryItems = allItems;
    }

    public void AddNewItems(Component component, object data){
        object[] temp = (object[]) data;
        List<ItemSO> newItems = (List<ItemSO>) temp[0];
        List<WeaponSO> newWeapons = (List<WeaponSO>) temp[1];
        foreach (ItemSO item in newItems)
        {
            allItems.Add(item);
        }
        foreach (WeaponSO weapon in newWeapons)
        {
            allEquipment.Add(weapon);
        }
        playerData.inventoryItems = allItems;
        playerData.equipmentItems = allEquipment;
    }

    public void SendDataToInventoryUI(){
        ItemUIManager.itemUIManager.InstantiateImage(allItems);
        EquipmentUIManager.equipmentUIManager.InstantiateImage(allEquipment);
        ConfidantInventoryUIManager.confidantInventoryUIManager.InstantiateImage(allConfidantItems);
    }

    public void SendDataToConfidantGiftUI() {
        ConfidantGiftManager.confidantGiftManager.InstantiateImage(allConfidantItems);
    }

    public void SendDataToSwitchWeaponUI() {
        PlayerSwitchWeaponUIManager.playerSwitchWeaponUIManager.InstantiateImage(allEquipment);
    }
}
