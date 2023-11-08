using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public PlayerData playerData;
    public static InventoryManager inventoryManager;
    private static int counter = 0;
    [SerializeField]
    private List<Item> allItems;

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
        DontDestroyOnLoad(this.gameObject);
        allItems = playerData.inventoryItems;
    }

    public void RemoveItem(Item item) {
        allItems.Remove(item);
        playerData.inventoryItems = allItems;
    }

    public void AddNewItems(List<Item> newItems){
        foreach (Item item in newItems)
        {
            allItems.Add(item);
        }
        playerData.inventoryItems = allItems;
    }

    public void SendDataToInventoryUI(){
        InventoryUIManager.inventoryUIManager.InstantiateImage(allItems);
    }
}
