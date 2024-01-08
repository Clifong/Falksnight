using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CheckForActivation", menuName = "Conditions/CheckForActivation", order = 1)]
public class CheckForActivation : Conditions
{
    private bool someCondition;

    public override bool CheckCondition() {
        return someCondition;
    }
}
