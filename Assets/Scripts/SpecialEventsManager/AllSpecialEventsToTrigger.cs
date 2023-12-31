using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllSpecialEventsToTrigger : MonoBehaviour
{
    public List<UnityEvent> allSpecialEvent;
    private int index = 0;
    
    public void TriggerEvent() {
        allSpecialEvent[index]?.Invoke();
        index += 1;
    }
}
