using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject interactCanvas;
    [SerializeField]
    private TextAsset dialogueText;
    [SerializeField]
    private string name;

    public void Interact() {
        DialogueManager.dialogueManager.StartDialogue(dialogueText, name);
    }

    public void ShowInteractCanvas() {
        interactCanvas.SetActive(true);
    }

    public void HideInteractCanvas() {
        interactCanvas.SetActive(false);
    }
}
