using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAndExpManager : MonoBehaviour
{
    public static MoneyAndExpManager moneyAndExpManager;
    private Dictionary<PlayerSO, int> allPlayerDict = new Dictionary<PlayerSO, int>();
    [SerializeField]
    private int moneyEarned;
    // Start is called before the first frame update
    void Start()
    {
        if (moneyAndExpManager != null){
            Destroy(moneyAndExpManager);
        }
        moneyAndExpManager = this;
        foreach (Player player in CharacterManager.characterManager.ReturnAllPlayers())
        {
            allPlayerDict.Add(player.GetPlayerSO(), 0);
        }
    }

    public void AddMoney(int money) {
        moneyEarned += money;
    }

    public void LoseMoney(int money) {
        moneyEarned -= money;
    }

    public void AddExp(PlayerSO playerSO, int exp) {
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

    public void FinallyDisplayMoney() {
        WinUIManager.winUIManager.DisplayMoneyEarned(moneyEarned);
    }

    public void FinallyAddExp() {
        foreach (PlayerSO playerSOInDict in allPlayerDict.Keys)
        {
            Debug.Log(playerSOInDict.name + " " + allPlayerDict[playerSOInDict].ToString());
            playerSOInDict.AddExp(allPlayerDict[playerSOInDict]);
        }    
    }
    
}
