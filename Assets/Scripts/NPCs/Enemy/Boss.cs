using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private int phaseIndex = 0;
    protected int oldBaseHealth;

    protected override void Die(PlayerSO playerSO){
        if (phaseIndex == ((BossSO)enemySO).phaseHealth.Count) {
            enemySO.baseHealth = oldBaseHealth;
            base.Die(playerSO);
        } else { 
            enemySO.baseHealth = ((BossSO)enemySO).phaseHealth[phaseIndex];
            currentHealth = ((BossSO)enemySO).phaseHealth[phaseIndex];
        }
        phaseIndex++;
    }
}
