using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsManager : MonoBehaviour
{
    public static RewardsManager rewardsManager;
    public RewardsStateSO rewardsStateSO;
    private Dictionary<PlayerSO, int> allPlayerDict = new Dictionary<PlayerSO, int>();

    void Start()
    {
        if (rewardsManager != null){
            Destroy(rewardsManager);
        }
        else {
            rewardsManager = this;
        }
        foreach (Player player in CharacterManager.characterManager.ReturnAllPlayers())
        {
            allPlayerDict.Add(player.GetPlayerSO(), 0);
        }
    }

    public void AddMoney(int money) {
        rewardsStateSO.AddMoney(money);
    }

    public void AddExp(PlayerSO playerSO, int exp) {
        rewardsStateSO.AddExp(allPlayerDict, playerSO, exp);
    }

    public void AddTempItem(List<Item> item) {
        rewardsStateSO.AddTempItem(item);
    }
}
