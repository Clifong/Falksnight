using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject interactCanvas;
    public void Interact() {
        Debug.Log("NPC");
    }

    public void ShowInteractCanvas() {
        interactCanvas.SetActive(true);
    }

    public void HideInteractCanvas() {
        interactCanvas.SetActive(false);
    }
}
