using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingManagerEnemy : MonoBehaviour
{
    public GameObject selectTargetEnemy;

    public void SetSelectedEnemy(Component component, object data){
        object[] temp = (object[]) data;
        Enemy enemy = (Enemy) temp[0];
        Transform enemyTransform = enemy.gameObject.transform;
        selectTargetEnemy.transform.position = new Vector2(enemyTransform.position.x, enemyTransform.position.y + 1.0f);
    }
}
