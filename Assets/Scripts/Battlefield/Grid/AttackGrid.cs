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
            PlantUIManager.plantUIManager.DisablePlantInfoPanel();
            PlantUIManager.plantUIManager.EnableContentPanel(this);
        } else {
            PlantUIManager.plantUIManager.DisableContentPanel();
            PlantUIManager.plantUIManager.EnablePlantInfoPanel(this);
        }
    }

    public PlantSO ReturnPlantSO() {
        return plant;
    }

    public void SetPlant(PlantSO plant) {
        this.plant = plant;
    }

    public void RemovePlant() {
        this.plant = null;
        Destroy(transform.GetChild(0).gameObject);
    }
}
