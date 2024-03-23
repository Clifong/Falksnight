using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player party SO", menuName = "Player party SO", order = 1)]
public class PlayerPartySO : ScriptableObject {
    public List<PlayerSO> activeParty = new List<PlayerSO>();
    public List<PlayerSO> reserveParty = new List<PlayerSO>();
    public List<PlayerSO> allParty = new List<PlayerSO>();

    public List<PlayerSO> ReturnPartyMembers(){
        return activeParty;
    }

    public List<PlayerSO> ReturnAllPartyMembers() {
        return allParty;
    }

    public void ModifyPartySetup(List<PlayerSO> activeParty, List<PlayerSO> reserveParty) {
        this.activeParty = activeParty;
        this.reserveParty = reserveParty;
    }
}
