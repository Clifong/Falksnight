using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy party SO", menuName = "Enemy party SO", order = 1)]
public class EnemyPartySO : ScriptableObject
{
    public List<EnemySO> enemyParty;
    public ExplorationEnemySO explorationEnemySO;

    public List<EnemySO> ReturnAllEnemies(){
        return enemyParty;
    }

    public void SetEnemyDead() {
        explorationEnemySO.dead = true;
    }

    public void SetEnemyParty(ExplorationEnemySO explorationEnemySO) {
        this.explorationEnemySO = explorationEnemySO;
        enemyParty = explorationEnemySO.enemies;
    }
}
