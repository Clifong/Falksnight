using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private int phaseIndex = 0;
    protected int oldBaseHealth;

    protected override void Die(PlayerSO playerSO){
        if (phaseIndex == ((BossSO)enemySO).phaseHealth.Count) {
            EnemyManager.enemyManager.UpdateList(this);
            ItemAndEquipmentGainTempManager.itemAndEquipmentGainTempManager.AddTempItem(enemySO.itemDrop);
            MoneyAndExpManager.moneyAndExpManager.AddMoney(enemySO.returnRandomMoney());
            MoneyAndExpManager.moneyAndExpManager.AddExp(playerSO, enemyExp);
            // anime.SetBool("die", true);
            enemySO.baseHealth = oldBaseHealth;
            Destroy(gameObject);
        } else { 
            enemySO.baseHealth = ((BossSO)enemySO).phaseHealth[phaseIndex];
            currentHealth = ((BossSO)enemySO).phaseHealth[phaseIndex];
        }
        phaseIndex++;
    }
}
