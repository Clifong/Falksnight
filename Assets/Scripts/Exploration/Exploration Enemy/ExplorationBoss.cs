using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationBoss : ExplorationEnemy
{
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "target"){
            enemyPartySO.SetEnemyParty(explorationEnemySO);
            LevelManager.LoadLevel(this, "BossBattlefield");
        }
    }
}
