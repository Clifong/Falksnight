using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenParty : MonoBehaviour
{
    private void OnOpenParty(){
        PlayerAttackDisabler.playerAttackDisabler.ChangeEnable();
        PlayerPartyManager.playerPartyManager.SendPartyMembersDataToUI();
    }

    public void OpenParty(){
        OnOpenParty();
    }
}
