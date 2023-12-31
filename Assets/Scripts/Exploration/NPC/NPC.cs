using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject interactCanvas;
    [SerializeField]
    private TextAsset dialogueText;
    [SerializeField]
    private string name;

    public virtual void Interact() {
        DialogueManager.dialogueManager.StartDialogue(this, dialogueText, name);
    }

    public abstract void EndDialogueEvent();

    public virtual void ShowInteractCanvas() {
        interactCanvas.SetActive(true);
    }

    public virtual void HideInteractCanvas() {
        interactCanvas.SetActive(false);
    }
}
