using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftingButton : MonoBehaviour
{
    public void SendDataToConfidantGiftUI() {
        InventoryManager.inventoryManager.SendDataToConfidantGiftUI();
    }
}
