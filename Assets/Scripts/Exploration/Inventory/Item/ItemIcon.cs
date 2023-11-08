using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    [SerializeField]
    private Item itemData;
    private GameObject reference;
    
    public void SetData(){
        InventoryUIManager.inventoryUIManager.SetData(itemData);
    }

    public void SetReference(GameObject reference) {
        this.reference = reference;
    }

    public void SetItemReference() {
        InventoryUIManager.inventoryUIManager.SetItemReference(itemData, reference);
    }
}
