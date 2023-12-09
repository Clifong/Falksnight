using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfidantGiftManager : MonoBehaviour
{
    public static ConfidantGiftManager confidantGiftManager;
    public Transform content;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI effectText;
    public TextMeshProUGUI descriptionText;
    public Image itemIcon;
    private ConfidantItemSO confidantItemSO;
    public Button giftItemButton;

    public Image confidantItemImage;
    public TextMeshProUGUI name;
    public TextMeshProUGUI whatItDoesText;
    public TextMeshProUGUI description;
    private List<GameObject> currentlyInstantiatedIcons = new List<GameObject>();


    private void Start() {
        if (confidantGiftManager != null) {
            Destroy(confidantGiftManager);
        }
        confidantGiftManager = this;
    }

    public void InstantiateImage(List<ConfidantItemSO> confidantItems){
        giftItemButton.gameObject.SetActive(false);
        foreach (GameObject icon in currentlyInstantiatedIcons)
        {
            Destroy(icon);
        }
        foreach (ConfidantItemSO confidantItemSO in confidantItems)
        {
            GameObject instantiatedGrid = Instantiate(confidantItemSO.confidantItemWithGrid, content);
            currentlyInstantiatedIcons.Add(instantiatedGrid);
        }
    }

    public void SetData(ConfidantItemSO confidantItemSO){
        confidantItemSO.SetUIInfo(name, whatItDoesText, description, confidantItemImage);
    }

    public void SetCurrentConfidantItemSO(GameObject confidantItemIcon, ConfidantItemSO confidantItemSO) {
        GiftingManager.giftingManager.SetReference(confidantItemIcon, confidantItemSO);
        this.confidantItemSO = confidantItemSO;
        giftItemButton.gameObject.SetActive(true);
        SetConfidantItemText();
    }

    public void SetConfidantItemText() {
        confidantItemSO.SetUIInfo(nameText, effectText, descriptionText, itemIcon);
    }

    public void RemoveConfidantItem(GameObject confidantItemIcon) {
        giftItemButton.gameObject.SetActive(false);
        currentlyInstantiatedIcons.Remove(confidantItemIcon);
        Destroy(confidantItemIcon);
    }

}
