using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public void PartyMembersAttack(){
        CharacterManager.characterManager.AllPartyMembersAct();
    }
}
