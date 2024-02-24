using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected EnemySO enemySO;
    protected Animator anime; 
    protected int currentHealth;
    protected int currentAttack;
    protected int currentDefence;
    protected int currentCritRate;
    protected int currentCritDamage;
    protected int enemyExp;
    protected EnemyUICanvas enemyUICanvas;
    public CrossObjectEventWithData spawnDamageText;
    public CrossObjectEventWithData attackPlayer;
    public CrossObjectEventWithData attackAllPlayers;
    public CrossObjectEventWithData enemyDied;
    public CrossObjectEventWithData changeSkillText;
    public CrossObjectEventWithData selectThisEnemy;

    // Start is called before the first frame update
    protected virtual void Initialise()
    {
        anime = GetComponent<Animator>();
        currentHealth = enemySO.baseHealth;
        currentAttack = enemySO.baseAttack;
        currentDefence = enemySO.baseDefence;
        currentCritRate = enemySO.baseCritRate;
        currentCritDamage = enemySO.baseCritDamage;
        enemyExp = enemySO.CalculateExp();
        enemyUICanvas = GetComponentInChildren<EnemyUICanvas>();
    }

    public EnemySO GetEnemSO(){
        return enemySO;
    }

    public float GetCurrentHealthRatio(){
        return (float)currentHealth/(float)enemySO.baseHealth;
    }

    public virtual void OnMouseDown(){
        selectThisEnemy.TriggerEvent(this, this);
    } 

    //Want to add flexibility to attack style
    public virtual void Attack(){
        int randomInteger = Random.Range(0, enemySO.skillSet.Count); 
        if (enemySO.skillSet[randomInteger].allEnemy) {
            attackAllPlayers.TriggerEvent(this, this, enemySO.skillSet[randomInteger].attack + currentAttack, enemySO.skillSet[randomInteger].name);
        }
        else {
            attackPlayer.TriggerEvent(this, this, enemySO.skillSet[randomInteger].attack + currentAttack, enemySO.skillSet[randomInteger].name);
        }
        changeSkillText.TriggerEvent(this, enemySO.skillSet[randomInteger].name);
    }

    public virtual void GetDamaged(int damage, bool critOrNot, Player player){
        currentHealth -= damage;
        if (currentHealth <= 0){
            Die(player.GetPlayerSO());
        }
        spawnDamageText.TriggerEvent(this, gameObject.transform.position, damage, critOrNot);
    }

    protected virtual void Die(PlayerSO playerSO){
        enemyDied.TriggerEvent(this, this);
        RewardsManager.rewardsManager.AddTempItem(enemySO.itemDrop);
        RewardsManager.rewardsManager.AddMoney(enemySO.returnRandomMoney());
        RewardsManager.rewardsManager.AddExp(playerSO, enemyExp);
        // anime.SetBool("die", true);
        Destroy(gameObject);
    }
}
