using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "MC") {
            TutorialManager.tutorialManager.ShowPopup();
            Destroy(this.gameObject);
        }
    }
}
