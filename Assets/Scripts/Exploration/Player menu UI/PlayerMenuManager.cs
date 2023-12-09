using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMenuManager : MonoBehaviour
{
    public static PlayerMenuManager playerMenuManager;
    public Transform contentView;
    public Canvas playerMenuUICanvas;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI critRateText;
    public TextMeshProUGUI critDamageText;
    public TextMeshProUGUI expNeededText;
    public TextMeshProUGUI levelText;
    public Slider expSlider;
    private PlayerSO currentPlayer;
    private List<GameObject> currentlyInstantiatedIcons = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (playerMenuManager != null){
            Destroy(this.gameObject);
        }
        playerMenuManager = this;
    }

    public void EnableOrDisableCanvas(){
        playerMenuUICanvas.enabled = !playerMenuUICanvas.enabled;
        foreach (GameObject icon in currentlyInstantiatedIcons)
        {
            Destroy(icon);
        }
        List<PlayerSO> allPartyMembers = PlayerPartyManager.playerPartyManager.ReturnAllPartyMembers();
        if (allPartyMembers.Count > 0) {
            SetPlayerStats(allPartyMembers[0]);
        }
        foreach (PlayerSO playerSO in allPartyMembers)
        {
            GameObject instantiatedPartyIcon = Instantiate(playerSO.partyIcon, contentView);
            instantiatedPartyIcon.GetComponent<PlayerMenuPlayerIcon>().SetPlayerSO(playerSO);
            currentlyInstantiatedIcons.Add(instantiatedPartyIcon);
        }
    }

    public void SetPlayerStats(PlayerSO playerSO) {
        currentPlayer = playerSO;
        playerSO.GeneralStatsTextInitialization(healthText, attackText, defenceText, critRateText, critDamageText);
        playerSO.LevelAndExpRequired(levelText, expNeededText);
        expSlider.value = playerSO.ReturnExpRatio();
        PlayerEquipmentManager.playerEquipmentManager.SetWeaponStats(playerSO.currWeapon);
    }

    public void SwitchPlayerWeapon(WeaponSO weaponSO) {
        PlayerEquipmentManager.playerEquipmentManager.SetWeaponStats(weaponSO);
        currentPlayer.SwitchWeapon(weaponSO);
    }
}
