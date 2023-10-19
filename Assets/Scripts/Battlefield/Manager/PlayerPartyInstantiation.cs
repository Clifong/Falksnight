using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartyInstantiation : MonoBehaviour
{
    public List<Transform> playerPosition;
    private List<PlayerSO> playerParty;

    private void Start(){
        playerParty = PlayerPartyManager.playerPartyManager.returnPartyMembers();
        for (int i = 0; i < playerParty.Count; i++)
        {
            Instantiate(playerParty[i].playerGameObject, playerPosition[i].position, Quaternion.identity);
        }
        CharacterManager.characterManager.PlayerInstantiationComplete();
    }
}
