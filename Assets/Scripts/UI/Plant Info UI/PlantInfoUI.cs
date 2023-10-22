using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantInfoUI : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    private AttackGrid attackGrid;

    public void SetData(AttackGrid attackGrid) {
        gameObject.SetActive(true);
        this.attackGrid = attackGrid;
        PlantSO plant = attackGrid.ReturnPlantSO();
        name.text = plant.name;
        description.text = plant.description;
    }

    public void DisablePlantInfoPanel() {
        gameObject.SetActive(false);
    }

    public void RemovePlant() {
        attackGrid.RemovePlant();
    }
    
}
