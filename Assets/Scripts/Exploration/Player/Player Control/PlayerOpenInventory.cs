using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenInventory : MonoBehaviour
{
    void OnOpenInventory(){
        PlayerAttackDisabler.playerAttackDisabler.ChangeEnable();
        PlayerMovementDisabler.playerMovementDisabler.ChangeEnable();
        InventoryManager.inventoryManager.SendDataToInventoryUI();
    }

    public void OpenInventory(){
        OnOpenInventory();
    }
}
