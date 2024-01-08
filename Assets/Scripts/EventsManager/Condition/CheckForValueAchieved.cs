using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CheckForValueAchieved", menuName = "Conditions/CheckForValueAchieved", order = 1)]
public class CheckForValueAchieved : Conditions
{
    [SerializeField]
    private int count = 0;
    public int valueToHit;

    public override bool CheckCondition() {
        return count == valueToHit;
    }

    public void IncrementCount() {
        count += 1;
    }
}
