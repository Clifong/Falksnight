using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : ShopIcons
{
    [SerializeField]
    private WeaponSO equipmentData;
    private GameObject reference;
    public CrossObjectEventWithData crossObjectEventWithData;
    
    public void SetData(){
        EquipmentUIManager.equipmentUIManager.SetData(equipmentData);
        PlayerSwitchWeaponUIManager.playerSwitchWeaponUIManager.SetData(equipmentData);
    }

    public override void SetDataForCrossObjectEventWithData() {
        isPurchasing = !isPurchasing;
        if (isPurchasing) {
            SelectThis();
            crossObjectEventWithData.TriggerEvent(this, equipmentData, true);
        } else {
            UnselectThis();
            crossObjectEventWithData.TriggerEvent(this, equipmentData, false);
        }
    }   

    public override void ChangeBuyingForSingleBuy() {
        isPurchasing = !isPurchasing;
        if (isPurchasing) {
            SelectThis();
        } else {
            UnselectThis();
        }
    }

    public void SetReference(GameObject reference) {
        this.reference = reference;
    }
}
