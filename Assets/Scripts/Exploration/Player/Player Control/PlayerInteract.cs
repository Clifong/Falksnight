using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable interactable;
    private void OnTriggerEnter2D(Collider2D other){
        this.interactable = other.GetComponent<IInteractable>();
        if (this.interactable != null) {
            this.interactable.ShowInteractCanvas();
        }
    }

    private void OnTriggerExit2D(Collider2D other){
       if (this.interactable != null) {
        this.interactable.HideInteractCanvas();
        this.interactable = null;
       }
    }

    public void OnInteract() {
        if (interactable != null) {
            interactable.Interact();
        }
    }
}
