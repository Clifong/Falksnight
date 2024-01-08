using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SingleObjectEvent : MonoBehaviour
{
    public List<UnityEvent> allSpecialEvent;
    private int index = 0;
    
    public void TriggerEvent() {
        allSpecialEvent[index]?.Invoke();
    }

    public void TriggerEventAndIncrementIndex() {
        TriggerEvent();
        IncrementIndex();
    }

    public void IncrementIndex() {
        index += 1;
        index = Mathf.Min(index, allSpecialEvent.Count - 1);
    }
}
