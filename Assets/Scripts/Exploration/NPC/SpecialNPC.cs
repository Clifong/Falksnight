using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialNPC : NPC
{
    public UnityEvent endDialogueEvent;
    public override void EndDialogueEvent() {
        endDialogueEvent?.Invoke();
    }
}
