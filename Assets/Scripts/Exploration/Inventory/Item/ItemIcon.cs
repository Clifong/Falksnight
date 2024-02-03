using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    [SerializeField]
    private ItemSO itemData;
    private GameObject reference;
    public CrossObjectEventWithData crossObjectEventWithData;
    
    public void SetData(){
        ItemUIManager.itemUIManager.SetData(itemData);
    }

    public void SetDataForCrossObjectEventWithData() {
        crossObjectEventWithData.TriggerEvent(this, itemData);
    }   

    public void SetReference(GameObject reference) {
        this.reference = reference;
    }

    public void SetItemReference() {
        ItemUIManager.itemUIManager.SetItemReference(itemData, reference);
    }
}
