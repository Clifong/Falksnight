using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour{

    [SerializeField]
    private Player currentPlayerSelected;
    private Enemy currentEnemySelected;
    [SerializeField]
    private int selectedAction = 0;
    [SerializeField]
    private int totalNumberOfPartyMembers;
    private List<Player> allPartyMembers = new List<Player>();
    public CrossObjectEvent allPlayersReady;
    public CrossObjectEvent allPlayersDead;
    public CrossObjectEventWithData returnAllPlayer;

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
            mcPlayer.OnMouseDown();
        } else {
            pcPlayer.OnMouseDown();
        }
        totalNumberOfPartyMembers = allPartyMembers.Count;
    }

    public void SetSelectedPlayer(Component component, object data){
        object[] temp = (object[]) data;
        currentPlayerSelected = (Player) temp[0];
        currentPlayerSelected.targetEnemy = currentEnemySelected;
    }

    public void Attack(Component component, object data){
        object[] temp = (object[]) data;
        SkillsSO skillSO = (SkillsSO) temp[0];
        SkillIcon skillIcon = (SkillIcon) temp[1];
        this.currentPlayerSelected.SetSkillsToUse(skillSO, skillIcon);
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
            allPlayersReady.TriggerEvent();
        }
    }

    public void DecreaseTotalNumberOfPartyMembers(){
        totalNumberOfPartyMembers -= 1;
        if (totalNumberOfPartyMembers <= 0) {
            allPlayersDead.TriggerEvent();
        }
    }

    public void AllPartyMembersAct(){
        selectedAction = 0;
        StartCoroutine(WaitForAMoment());
    }

    private IEnumerator WaitForAMoment(){
        foreach (Player player in allPartyMembers)
        {
            player.Act();
            yield return new WaitForSeconds(1);
        }
        TurnManager.turnManager.ChangeTurn();
        StopAllCoroutines();
    }

    public void UpdateList(Component component, object data){
        object[] temp = (object[]) data;
        allPartyMembers.Remove((Player) temp[0]);
        totalNumberOfPartyMembers = allPartyMembers.Count;
        if (totalNumberOfPartyMembers == 0){
            LevelManager.LoadLevel(this, "Lose");
        }
        else{
            allPartyMembers[0].OnMouseDown();
        }
    }

    public void AttackAPlayer(Component component, object data) {
        object[] temp = (object[]) data;
        int randomInteger = Random.Range(0, totalNumberOfPartyMembers);
        int damage = (int) temp[1];
        allPartyMembers[randomInteger].GetDamaged(damage);
    }

    public void AttackAllPlayer(Component component, object data) {
        object[] temp = (object[]) data;
        int randomInteger = Random.Range(0, totalNumberOfPartyMembers);
        int damage = (int) temp[1];
        foreach (Player player in allPartyMembers)
        {
            player.GetDamaged(damage);
        }
    }

    public void ReturnAllPlayers() {
        if (allPartyMembers.Count == 0){
            returnAllPlayer.TriggerEvent(this, null);
            return;
        }
        returnAllPlayer.TriggerEvent(this, allPartyMembers);
    }

    public void SetTargetEnemy(Component component, object data ) {
        object[] temp = (object[]) data;
        currentEnemySelected = (Enemy) temp[0];
        currentPlayerSelected.targetEnemy = currentEnemySelected;
    }

}
