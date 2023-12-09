using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponButton : MonoBehaviour
{
    public void SwitchPlayerWeapon() {
        PlayerSwitchWeaponUIManager.playerSwitchWeaponUIManager.SwitchWeapon();
    }
}
