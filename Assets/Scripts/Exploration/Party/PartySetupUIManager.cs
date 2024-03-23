using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySetupUIManager : MonoBehaviour
{
    public static PartySetupUIManager partySetupUIManager;
    public Transform activePanel;
    public Transform reservePanel;
    public Canvas partySetupUICanvas;
    private List<GameObject> currentlyInstantiatedImages = new List<GameObject>();
    public GameObject playerIcon;
    public PlayerPartySO playerPartySO;
    void Start()
    {
        if (partySetupUIManager != null){
            Destroy(this.gameObject);
        }
        partySetupUIManager = this;
    }

    public void OnDisableCanvas() {
        List<PlayerSO> activeParty = new List<PlayerSO>();
        List<PlayerSO> reserveParty = new List<PlayerSO>();
        foreach (Transform child in activePanel)
        {
            activeParty.Add(child.gameObject.GetComponent<PlayerIcon>().GetPlayerSO());
        }
        foreach (Transform child in reservePanel)
        {
            reserveParty.Add(child.gameObject.GetComponent<PlayerIcon>().GetPlayerSO());
        }
        playerPartySO.ModifyPartySetup(activeParty, reserveParty);
    }

    public void InstantiatePartyIcon(){
        partySetupUICanvas.enabled = !partySetupUICanvas.enabled;
        if (partySetupUICanvas.enabled == false) {
            OnDisableCanvas();
        }
        else {
            foreach (GameObject icon in currentlyInstantiatedImages){
                Destroy(icon);
            }
            foreach (PlayerSO playerSO in playerPartySO.activeParty)
            {
                GameObject instantiatedPlayerIcon = Instantiate(playerIcon, activePanel);
                PlayerIcon playerIconScript = instantiatedPlayerIcon.GetComponent<PlayerIcon>();
                currentlyInstantiatedImages.Add(instantiatedPlayerIcon);
                playerIconScript.SetField(playerSO);
            }
            foreach (PlayerSO playerSO in playerPartySO.reserveParty)
            {
                GameObject instantiatedPlayerIcon = Instantiate(playerIcon, reservePanel);
                PlayerIcon playerIconScript = instantiatedPlayerIcon.GetComponent<PlayerIcon>();
                currentlyInstantiatedImages.Add(instantiatedPlayerIcon);
                playerIconScript.SetField(playerSO);
            }
        }
    }
}
