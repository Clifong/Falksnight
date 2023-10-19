using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeManager : MonoBehaviour
{
    public static GaugeManager gaugeManager;
    public EnergyGauge energyGauge;

    void Start(){
        if (gaugeManager != null){
            Destroy(gaugeManager);
        }
        gaugeManager = this;
    }
    
    public void IncreaseGauge(int value){
        energyGauge.IncreaseGauge(value);
    }
}
