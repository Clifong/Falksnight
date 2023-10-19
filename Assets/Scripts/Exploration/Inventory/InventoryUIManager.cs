using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager inventoryUIManager;
    public Transform panel;
    public Canvas playerUICanvas;
    public Image itemImage;
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    private List<GameObject> currentlyInstantiatedImages = new List<GameObject>();
    void Start()
    {
        if (inventoryUIManager != null){
            Destroy(this.gameObject);
        }
        inventoryUIManager = this;
    }

    public void InstantiateImage(List<Item> items){
        playerUICanvas.enabled = !playerUICanvas.enabled;
        foreach (GameObject item in currentlyInstantiatedImages)
        {
            Destroy(item);
        }
        foreach (Item item in items)
        {
            GameObject instantiatedGrid = Instantiate(item.ItemWithGridImage, panel);
            currentlyInstantiatedImages.Add(instantiatedGrid);
        }
    }

    public void SetData(Item itemData){
        itemImage.sprite = itemData.itemImage;
        name.text = itemData.name;
        description.text = itemData.description;
    }
}
