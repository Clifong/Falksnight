using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfidantIcon : MonoBehaviour
{
    private PlayerSO playerSO;
    
    public void SetPlayerSO(PlayerSO playerSO) {
        this.playerSO = playerSO;
    }

    public void SetConfidantInfo() {
        ConfidantUIManager.confidantUIManager.SetConfidantInfo(playerSO);
    }
}
