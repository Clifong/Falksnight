using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartyInstantiation : MonoBehaviour
{
    public List<Transform> playerPosition;
    public PlayerPartySO playerParty;
    public CrossObjectEvent allPlayersSpawned;

    private void Start(){
        for (int i = 0; i < playerParty.activeParty.Count; i++)
        {
            Instantiate(playerParty.activeParty[i].playerGameObject, playerPosition[i].position, Quaternion.identity);
        }
        Debug.Log("PLAYERS");
        allPlayersSpawned.TriggerEvent();
    }
}
