using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInventoryUIManager : MonoBehaviour
{
    public Transform content;
    public PlayerData playerData;
    private List<GameObject> icons = new List<GameObject>();
    public GameObject useButton;

    public void InstantiateIcon() {
        foreach (GameObject icon in icons)
        {
            Destroy(icon);
        }
        foreach (ItemSO item in playerData.inventoryItems)
        {
            GameObject itemIcon = Instantiate(item.itemWithGridImageForBattle, content);
            icons.Add(itemIcon);
        }
    }
}
