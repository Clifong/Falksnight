using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CrossObjectEventWithData", menuName = "Cross object events with data", order = 1)]
public class CrossObjectEventWithData : ScriptableObject
{
    [SerializeField]
    private List<CrossObjecEventListenerWithData> listeners = new List<CrossObjecEventListenerWithData>();

    public void TriggerEvent(Component sender, object data) {
        foreach (CrossObjecEventListenerWithData listener in listeners)
        {
            listener.TriggerEvent(sender, data);
        }
    }

    public void AddListener(CrossObjecEventListenerWithData listener) {
        listeners.Add(listener);
    }

    public void RemoveListener(CrossObjecEventListenerWithData listener) {
        listeners.Remove(listener);
    }
}
