using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerEquipmentManager : MonoBehaviour
{
    public static PlayerEquipmentManager playerEquipmentManager;
    public TextMeshProUGUI healthBoostText;
    public TextMeshProUGUI attackBoostText;
    public TextMeshProUGUI defenceBoostText;
    public TextMeshProUGUI critRateBoostText;
    public TextMeshProUGUI critDamageBoostText;
    public TextMeshProUGUI name;
    public Image imageIcon;
    // Start is called before the first frame update
    void Start()
    {
        if (playerEquipmentManager != null){
            Destroy(this.gameObject);
        }
        playerEquipmentManager = this;
    }

    public void SetWeaponStats(WeaponSO weaponSO) {
        imageIcon.sprite = weaponSO.weaponImage;
        name.text = weaponSO.name;
        healthBoostText.text = "+" + weaponSO.healthBoost.ToString();
        attackBoostText.text = "+" + weaponSO.attackBoost.ToString();
        defenceBoostText.text = "+" + weaponSO.defenceBoost.ToString();
        critRateBoostText.text = "+" + weaponSO.critRateBoost.ToString() + "%";
        critDamageBoostText.text = "+" + weaponSO.critDamageBoost.ToString() + "%";
    }
}
