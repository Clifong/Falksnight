using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquipmentUIManager : MonoBehaviour
{
    public static EquipmentUIManager equipmentUIManager;
    public Transform panel;
    public Image equipmentImage;
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public TextMeshProUGUI healthBoostText;
    public TextMeshProUGUI attackBoostText;
    public TextMeshProUGUI defenceBoostText;
    public TextMeshProUGUI critRateBoostText;
    public TextMeshProUGUI critDamageBoostText;
    private List<GameObject> currentlyInstantiatedImages = new List<GameObject>();
    void Start()
    {
        if (equipmentUIManager != null){
            Destroy(this.gameObject);
        }
        equipmentUIManager = this;
    }

    public void InstantiateImage(List<WeaponSO> equipments){
        foreach (GameObject equipment in currentlyInstantiatedImages)
        {
            Destroy(equipment);
        }
        foreach (WeaponSO equipment in equipments)
        {
            GameObject instantiatedGrid = Instantiate(equipment.equipmentInSphereGrid, panel);
            instantiatedGrid.GetComponent<WeaponIcon>().SetReference(instantiatedGrid);
            currentlyInstantiatedImages.Add(instantiatedGrid);
        }
    }

    public void SetData(WeaponSO equipmentData){
        equipmentImage.sprite = equipmentData.equipmentImage;
        name.text = equipmentData.name;
        description.text = equipmentData.description;
        healthBoostText.text = "+" + equipmentData.healthBoost.ToString();
        attackBoostText.text = "+" + equipmentData.attackBoost.ToString();
        defenceBoostText.text = "+" + equipmentData.defenceBoost.ToString();
        critRateBoostText.text = "+" + equipmentData.critRateBoost.ToString() + "%";
        critDamageBoostText.text = "+" + equipmentData.critDamageBoost.ToString() + "%";
    }
}
