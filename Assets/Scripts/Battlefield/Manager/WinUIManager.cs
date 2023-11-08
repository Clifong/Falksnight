using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUIManager : MonoBehaviour
{
    public static WinUIManager winUIManager;
    public Canvas winUICanvas;

    void Awake()
    {
        winUICanvas.enabled = false;
        if (winUIManager != null){
            Destroy(winUIManager);
        }
        winUIManager = this;
    }

    public void ShowWinPanel() {
        winUICanvas.enabled = true;
    }
    
    public void ExitBattle() {
        LevelManager.WinBattle(this);
    }
}
