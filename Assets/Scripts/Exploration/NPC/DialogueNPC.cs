using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    [SerializeField]
    private List<TextAsset> dialogueTextList;
    [SerializeField]
    private string name;
    private NPC npc;
    private int index = 0;

    void Start() {
        npc = GetComponent<NPC>();
    }

    public void PlayDialogue() {
        DialogueManager.dialogueManager.StartDialogue(dialogueTextList[index], name);
    }

    public void PlayDialogueAndIncrementIndex() {
        PlayDialogue();
        IncrementIndex();
    }

    public void IncrementIndex() {
        index += 1;
        index = Mathf.Min(index, dialogueTextList.Count - 1);
    }

}
