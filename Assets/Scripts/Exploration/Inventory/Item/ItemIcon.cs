using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : ShopIcons
{
    [SerializeField]
    private ItemSO itemData;
    private GameObject reference;
    public CrossObjectEventWithData crossObjectEventWithData;
    
    public void SetData(){
        ItemUIManager.itemUIManager.SetData(itemData);
    }

    public override void SetDataForCrossObjectEventWithData() {
        isPurchasing = !isPurchasing;
        if (isPurchasing) {
            SelectThis();
            crossObjectEventWithData.TriggerEvent(this, itemData, true);
        } else {
            UnselectThis();
            crossObjectEventWithData.TriggerEvent(this, itemData, false);
        }
    }   

    public override void ChangeBuyingForSingleBuy() {
        isPurchasing = !isPurchasing;
        if (isPurchasing) {
            SelectThis();
        } else {
            UnselectThis();
        }
    }

    public void SetReference(GameObject reference) {
        this.reference = reference;
    }

    public void SetItemReference() {
        ItemUIManager.itemUIManager.SetItemReference(itemData, reference);
    }
}
