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
    private SkillIcon skillIcon;
    public CrossObjectEventWithData playerDie;
    public CrossObjectEventWithData selectThisPlayer;
    public CrossObjectEventWithData spawnDamageText;
    public CrossObjectEventWithData changeSkillText;
    public CrossObjectEventWithData attackAEnemy;
    public CrossObjectEventWithData attackAllEnemies;
    public Enemy targetEnemy;

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
        spawnDamageText.TriggerEvent(this, gameObject.transform.position, trueDamage, false);
    }

    public float GetCurrentHealthRatio(){
        return (float)currentHealth/(float)playerSO.baseHealth;
    }

    public virtual void OnMouseDown(){
        selectThisPlayer.TriggerEvent(this, this);
    } 

    public virtual void SetSkillsToUse(SkillsSO skillsSO, SkillIcon newSkillIcon){
        this.skillsToUse = skillsSO;
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
            attackAllEnemies.TriggerEvent(this, attackDamage, critOrNot, this);
        }
        else {
            attackAEnemy.TriggerEvent(this, attackDamage, critOrNot, this, targetEnemy);
        }
        changeSkillText.TriggerEvent(this, skillsToUse.name);
    }

    protected virtual void Guard(){
        currentDefence *= 2;
    }

    protected virtual void Die(){
        // anime.SetBool("die", true);
        playerDie.TriggerEvent(this, this);
        Destroy(gameObject);
    }
}
