using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSwitchWeaponUIManager : MonoBehaviour
{
    public static PlayerSwitchWeaponUIManager playerSwitchWeaponUIManager;
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
    public Button changeWeaponButton;
    private WeaponSO referencedWeapon;
    void Start()
    {
        if (playerSwitchWeaponUIManager != null){
            Destroy(this.gameObject);
        }
        playerSwitchWeaponUIManager = this;
    }

    public void InstantiateImage(List<WeaponSO> equipments){
        foreach (GameObject equipment in currentlyInstantiatedImages)
        {
            Destroy(equipment);
        }
        foreach (WeaponSO equipment in equipments)
        {
            GameObject instantiatedGrid = Instantiate(equipment.weaponInSphereGrid, panel);
            instantiatedGrid.GetComponent<WeaponIcon>().SetReference(instantiatedGrid);
            currentlyInstantiatedImages.Add(instantiatedGrid);
        }
    }

    public void SetData(WeaponSO equipmentData){
        changeWeaponButton.gameObject.SetActive(true);
        referencedWeapon = equipmentData;
        equipmentImage.sprite = equipmentData.weaponImage;
        name.text = equipmentData.name;
        description.text = equipmentData.description;
        healthBoostText.text = "+" + equipmentData.healthBoost.ToString();
        attackBoostText.text = "+" + equipmentData.attackBoost.ToString();
        defenceBoostText.text = "+" + equipmentData.defenceBoost.ToString();
        critRateBoostText.text = "+" + equipmentData.critRateBoost.ToString() + "%";
        critDamageBoostText.text = "+" + equipmentData.critDamageBoost.ToString() + "%";
    }

    public void SwitchWeapon() {
        PlayerMenuManager.playerMenuManager.SwitchPlayerWeapon(referencedWeapon);
    }
}
