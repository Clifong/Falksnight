using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenInventory : MonoBehaviour
{
    void OnOpenInventory(){
        PlayerAttackDisabler.playerAttackDisabler.ChangeEnable();
        InventoryManager.inventoryManager.SendDataToInventoryUI();
    }

    public void OpenInventory(){
        OnOpenInventory();
    }
}
