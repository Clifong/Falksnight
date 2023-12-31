using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialEventsManager : MonoBehaviour
{
    public static SpecialEventsManager specialEventsManager;
    public List<UnityEvent> allEvents;
    private AllSpecialEventsToTrigger[] allSpecialGameObjects;

    void Start() {
        if (specialEventsManager != null) {
            Destroy(this);
        } else {
            specialEventsManager = this;
        }
        allSpecialGameObjects = (AllSpecialEventsToTrigger[]) FindObjectsOfType<AllSpecialEventsToTrigger>();
    }

    public void TriggerEvent() {
        foreach (AllSpecialEventsToTrigger specialGameObject in allSpecialGameObjects)
        {
            specialGameObject.TriggerEvent();
        }
    }
}
