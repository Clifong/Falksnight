using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfidantItemIcon : MonoBehaviour
{
    public ConfidantItemSO confidantSO;

    public void SetCurrentConfidantItemSO() {
        ConfidantInventoryUIManager.confidantInventoryUIManager.SetData(confidantSO);
        ConfidantGiftManager.confidantGiftManager.SetCurrentConfidantItemSO(this.gameObject, confidantSO);
    }
}
