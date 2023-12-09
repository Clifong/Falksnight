using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeaponButton : MonoBehaviour
{
    public void SendData() {
        InventoryManager.inventoryManager.SendDataToSwitchWeaponUI();
    }
}
