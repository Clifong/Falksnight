using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventWithParameters : UnityEvent<Component, object> {}
public class CrossObjecEventListenerWithData : MonoBehaviour
{
    public CrossObjectEventWithData gameEvent;
    public UnityEventWithParameters responseOnTrigger; 

    private void OnEnable() {
        gameEvent.AddListener(this);
    }

    private void OnDisable() {
        gameEvent.RemoveListener(this);
    }

    public virtual void TriggerEvent(Component sender, object data) {

        responseOnTrigger?.Invoke(sender, data);
    }
}
