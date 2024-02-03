using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    private DialogueNPC dialogueNPC;
    // public List<Conditions> conditions;
    public int index = 0;

    void Start() {
        dialogueNPC = GetComponent<DialogueNPC>();
    }   
}
    
