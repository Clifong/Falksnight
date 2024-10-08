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
    }

    public void FillDictionary(Component component, object data) {
        object[] temp = (object[]) data;
        foreach (Player player in (List<Player>) temp[0])
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

    public void AddTempItem(List<ItemSO> item) {
        rewardsStateSO.AddTempItem(item);
    }
}
