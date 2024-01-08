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
        interactCanvas.SetActive(true);
    }

    public void HideInteractCanvas() {
        interactCanvas.SetActive(false);
    }
}
