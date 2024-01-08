using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CrossObjectEventWithConditions", menuName = "Cross object events/With conditions", order = 1)]
public class CrossObjectEventWithConditions : CrossObjectEvent
{
    public Conditions conditions;

    public void TriggerEvent() {
        if (conditions.CheckCondition()) {
            foreach (CrossObjectEventListener listener in listeners)
            {
                listener.TriggerEvent();
            }
        }
    }
}
