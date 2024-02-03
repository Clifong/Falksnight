using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CounterListenerForCrossObjectEvent : CrossObjectEventListener {
    private int internalCounter = 0;
    private int totalCounter;
    public UnityEvent counterReached;
    public MonoBehaviour script;

    private void Start() {
        totalCounter = Object.FindObjectsOfType(script.GetType()).Length;
        Debug.Log(totalCounter);
    }

    public override void TriggerEvent() {
        internalCounter += 1;
        if (totalCounter == internalCounter) {
            counterReached?.Invoke();
        }
    }
}
