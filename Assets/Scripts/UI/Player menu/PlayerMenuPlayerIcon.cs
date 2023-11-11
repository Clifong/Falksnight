using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuPlayerIcon : MonoBehaviour
{
    private PlayerSO playerSO;
    
    public void SetPlayerSO(PlayerSO playerSO) {
        this.playerSO = playerSO;
    }

    public void SetPlayerStats() {
        Debug.Log(playerSO);
        PlayerMenuManager.playerMenuManager.SetPlayerStats(playerSO);
    }
}
