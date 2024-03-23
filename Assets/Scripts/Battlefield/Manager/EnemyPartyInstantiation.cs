using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartyInstantiation : MonoBehaviour
{
    public List<Transform> enemyPosition;
    public EnemyPartySO enemyPartySO;
    public CrossObjectEvent allEnemiesSpawned;

    private void Start(){
        for (int i = 0; i < enemyPartySO.ReturnAllEnemies().Count; i++)
        {
            Instantiate(enemyPartySO.enemyParty[i].enemyGameObject, enemyPosition[i].position, Quaternion.identity);
        }
        Debug.Log("ENEMIES");
        allEnemiesSpawned.TriggerEvent();
    }
}
