using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenPlayerMenu : MonoBehaviour
{
    private void OnOpenPlayerMenu(){
        PlayerAttackDisabler.playerAttackDisabler.ChangeEnable();
        PlayerMovementDisabler.playerMovementDisabler.ChangeEnable();
        PlayerMenuManager.playerMenuManager.EnableOrDisableCanvas();
    }

    public void OpenPlayerMenu(){
        OnOpenPlayerMenu();
    }
}
