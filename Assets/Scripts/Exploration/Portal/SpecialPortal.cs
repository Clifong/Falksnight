using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPortal : MonoBehaviour, IInteractable
{
    public string nextLevel;
    [SerializeField]
    private GameObject interactCanvas;

    public void ShowInteractCanvas() {
        interactCanvas.SetActive(true);
    }

    public void HideInteractCanvas() {
        interactCanvas.SetActive(false);
    }

    public void Interact() {
        LevelManager.LoadLevel(this, nextLevel);
    }
}
