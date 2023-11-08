using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager inventoryUIManager;
    public Transform panel;
    public GameObject scrollItemView;
    public Canvas playerUICanvas;
    public Image itemImage;
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public Button useButton;
    private GameObject referencedItem;
    private Item selectedItem;
    private PlayerSO selectedPlayer;
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
        useButton.gameObject.SetActive(false);
        foreach (GameObject item in currentlyInstantiatedImages)
        {
            Destroy(item);
        }
        foreach (Item item in items)
        {
            GameObject instantiatedGrid = Instantiate(item.itemWithGridImage, panel);
            instantiatedGrid.GetComponent<ItemIcon>().SetReference(instantiatedGrid);
            currentlyInstantiatedImages.Add(instantiatedGrid);
        }
    }

    public void SetData(Item itemData){
        itemImage.sprite = itemData.itemImage;
        name.text = itemData.name;
        description.text = itemData.description;
        useButton.gameObject.SetActive(true);
    }

    public void SetItemReference(Item itemData, GameObject instantiatedGrid) {
        referencedItem = instantiatedGrid;
        selectedItem = itemData;
    }

    public void SetSelectedPlayer(PlayerSO player) {
        selectedPlayer = player;
    }

    public void Consume() {
        if (selectedPlayer != null) {
            InventoryManager.inventoryManager.RemoveItem(selectedItem);
            selectedPlayer.RecoverHealth(selectedItem.recoverHealth);
            Destroy(referencedItem);
            scrollItemView.SetActive(false);
        }
    }
}
