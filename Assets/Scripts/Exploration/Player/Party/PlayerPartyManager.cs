using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartyManager : MonoBehaviour
{
    public static PlayerPartyManager playerPartyManager;
    private static int counter = 0;
    [SerializeField]
    private List<PlayerSO> activeParty = new List<PlayerSO>();
    [SerializeField]
    private List<PlayerSO> reserveParty = new List<PlayerSO>();
    [SerializeField]
    private List<PlayerSO> allParty = new List<PlayerSO>();

    void Start()
    {
        if (PlayerPartyManager.counter >= 1){
            Destroy(this.gameObject);
        }
        playerPartyManager = this;
        PlayerPartyManager.counter += 1;
        if (PlayerPartyManager.counter == 10){
            PlayerPartyManager.counter = 1;
        }
        foreach (PlayerSO active in activeParty)
        {
            allParty.Add(active);
        }
        foreach (PlayerSO reserve in reserveParty)
        {
            allParty.Add(reserve);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ModifyPartySetup(List<PlayerSO> activeParty, List<PlayerSO> reserveParty) {
        this.activeParty = activeParty;
        this.reserveParty = reserveParty;
    }

    public List<PlayerSO> ReturnPartyMembers(){
        return activeParty;
    }

    public List<PlayerSO> ReturnAllPartyMembers() {
        return allParty;
    }

    public void SendPartyMembersDataToUI(){
        PartySetupUIManager.partySetupUIManager.InstantiatePartyIcon(activeParty, reserveParty);
    }
}
