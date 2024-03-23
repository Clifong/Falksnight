using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConfidantUIManager : MonoBehaviour
{
    public static ConfidantUIManager confidantUIManager;
    public Slider relationshipSlider;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Transform contentView;
    public Canvas confidantCanvas;
    public Image characterImage;
    public PlayerPartySO playerPartySO;
    private List<GameObject> currentlyInstantiatedIcons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       if (confidantUIManager != null) {
        Destroy(confidantUIManager);
       } 
       confidantUIManager = this;
    }

    public void SetConfidantInfo(PlayerSO playerSO) {
        GiftingManager.giftingManager.SetReferencePlayer(playerSO);
        playerSO.GeneralConfidantTextInitialization(nameText, levelText, relationshipSlider);
    }

    public void EnableOrDisableCanvas(){
        confidantCanvas.enabled = !confidantCanvas.enabled;
        foreach (GameObject icon in currentlyInstantiatedIcons)
        {
            Destroy(icon);
        }
        List<PlayerSO> allPartyMembers = playerPartySO.ReturnAllPartyMembers();
        SetConfidantInfo(allPartyMembers[0]);
        foreach (PlayerSO playerSO in allPartyMembers)
        {
            GameObject instantiatedConfidantIcon = Instantiate(playerSO.confidantIcon, contentView);
            instantiatedConfidantIcon.GetComponent<ConfidantIcon>().SetPlayerSO(playerSO);
            currentlyInstantiatedIcons.Add(instantiatedConfidantIcon);
        }
    }
}
