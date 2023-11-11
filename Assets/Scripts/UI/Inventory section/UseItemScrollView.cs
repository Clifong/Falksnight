using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemScrollView : MonoBehaviour
{
    public Transform viewPoint;
    public GameObject playerIcon;
    private List<GameObject> currentlyInstantiatedImages = new List<GameObject>();
    
    public void EnableObject() {
        List<PlayerSO> partyInfo = PlayerPartyManager.playerPartyManager.ReturnPartyMembers();
        foreach (GameObject icon in currentlyInstantiatedImages){
            Destroy(icon);
        }
        foreach (PlayerSO playerSO in partyInfo)
        {
            GameObject instantiatedPlayerIcon = Instantiate(playerIcon, viewPoint);
            PlayerIconInventory playerIconInventoryScript = instantiatedPlayerIcon.GetComponent<PlayerIconInventory>();
            currentlyInstantiatedImages.Add(instantiatedPlayerIcon);
            playerIconInventoryScript.SetField(playerSO);
        }
    }
}
