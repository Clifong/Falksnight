using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour{
    public static CharacterManager characterManager;
    [SerializeField]
    private Player currentPlayerSelected;
    [SerializeField]
    private Player previousPlayerSelected;
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
        GameObject MC = GameObject.FindWithTag("MC");
        TargetingManagerParty.targetingManagerParty.SetSelectedPlayer(MC.GetComponent<MC>());
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("PC"))
        {
            allPartyMembers.Add(player.GetComponent<Player>());
        }
        foreach (GameObject mc in GameObject.FindGameObjectsWithTag("MC"))
        {
            allPartyMembers.Add(mc.GetComponent<Player>());
        }
        totalNumberOfPartyMembers = allPartyMembers.Count;
    }

    public void SetSelectedPlayer(Player player){
        previousPlayerSelected = currentPlayerSelected;
        currentPlayerSelected = player;
    }

    public void IncrementAction(SkillsSO skillSO){
        this.currentPlayerSelected.SetAction(Actions.ATTACK);
        if (currentPlayerSelected != previousPlayerSelected){
            selectedAction += 1;
            selectedAction = Mathf.Min(selectedAction, totalNumberOfPartyMembers);
            previousPlayerSelected = currentPlayerSelected;
            this.currentPlayerSelected.SetSkillsToUse(skillSO, EnemyManager.enemyManager.GetSelectedEnemy());
            EnableAllPartyMembersToAct();
        }
        else{
            this.currentPlayerSelected.SetSkillsToUse(skillSO, EnemyManager.enemyManager.GetSelectedEnemy());
        }
    }

    public void IncrementAction(){
        this.currentPlayerSelected.SetAction(Actions.GUARD);
        if (currentPlayerSelected != previousPlayerSelected){
            selectedAction += 1;
            selectedAction = Mathf.Min(selectedAction, totalNumberOfPartyMembers);
            previousPlayerSelected = currentPlayerSelected;
            EnableAllPartyMembersToAct();
        }
    }

    public void EnableAllPartyMembersToAct(){
        if (selectedAction == totalNumberOfPartyMembers){
            AttackUIManager.attackUIManager.AllPartyMembersActionsSelected();
        }
    }

    public void DecreaseTotalNumberOfPartyMembers(){
        totalNumberOfPartyMembers -= 1;
    }

    public void AllPartyMembersAct(){
        AttackUIManager.attackUIManager.HidePlayerUIElements();
        selectedAction = 0;
        previousPlayerSelected = null;
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
        }
        else{
            TargetingManagerParty.targetingManagerParty.SetSelectedPlayer(allPartyMembers[0]);
            previousPlayerSelected = null;
        }
    }

    public bool EveryoneDead(){
        return allPartyMembers.Count == 0;
    }

    public Player returnAPlayer(){
        if (allPartyMembers.Count == 0){
            return null;
        }
        int randomInteger = Random.Range(0, totalNumberOfPartyMembers); 
        return allPartyMembers[randomInteger];
    }

    public List<Player> returnAllPlayers() {
        if (allPartyMembers.Count == 0){
            return null;
        }
        return allPartyMembers;
    }

}
