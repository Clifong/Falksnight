using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenAll : MonoBehaviour
{
    public CrossObjectEvent openParty;
    public CrossObjectEvent openInventory;
    public CrossObjectEvent openPlayerMenu;
    private bool condition = true;
    
    public void OnOpenParty() {
        if (condition) {
            openParty.TriggerEvent();
        }
    }

    public void OnOpenInventory(){
        if (condition) {
            openInventory.TriggerEvent();
        }
    }

    public void OnOpenPlayerMenu() {
        if (condition) {
            openPlayerMenu.TriggerEvent();
        }
    }

    public void ChangeEnable() {
        this.condition = !this.condition;
    }
}
