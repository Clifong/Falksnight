using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantBoxIcon : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    private PlantSO plantSO;
    private EnergyGauge eneryGauge;
    private AttackGrid gridBox;

    private void Start() {
        eneryGauge = GameObject.Find("Gauge").GetComponent<EnergyGauge>();
    }

    public void GrowPlant() {
        if (eneryGauge.getCurrentEnergy() >= plantSO.cost) {
            eneryGauge.IncreaseGauge(-plantSO.cost);
            gridBox.SetPlant(plantSO);
            Instantiate(plantSO.plantGameObject, gridBox.transform);
            PlantUIManager.plantUIManager.DisableContentPanel();
        }
    }

    public void SetData(PlantSO plantSO, AttackGrid grid) {
        gridBox = grid;
        this.plantSO = plantSO;
        this.nameText.text = plantSO.name;
        this.costText.text = plantSO.cost.ToString();
    }
}
