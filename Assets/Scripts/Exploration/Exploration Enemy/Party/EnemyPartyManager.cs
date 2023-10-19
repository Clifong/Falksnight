using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartyManager : MonoBehaviour
{
    public static EnemyPartyManager enemyPartyManager;
    private static int counter = 0;
    [SerializeField]
    private List<EnemySO> enemyPartyInfo = new List<EnemySO>();
    private ExplorationEnemySO explorationEnemySO;
    
    void Start()
    {
        if (EnemyPartyManager.counter >= 1){
            Destroy(this.gameObject);
        }
        enemyPartyManager = this;
        EnemyPartyManager.counter += 1;
        if (EnemyPartyManager.counter == 10){
            EnemyPartyManager.counter = 1;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetEnemyParty(ExplorationEnemySO explorationEnemySO){
        enemyPartyInfo = explorationEnemySO.enemies;
        this.explorationEnemySO = explorationEnemySO;
    }

    public List<EnemySO> returnEnemyPartyMembers(){
        return enemyPartyInfo;
    }

    public void SetEnemyDead(){
        explorationEnemySO.dead = true;
    }
}
