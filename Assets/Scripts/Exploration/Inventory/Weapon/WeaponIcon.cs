using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIcon : MonoBehaviour
{
    [SerializeField]
    private WeaponSO equipmentData;
    private GameObject reference;
    
    public void SetData(){
        EquipmentUIManager.equipmentUIManager.SetData(equipmentData);
        PlayerSwitchWeaponUIManager.playerSwitchWeaponUIManager.SetData(equipmentData);
    }

    public void SetReference(GameObject reference) {
        this.reference = reference;
    }

    // public void SetItemReference() {
    //     EquipmentUIManager.equipmentUIManager.SetItemReference(equipmentData, reference);
    // }
}
