using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public void Close(){
        if (PlayerAttackDisabler.playerAttackDisabler != null) {
            PlayerAttackDisabler.playerAttackDisabler.ChangeEnable();
        }
        PlayerMovementDisabler.playerMovementDisabler.ChangeEnable();
    }
}
