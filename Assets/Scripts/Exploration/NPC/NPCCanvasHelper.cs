using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCCanvasHelper : MonoBehaviour, IInteractable
{
    public UnityEvent InteractEvent;

    [SerializeField]
    private GameObject interactCanvas;
    private bool trigger = true;
    
    public void Interact() {
        HideInteractCanvas();
        InteractEvent?.Invoke();
    }

    public void ShowInteractCanvas() {
        interactCanvas.SetActive(true);
    }

    public void HideInteractCanvas() {
        interactCanvas.SetActive(false);
    }
}
