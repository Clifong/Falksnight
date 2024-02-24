using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private bool allDead;
    private List<Enemy> allEnemies = new List<Enemy>();
    public CrossObjectEvent allEnemiesDied;
    public CrossObjectEvent winBattle;
    public CrossObjectEvent hideText;
    public CrossObjectEventWithData getAllEnemies;

    public void EnemyInstantiationComplete(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemies[0].GetComponent<Enemy>().OnMouseDown();
        foreach (GameObject enemy in enemies)
        {
            allEnemies.Add(enemy.GetComponent<Enemy>());
        }
        allEnemies[0].OnMouseDown();
    }

    public void DamageAEnemy(Component component, object data ) {
        object[] temp = (object[]) data;
        int damage = (int) temp[0];
        bool critOrNot = (bool) temp[1];
        Player player = (Player) temp[2];
        Enemy enemy = (Enemy) temp[3];
        enemy.GetDamaged(damage, critOrNot, player);
    }

    public void DamageAllEnemies(Component component, object data) {
        object[] temp = (object[]) data;
        int damage = (int) temp[0];
        bool critOrNot = (bool) temp[1];
        Player player = (Player) temp[2];
        List<Enemy> copiedEnemies = new List<Enemy>(allEnemies);
        foreach (Enemy enemy in copiedEnemies)
        {   
            if (enemy != null) {
                enemy.GetDamaged(damage, critOrNot, player);
            }
        }
    }

    public void ReturnAllEnemies() {
        getAllEnemies.TriggerEvent(this, allEnemies);
    }

    public void AllEnemiesAttack(){
        StartCoroutine(WaitForAMoment());
    }

    public void UpdateList(Component component, object data){
        object[] temp = (object[]) data;
        Enemy enemy = (Enemy) temp[0];
        allEnemies.Remove(enemy);
        if (allEnemies.Count == 0){
            allEnemiesDied.TriggerEvent();
            EnemyPartyManager.enemyPartyManager.SetEnemyDead();
            StartCoroutine(WaitForAMomentWin());
        }
        else{
            allEnemies[0].OnMouseDown();
        }
    }

    private IEnumerator WaitForAMomentWin(){
        yield return new WaitForSeconds(1);
        winBattle.TriggerEvent();
    }

    private IEnumerator WaitForAMoment(){
        foreach (Enemy enemy in allEnemies)
        {
            enemy.Attack();
            yield return new WaitForSeconds(1);
        }
        hideText.TriggerEvent();
        TurnManager.turnManager.ChangeTurn();
        StopAllCoroutines();
    }
}
