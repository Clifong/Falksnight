using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIconInventory : PlayerIcon
{
    private PlayerSO playerSO;

    public void SetField(PlayerSO playerSO){
        this.playerSO = playerSO;
        name.text = playerSO.name;
        healthSlider.value = playerSO.getHealthRatio();
        healthValue.text = playerSO.currentHealth.ToString() + "/" + playerSO.baseHealth.ToString();
    }

    public void SetSelectedPlayer() {
        InventoryUIManager.inventoryUIManager.SetSelectedPlayer(playerSO);
    }
}
