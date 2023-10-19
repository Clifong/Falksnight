using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySetupUIManager : MonoBehaviour
{
    public static PartySetupUIManager partySetupUIManager;
    public Transform panel;
    public Canvas partySetupUICanvas;
    private List<GameObject> currentlyInstantiatedImages = new List<GameObject>();
    public GameObject playerIcon;
    void Start()
    {
        if (partySetupUIManager != null){
            Destroy(this.gameObject);
        }
        partySetupUIManager = this;
    }

    public void InstantiateIcon(List<PlayerSO> partyInfo){
        partySetupUICanvas.enabled = !partySetupUICanvas.enabled;
        foreach (GameObject icon in currentlyInstantiatedImages){
            Destroy(icon);
        }
        foreach (PlayerSO playerSO in partyInfo)
        {
            GameObject instantiatedPlayerIcon = Instantiate(playerIcon, panel);
            PlayerIcon playerIconScript = instantiatedPlayerIcon.GetComponent<PlayerIcon>();
            currentlyInstantiatedImages.Add(instantiatedPlayerIcon);
            playerIconScript.SetField(playerSO);
        }
    }
}
