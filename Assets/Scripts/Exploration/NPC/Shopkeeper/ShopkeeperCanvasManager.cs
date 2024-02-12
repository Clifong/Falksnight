using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperCanvasManager : MonoBehaviour
{
    public Transform itemContent;
    public Transform equipmentContent;
    public ShopkeeperSO shopkeeperSO;
    public List<GameObject> icons;
    
    public void SendDataToUI() {
        foreach (GameObject gameObject in icons)
        {
            Destroy(gameObject);
        }

        foreach (ItemSO item in shopkeeperSO.itemsSoldDict.GetAllItems())
        {
            GameObject icon = Instantiate(item.itemWithGridImageForShop, itemContent);
            icons.Add(icon);
        } 
        foreach (WeaponSO equipment in shopkeeperSO.weaponsSoldDict.GetAllWeapons())
        {   
            GameObject icon = Instantiate(equipment.weaponInSphereGridForShop, equipmentContent);     
            icons.Add(icon);
        }   
    }

    public void DeleteIcons(List<ShopIcons> icons) {
        foreach (ShopIcons shopIcon in icons)
        {
            this.icons.Remove(shopIcon.gameObject);
            Destroy(shopIcon.gameObject);
        }
    }
}
