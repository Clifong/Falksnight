using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackGrid : MonoBehaviour
{
    [SerializeField]
    private PlantSO plant;

    private void OnMouseDown(){
        if (plant == null) {
            PlantUIManager.plantUIManager.EnableContentPanel(this);
        } else {
            PlantUIManager.plantUIManager.EnablePlantGrowthPanel();
        }
    }

    public void SetPlant(PlantSO plant) {
        this.plant = plant;
    }
}
