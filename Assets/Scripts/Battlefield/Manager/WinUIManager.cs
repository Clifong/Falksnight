using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinUIManager : MonoBehaviour
{
    public static WinUIManager winUIManager;
    public RewardsStateSO rewardsStateSO;
    public TextMeshProUGUI moneyEarnedText;
    public Transform content;

    void Awake()
    {
        if (winUIManager != null){
            Destroy(winUIManager);
        }
        winUIManager = this;
    }

    public void ShowWinPanel() {
        moneyEarnedText.text = rewardsStateSO.moneyEarned.ToString();
        foreach (Item item in rewardsStateSO.itemRewards)
        {
            Instantiate(item.itemWithGridImageAndName, content);
        }
    }
}
