using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager enemyManager;
    private Enemy enemy;
    private bool allDead;
    private List<Enemy> allEnemies = new List<Enemy>();
    // Start is called before the first frame update
    void Awake()
    {
        if (enemyManager != null){
            Destroy(enemyManager);
        }
        enemyManager = this;
    }

    public void EnemyInstantiationComplete(){
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        TargetingManagerEnemy.targetingManagerEnemy.SetSelectedEnemy(Enemies[0].GetComponent<Enemy>());
        foreach (GameObject enemy in Enemies)
        {
            allEnemies.Add(enemy.GetComponent<Enemy>());
        }
    }

    public void SetSelectedEnemy(Enemy enemy){
        this.enemy = enemy;
    }

    public Enemy GetSelectedEnemy(){
        return this.enemy;
    }

    public void AllEnemiesAttack(){
        StartCoroutine(WaitForAMoment());
    }

    public void UpdateList(Enemy enemy){
        allEnemies.Remove(enemy);
        if (allEnemies.Count == 0){
            EnemyPartyManager.enemyPartyManager.SetEnemyDead();
            LevelManager.WinBattle(this);
        }
        else{
            TargetingManagerEnemy.targetingManagerEnemy.SetSelectedEnemy(allEnemies[0]);
        }
    }

    private IEnumerator WaitForAMoment(){
        foreach (Enemy enemy in allEnemies)
        {
            enemy.Attack();
            yield return new WaitForSeconds(1);
        }
        if (!CharacterManager.characterManager.EveryoneDead()){
            SkillTextboxManager.skillTextboxManager.HideText();
            TurnManager.turnManager.ChangeTurn();
            AttackUIManager.attackUIManager.ShowPlayerUIElements();
            StopAllCoroutines();
        }
    }

    public bool EveryoneDead(){
        return allEnemies.Count == 0;
    }
}
