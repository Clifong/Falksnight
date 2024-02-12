using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{
    private List<ItemSO> stackOfItemsBought = new List<ItemSO>();
    private List<WeaponSO> stackOfWeaponsBought = new List<WeaponSO>();
    private bool isMultiPurchaseEnabled = false;
    public CrossObjectEvent canPurchase;
    public CrossObjectEvent cannotPurchase;
    public CrossObjectEventWithData SendDataToUI;
    public ShopTotalCostManager adjustUIWhenChangingBoughtStuff;
    public ShopkeeperCanvasManager shopkeeperCanvasManager;
    private int totalCost = 0;
    private List<ShopIcons> allShopIcons = new List<ShopIcons>();

    public void ResetData() {
        totalCost = 0;
        stackOfItemsBought = new List<ItemSO>();
        stackOfWeaponsBought = new List<WeaponSO>();
        foreach (ShopIcons shopIcons in allShopIcons)
        {
            shopIcons.ChangeBuyingForSingleBuy();
        }
        allShopIcons = new List<ShopIcons>();
        cannotPurchase.TriggerEvent();
    }

    public void EnableOrDisableMultiPurchasing() {
        ResetData();
        isMultiPurchaseEnabled = !isMultiPurchaseEnabled;
        adjustUIWhenChangingBoughtStuff.ChangeCostText(totalCost);
        if (!isMultiPurchaseEnabled) {
            cannotPurchase.TriggerEvent();
            adjustUIWhenChangingBoughtStuff.gameObject.SetActive(false);
        } else {
            adjustUIWhenChangingBoughtStuff.gameObject.SetActive(true);
        }
    }

    public void AddDataToList(Component component, object data) {
        object[] temp = (object[]) data;
        object addingThing = temp[0];
        
        if (!isMultiPurchaseEnabled) {
            if (allShopIcons.Count > 0) {
                if (allShopIcons[0] != (ShopIcons) component) {
                    allShopIcons[0].ChangeBuyingForSingleBuy();
                    stackOfWeaponsBought.Clear();
                    stackOfItemsBought.Clear();
                    allShopIcons[0] = (ShopIcons) component;
                }
            } else {
                allShopIcons.Add((ShopIcons) component);
            }
        } else {
            allShopIcons.Add((ShopIcons) component);
        }

        if ((bool) temp[1]) {

            if (addingThing is ItemSO) {
                stackOfItemsBought.Add((ItemSO) addingThing);
                totalCost += ((ItemSO) addingThing).cost;
            } else if (addingThing is WeaponSO) {
                stackOfWeaponsBought.Add((WeaponSO) addingThing);
                totalCost += ((WeaponSO)addingThing).cost;
            }

        } else {
        
            if (addingThing is ItemSO) {
                stackOfItemsBought.Remove((ItemSO) addingThing);
                totalCost -= ((ItemSO) addingThing).cost;
            } else if (addingThing is WeaponSO) {
                stackOfWeaponsBought.Remove((WeaponSO) addingThing);
                totalCost -= ((WeaponSO)addingThing).cost;
            }

        }
        
        if (totalCost == 0) {
            cannotPurchase.TriggerEvent();
        } else {
            canPurchase.TriggerEvent();
        }

        if (isMultiPurchaseEnabled) {
            adjustUIWhenChangingBoughtStuff.ChangeCostText(totalCost);
        }
    }

    public void SendDataToCheckoutUI() {
        SendDataToUI.TriggerEvent(this, stackOfItemsBought, stackOfWeaponsBought, totalCost);
    }

    public void DeleteBoughtStuffIcons() {
        shopkeeperCanvasManager.DeleteIcons(allShopIcons);
        ResetData();
    }
    
}
