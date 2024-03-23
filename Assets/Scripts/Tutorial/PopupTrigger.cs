using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTrigger : MonoBehaviour
{
    public CrossObjectEvent interactingWithTriggerEvent;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "MC") {
            interactingWithTriggerEvent.TriggerEvent();
            Destroy(this.gameObject);
        }
    }
}
