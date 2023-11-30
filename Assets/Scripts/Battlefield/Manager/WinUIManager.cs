using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinUIManager : MonoBehaviour
{
    public static WinUIManager winUIManager;
    public Canvas winUICanvas;
    public TextMeshProUGUI moneyEarnedText;
    public Transform content;

    void Awake()
    {
        winUICanvas.enabled = false;
        if (winUIManager != null){
            Destroy(winUIManager);
        }
        winUIManager = this;
    }

    public void ShowWinPanel() {
        ItemAndEquipmentGainTempManager.itemAndEquipmentGainTempManager.DisplayAllTempItem();
        MoneyAndExpManager.moneyAndExpManager.FinallyDisplayMoney();
        winUICanvas.enabled = true;
    }
    
    public void ExitBattle() {
        LevelManager.WinBattle(this);
    }

    public void DisplayAllItemAndEquipmentGained(List<Item> allItem) {
        foreach (Item item in allItem)
        {
            Instantiate(item.itemWithGridImageAndName, content);
        }
    }

    public void DisplayMoneyEarned(int money) {
        moneyEarnedText.text = money.ToString();
    }
}
