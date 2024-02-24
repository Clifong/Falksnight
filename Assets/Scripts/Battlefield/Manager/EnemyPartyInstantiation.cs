using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartyInstantiation : MonoBehaviour
{
    public List<Transform> enemyPosition;
    private List<EnemySO> enemyParty;
    public CrossObjectEvent allEnemiesSpawned;

    private void Start(){
        enemyParty = EnemyPartyManager.enemyPartyManager.returnEnemyPartyMembers();
        for (int i = 0; i < enemyParty.Count; i++)
        {
            Instantiate(enemyParty[i].enemyGameObject, enemyPosition[i].position, Quaternion.identity);
        }
        allEnemiesSpawned.TriggerEvent();
    }
}
