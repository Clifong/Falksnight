using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperCanvasManager : MonoBehaviour
{
    public Transform itemContent;
    public Transform equipmentContent;
    public ShopkeeperSO shopkeeperSO;
    
    public void SendDataToUI() {
        foreach (ItemSO item in shopkeeperSO.itemsSold)
        {
            Instantiate(item.itemWithGridImageForShop, itemContent);
        } 
        foreach (WeaponSO equipment in shopkeeperSO.equipmentSold)
        {   
            Instantiate(equipment.equipmentInSphereGridForShop, equipmentContent);     
        }
    }

    public void Something( object data) {

    }
}
