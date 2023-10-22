using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantUIManager : MonoBehaviour
{
    public static PlantUIManager plantUIManager;
    // private Player playerSelected;
    public GameObject plantBoxIcon;
    public GameObject UIPanel;
    public PlantInfoUI plantInfoUIScript;

    
    [SerializeField]
    private Transform contentTransform;
    private List<GameObject> spawnedplantBoxIcon = new List<GameObject>();

    void Awake()
    {
        if (plantUIManager != null){
            Destroy(plantUIManager);
        }
        plantUIManager = this;
    }

    public void DisableContentPanel() {
        UIPanel.SetActive(false);
    }

    public void DisablePlantInfoPanel() {
        plantInfoUIScript.DisablePlantInfoPanel();
    }

    public void EnableContentPanel(AttackGrid attackGrid) {
        foreach (GameObject icon in spawnedplantBoxIcon)
        {
            Destroy(icon);
        }
        UIPanel.SetActive(true);
        List<PlantSO> allPlantSO = PlantCollectionManager.plantCollectionManager.ReturnAllPlantSO();
        foreach (PlantSO plantSO in allPlantSO) {
            GameObject instantiatedPlantBoxIcon = Instantiate(plantBoxIcon, contentTransform);
            instantiatedPlantBoxIcon.GetComponent<PlantBoxIcon>().SetData(plantSO, attackGrid);
            spawnedplantBoxIcon.Add(instantiatedPlantBoxIcon);
        }
    }

    public void EnablePlantInfoPanel(AttackGrid attackGrid) {
        plantInfoUIScript.SetData(attackGrid);
    }
}
