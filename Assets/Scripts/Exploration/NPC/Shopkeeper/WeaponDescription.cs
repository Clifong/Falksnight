using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponDescription : MonoBehaviour
{
    public Image weaponImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI healthBoostText;
    public TextMeshProUGUI attackBoostText;
    public TextMeshProUGUI defenceBoostText;
    public TextMeshProUGUI critRateBoostText;
    public TextMeshProUGUI critDamageBoostText;

    public void SetUIInfo(Component component, object data) {
        WeaponSO weaponSO = (WeaponSO)((object[]) data)[0];
        weaponImage.sprite = weaponSO.weaponImage;
        nameText.text = weaponSO.name;
        costText.text = weaponSO.cost.ToString();
        descriptionText.text = weaponSO.description;
        healthBoostText.text = "+" + weaponSO.healthBoost.ToString();
        attackBoostText.text = "+" + weaponSO.attackBoost.ToString();
        defenceBoostText.text = "+" + weaponSO.defenceBoost.ToString();
        critRateBoostText.text = "+" + weaponSO.critRateBoost.ToString() + "%";
        critDamageBoostText.text = "+" + weaponSO.critDamageBoost.ToString() + "%";
    }
}
