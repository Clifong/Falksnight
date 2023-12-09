using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenConfidant : MonoBehaviour
{
    private void OnOpenConfidant(){
        if (PlayerAttackDisabler.playerAttackDisabler != null) {
            PlayerAttackDisabler.playerAttackDisabler.ChangeEnable();
        }
        PlayerMovementDisabler.playerMovementDisabler.ChangeEnable();
        ConfidantUIManager.confidantUIManager.EnableOrDisableCanvas();
    }

    public void OpenConfidant(){
        OnOpenConfidant();
    }
}
