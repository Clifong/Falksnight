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
            List<Player> allPlayer = CharacterManager.characterManager.returnAllPlayers();
            foreach (Player player in allPlayer.ToArray())
            {
                if (player != null){
                    SkillTextboxManager.skillTextboxManager.ChangeText(enemySO.skillSet[randomInteger].name);
                    player.GetDamaged(enemySO.skillSet[randomInteger].attack + currentAttack);
                }
            }
        }
        else {
            Player attackPlayer = CharacterManager.characterManager.returnAPlayer();
            if (attackPlayer != null){
                SkillTextboxManager.skillTextboxManager.ChangeText(enemySO.skillSet[randomInteger].name);
                attackPlayer.GetDamaged(enemySO.skillSet[randomInteger].attack + currentAttack);
            }
        }
    }

    public virtual void GetDamaged(int damage){
        currentHealth -= damage;
        if (currentHealth <= 0){
            Die();
        }
        AttackUIManager.attackUIManager.InstantiateDamageText(gameObject.transform.position, damage);
    }

    protected virtual void Die(){
        EnemyManager.enemyManager.UpdateList(this);
        // anime.SetBool("die", true);
        Destroy(gameObject);
    }
}
