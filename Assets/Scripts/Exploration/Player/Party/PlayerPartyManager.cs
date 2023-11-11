using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartyManager : MonoBehaviour
{
    public static PlayerPartyManager playerPartyManager;
    private static int counter = 0;
    [SerializeField]
    private List<PlayerSO> partyInfo = new List<PlayerSO>();

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
        DontDestroyOnLoad(this.gameObject);
    }

    public List<PlayerSO> ReturnPartyMembers(){
        return partyInfo;
    }

    public void SendPartyMembersDataToUI(){
        PartySetupUIManager.partySetupUIManager.InstantiateIcon(partyInfo);
    }
}
