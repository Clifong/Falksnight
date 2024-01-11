using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObjects : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject interactCanvas;
    public UnityEvent interactionEvent;

    public void Interact() {
        interactionEvent?.Invoke();
    }

    public void ShowInteractCanvas() {
        if (interactCanvas != null) {
            interactCanvas.SetActive(true);
        }
        
    }

    public void HideInteractCanvas() {
        if (interactCanvas != null) {
            interactCanvas.SetActive(false);
        }
    }
}
