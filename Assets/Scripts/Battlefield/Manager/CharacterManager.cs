using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour{
    public static CharacterManager characterManager;
    [SerializeField]
    private Player currentPlayerSelected;
    [SerializeField]
    private int selectedAction = 0;
    [SerializeField]
    private int totalNumberOfPartyMembers;
    private List<Player> allPartyMembers = new List<Player>();

    // Start is called before the first frame update
    void Awake(){
        if (characterManager != null){
            Destroy(characterManager);
        }    
        characterManager = this;
    }

    public void PlayerInstantiationComplete(){
        bool haveMC = false;
        bool havePC = false;
        Player pcPlayer = null;
        Player mcPlayer = null;
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("PC"))
        {
            havePC = true;
            pcPlayer = player.GetComponent<Player>();
            allPartyMembers.Add(pcPlayer);
        }
        foreach (GameObject mc in GameObject.FindGameObjectsWithTag("MC"))
        {
            haveMC = true;
            mcPlayer = mc.GetComponent<Player>();
            allPartyMembers.Add(mcPlayer);
        }
        if (haveMC) {
            TargetingManagerParty.targetingManagerParty.SetSelectedPlayer(mcPlayer);
        } else {
            TargetingManagerParty.targetingManagerParty.SetSelectedPlayer(pcPlayer);
        }
        totalNumberOfPartyMembers = allPartyMembers.Count;
    }

    public void SetSelectedPlayer(Player player){
        currentPlayerSelected = player;
    }

    public void Attack(SkillsSO skillSO, SkillIcon skillIcon){
        this.currentPlayerSelected.SetSkillsToUse(skillSO, EnemyManager.enemyManager.GetSelectedEnemy(), skillIcon);
        this.currentPlayerSelected.SetAction(Actions.ATTACK);
        EnableAllPartyMembersToAct();
    }

    public void Guard(){
        this.currentPlayerSelected.SetAction(Actions.GUARD);
        EnableAllPartyMembersToAct();
    }

    public void EnableAllPartyMembersToAct(){
        bool isReady = true;
        foreach (Player player in allPartyMembers)
        {
            if (player.IsIdle()) {
                isReady = false;
            } 
        }
        if (isReady) {
            AttackUIManager.attackUIManager.AllPartyMembersActionsSelected();
        }
    }

    public void DecreaseTotalNumberOfPartyMembers(){
        totalNumberOfPartyMembers -= 1;
    }

    public void AllPartyMembersAct(){
        AttackUIManager.attackUIManager.HidePlayerUIElements();
        selectedAction = 0;
        StartCoroutine(WaitForAMoment());
    }

    private IEnumerator WaitForAMoment(){
        foreach (Player player in allPartyMembers)
        {
            player.Act();
            yield return new WaitForSeconds(1);
        }
        if (!EnemyManager.enemyManager.EveryoneDead()){
            TurnManager.turnManager.ChangeTurn();
            EnemyManager.enemyManager.AllEnemiesAttack();
            StopAllCoroutines();
        }
    }

    public void UpdateList(Player player){
        allPartyMembers.Remove(player);
        totalNumberOfPartyMembers = allPartyMembers.Count;
        if (totalNumberOfPartyMembers == 0){
            LevelManager.LoadLevel(this, "Lose");
        }
        else{
            TargetingManagerParty.targetingManagerParty.SetSelectedPlayer(allPartyMembers[0]);
        }
    }

    public bool EveryoneDead(){
        return allPartyMembers.Count == 0;
    }

    public Player ReturnAPlayer(){
        if (allPartyMembers.Count == 0){
            return null;
        }
        int randomInteger = Random.Range(0, totalNumberOfPartyMembers); 
        return allPartyMembers[randomInteger];
    }

    public List<Player> ReturnAllPlayers() {
        if (allPartyMembers.Count == 0){
            return null;
        }
        return allPartyMembers;
    }

}
