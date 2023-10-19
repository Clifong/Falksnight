using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingManagerEnemy : MonoBehaviour
{
    public GameObject selectTargetEnemy;
    public static TargetingManagerEnemy targetingManagerEnemy;
    void Awake()
    {
        if (targetingManagerEnemy != null){
            Destroy(targetingManagerEnemy);
        }    
        targetingManagerEnemy = this;
    }

    public void SetSelectedEnemy(Enemy enemy){
        EnemyManager.enemyManager.SetSelectedEnemy(enemy);
        Transform enemyTransform = enemy.gameObject.transform;
        selectTargetEnemy.transform.position = new Vector2(enemyTransform.position.x, enemyTransform.position.y + 1.0f);
    }
}
