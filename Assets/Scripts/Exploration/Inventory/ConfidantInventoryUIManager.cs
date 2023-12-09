using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfidantInventoryUIManager : MonoBehaviour
{
    public static ConfidantInventoryUIManager confidantInventoryUIManager;
    public Transform panel;
    public Image confidantItemImage;
    public TextMeshProUGUI name;
    public TextMeshProUGUI whatItDoesText;
    public TextMeshProUGUI description;
    private List<GameObject> currentlyInstantiatedIcons = new List<GameObject>();
    void Start()
    {
        if (confidantInventoryUIManager != null){
            Destroy(this.gameObject);
        }
        confidantInventoryUIManager = this;
    }

    public void InstantiateImage(List<ConfidantItemSO> confidantItems){
        foreach (GameObject icon in currentlyInstantiatedIcons)
        {
            Destroy(icon);
        }
        foreach (ConfidantItemSO confidantItemSO in confidantItems)
        {
            GameObject instantiatedGrid = Instantiate(confidantItemSO.confidantItemWithGrid, panel);
            currentlyInstantiatedIcons.Add(instantiatedGrid);
        }
    }

    public void SetData(ConfidantItemSO confidantItemSO){
        confidantItemSO.SetUIInfo(name, whatItDoesText, description, confidantItemImage);
    }
}
