using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftingManager : MonoBehaviour
{
    public static GiftingManager giftingManager;
    private GameObject itemIcon;
    private ConfidantItemSO confidantItemSO;
    private PlayerSO referencedPlayer;
    void Start()
    {
       if (giftingManager != null) {
        Destroy(giftingManager);
       } 
       giftingManager = this;
    }

    public void SetReferencePlayer(PlayerSO playerSO) {
        referencedPlayer = playerSO;
    }

    public void SetReference(GameObject itemIcon, ConfidantItemSO confidantItemSO) {
        this.itemIcon = itemIcon;
        this.confidantItemSO = confidantItemSO;
    }

    public void GiftItem() {
        referencedPlayer.RaiseRelationsipExp(confidantItemSO.relationshipExp);
        ConfidantUIManager.confidantUIManager.SetConfidantInfo(referencedPlayer);
        ConfidantGiftManager.confidantGiftManager.RemoveConfidantItem(itemIcon);
        InventoryManager.inventoryManager.RemoveConfidantItem(confidantItemSO);
    }
}
