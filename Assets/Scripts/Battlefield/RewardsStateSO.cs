using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battlefield rewards", menuName = "Battlefield rewards", order = 1)]
public class RewardsStateSO : ScriptableObject
{
    public int moneyEarned;
    public int expEarned;
    public List<WeaponSO> weaponRewards;
    public List<ItemSO> itemRewards;
    public List<ConfidantItemSO> confidantRewards;

    void Start()
    {
        moneyEarned = 0;
        expEarned = 0;
        weaponRewards = new List<WeaponSO>();
        itemRewards = new List<ItemSO>();
        confidantRewards = new List<ConfidantItemSO>();
    }

    public void AddMoney(int money) {
        moneyEarned += money;
    }

    public void LoseMoney(int money) {
        moneyEarned -= money;
    }

    public void AddTempItem(List<ItemSO> itemsGained) {
        foreach (ItemSO item in itemsGained)
        {
            itemRewards.Add(item);
        }
    }

    public void RemoveTempItem(ItemSO item) {
        itemRewards.Remove(item);
    }

    
    public void FinallyAddToInventory() {
        InventoryManager.inventoryManager.AddNewItems(itemRewards);
    }

    public void AddExp(Dictionary<PlayerSO, int> allPlayerDict, PlayerSO playerSO, int exp) {
        int remainingPlayer = allPlayerDict.Count - 1;
        if (remainingPlayer == 0) {
            remainingPlayer = 1;
        }
        List<PlayerSO> keys = new List<PlayerSO>(allPlayerDict.Keys);
        foreach (PlayerSO playerSOInDict in keys)
        {
            if (playerSO == playerSOInDict) {
                allPlayerDict[playerSO] += exp;
            } else {
                allPlayerDict[playerSOInDict] += (int)Mathf.Ceil((float)exp/(float)remainingPlayer);
            }
        }     
    }
}
