using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationHelper : MonoBehaviour
{
    public UnityEvent invokeEvent;

    public void InvokeEvent() {
        invokeEvent?.Invoke();
    }
}
