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
        List<PlayerSO> allPartyMembers = PlayerPartyManager.playerPartyManager.ReturnPartyMembers();
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
        healthText.text = playerSO.currentHealth.ToString() + "/" + playerSO.baseHealth.ToString();
        attackText.text = playerSO.baseAttack.ToString();
        defenceText.text = playerSO.baseDefence.ToString();
        critRateText.text = playerSO.baseCritRate.ToString() + "%";
        critDamageText.text = playerSO.baseCritDamage.ToString() + "%";
        levelText.text = "Level: " + playerSO.currLevel.ToString();
        expNeededText.text = playerSO.expNeeded.ToString() + " Needed";
        expSlider.value = playerSO.ReturnExpRatio();
    }
}
