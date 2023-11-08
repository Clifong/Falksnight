using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBattleButton : MonoBehaviour
{
    public void ExitBattle() {
        LevelManager.WinBattle(this);
    }
}
