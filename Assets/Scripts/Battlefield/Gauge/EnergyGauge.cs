using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyGauge : MonoBehaviour
{
    private Slider gaugeSlider;
    [SerializeField]
    private int maxEnergy;
    [SerializeField]
    private int currentEnergy;
    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = 0;
        gaugeSlider = GetComponent<Slider>();
        gaugeSlider.value = 0;
    }

    public void IncreaseGauge(int value){
        currentEnergy += value;
        gaugeSlider.value = (float)currentEnergy/(float)maxEnergy;
    }
}
