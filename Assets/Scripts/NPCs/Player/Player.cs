using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Actions {
    ATTACK, 
    GUARD
    };
public abstract class Player: MonoBehaviour
{
    [SerializeField]
    protected PlayerSO playerSO;
    [SerializeField]
    protected Actions allPossibleActions;
    protected Animator anime; 
    protected int currentHealth;
    protected int currentAttack;
    protected int currentDefence;
    protected int currentCritRate;
    protected int currentCritDamage;
    protected SkillsSO skillsToUse;
    protected Enemy targetEnemy;

    // Start is called before the first frame update
    protected virtual void Initialise()
    {
        playerSO.Initialise();
        anime = GetComponent<Animator>();
        currentHealth = playerSO.currentHealthWithBuffs;
        currentAttack = playerSO.currentAttackWithBuffs;
        currentDefence = playerSO.currentDefenceWithBuffs;
        currentCritRate = playerSO.currentCritRateWithBuffs;
        currentCritDamage = playerSO.currentCritDamageWithBuffs;
    }

    private void Update(){
        playerSO.currentHealth = currentHealth;
    }

    public PlayerSO GetPlayerSO(){
        return playerSO;
    }

    public void SetAction(Actions action){
        allPossibleActions = action;
    }

    public virtual void GetDamaged(int damage){
        int trueDamage = Mathf.Max(1, (int)Mathf.Floor((float)(damage - (double)currentDefence * 0.5)));
        currentHealth -= trueDamage;
        if (currentHealth <= 0){
            Die();
        }
        AttackUIManager.attackUIManager.InstantiateDamageText(gameObject.transform.position, trueDamage, false);
    }

    public float GetCurrentHealthRatio(){
        return (float)currentHealth/(float)playerSO.baseHealth;
    }


    public virtual void OnMouseDown(){
        TargetingManagerParty.targetingManagerParty.SetSelectedPlayer(this);
    } 

    public virtual void SetSkillsToUse(SkillsSO skillsSO, Enemy enemy){
        this.skillsToUse = skillsSO;
        this.targetEnemy = enemy;
    }

    public virtual void Act(){
        switch (allPossibleActions)
        {
            case (Actions.ATTACK):
                Attack();
                break;
            case (Actions.GUARD):
                Guard();
                break;
        }
    }

    //Want to add flexibility to attack style
    protected virtual void Attack(){
        int attackDamage = skillsToUse.attack + currentAttack;
        bool critOrNot = false;

        if(Random.Range(1, 100) <= currentCritRate) {
            critOrNot = true;
            attackDamage = (int)Mathf.Floor(attackDamage * (100 + currentCritDamage)/100);
        }

        if (skillsToUse.allEnemy){
            List<Enemy> allEnemies = EnemyManager.enemyManager.ReturnAllEnemies();
            SkillTextboxManager.skillTextboxManager.ChangeText(skillsToUse.name);
            foreach (Enemy enemy in allEnemies.ToArray())
            {
                enemy.GetDamaged(attackDamage, critOrNot, this);
            }
        }
        else {
            if (targetEnemy != null){
                SkillTextboxManager.skillTextboxManager.ChangeText(skillsToUse.name);
                targetEnemy.GetDamaged(attackDamage, critOrNot, this);
            }
            else{
                currentAttack += skillsToUse.attack;
            }
        }
    }

    protected virtual void Guard(){
        currentDefence *= 2;
    }

    protected virtual void Die(){
        // anime.SetBool("die", true);
        CharacterManager.characterManager.UpdateList(this);
        Destroy(gameObject);
    }
}
