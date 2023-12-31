using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Actions {
    ATTACK, 
    GUARD,
    IDLE,
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
    private SkillIcon skillIcon;

    // Start is called before the first frame update
    protected virtual void Initialise()
    {
        allPossibleActions = Actions.IDLE;
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
        if (action == Actions.GUARD) {
            skillsToUse = null;
            if (skillIcon != null) {
                skillIcon.NotAttacking();
                skillIcon = null;
            }
        }
        allPossibleActions = action;
    }

    public bool IsIdle() {
        return allPossibleActions == Actions.IDLE;
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

    public virtual void SetSkillsToUse(SkillsSO skillsSO, Enemy enemy, SkillIcon newSkillIcon){
        this.skillsToUse = skillsSO;
        this.targetEnemy = enemy;
        if (skillIcon != null) {
            skillIcon.Switch();
            skillIcon = newSkillIcon;
            skillIcon.Switch();
        } else {
            skillIcon = newSkillIcon;
            skillIcon.Switch();
        }
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
        allPossibleActions = Actions.IDLE;
    }

    public void CheckIfThisSkillIsUsed(SkillsSO skillSO, SkillIcon skillIcon) {
        if (skillsToUse == skillSO) {
            skillIcon.Switch();
            this.skillIcon = skillIcon;
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
