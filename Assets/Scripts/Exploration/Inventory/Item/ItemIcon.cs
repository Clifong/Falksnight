using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    [SerializeField]
    private Item itemData;
    
    public void SetData(){
        InventoryUIManager.inventoryUIManager.SetData(itemData);
    }
}
