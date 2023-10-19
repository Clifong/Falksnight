using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    [SerializeField] 
    private int minEnergyValue;
    [SerializeField] 
    private int maxEnergyValue;

    private void OnMouseDown(){
        int energyValue = Random.Range(minEnergyValue, maxEnergyValue);
        GaugeManager.gaugeManager.IncreaseGauge(energyValue);
        Destroy(this.gameObject);
    }
}
