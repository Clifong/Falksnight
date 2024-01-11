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
        TargetingManagerEnemy.targetingManagerEnemy.SetSelectedEnemy(this);
    } 

    //Want to add flexibility to attack style
    public virtual void Attack(){
        int randomInteger = Random.Range(0, enemySO.skillSet.Count); 
        if (enemySO.skillSet[randomInteger].allEnemy) {
            List<Player> allPlayer = CharacterManager.characterManager.ReturnAllPlayers();
            foreach (Player player in allPlayer.ToArray())
            {
                if (player != null){
                    SkillTextboxManager.skillTextboxManager.ChangeText(enemySO.skillSet[randomInteger].name);
                    player.GetDamaged(enemySO.skillSet[randomInteger].attack + currentAttack);
                }
            }
        }
        else {
            Player attackPlayer = CharacterManager.characterManager.ReturnAPlayer();
            if (attackPlayer != null){
                SkillTextboxManager.skillTextboxManager.ChangeText(enemySO.skillSet[randomInteger].name);
                attackPlayer.GetDamaged(enemySO.skillSet[randomInteger].attack + currentAttack);
            }
        }
    }

    public virtual void GetDamaged(int damage, bool critOrNot, Player player){
        currentHealth -= damage;
        if (currentHealth <= 0){
            Die(player.GetPlayerSO());
        }
        AttackUIManager.attackUIManager.InstantiateDamageText(gameObject.transform.position, damage, critOrNot);
    }

    protected virtual void Die(PlayerSO playerSO){
        EnemyManager.enemyManager.UpdateList(this);
        RewardsManager.rewardsManager.AddTempItem(enemySO.itemDrop);
        RewardsManager.rewardsManager.AddMoney(enemySO.returnRandomMoney());
        RewardsManager.rewardsManager.AddExp(playerSO, enemyExp);
        // anime.SetBool("die", true);
        Destroy(gameObject);
    }
}
