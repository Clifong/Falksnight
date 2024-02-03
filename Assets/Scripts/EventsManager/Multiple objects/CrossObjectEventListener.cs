using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrossObjectEventListener : MonoBehaviour
{
    public CrossObjectEvent gameEvent;
    public UnityEvent responseOnTrigger;

    private void OnEnable() {
        gameEvent.AddListener(this);
    }

    private void OnDisable() {
        gameEvent.RemoveListener(this);
    }

    public virtual void TriggerEvent() {
        responseOnTrigger?.Invoke();
    }
}
