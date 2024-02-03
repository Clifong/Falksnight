using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUIManager : MonoBehaviour
{
    public static ItemUIManager itemUIManager;
    public Transform panel;
    public GameObject scrollItemView;
    public Canvas playerUICanvas;
    public Image itemImage;
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public Button useButton;
    private GameObject referencedItem;
    private ItemSO selectedItem;
    private PlayerSO selectedPlayer;
    private List<GameObject> currentlyInstantiatedImages = new List<GameObject>();
    void Start()
    {
        if (itemUIManager != null){
            Destroy(this.gameObject);
        }
        itemUIManager = this;
    }

    public void InstantiateImage(List<ItemSO> items){
        playerUICanvas.enabled = !playerUICanvas.enabled;
        useButton.gameObject.SetActive(false);
        foreach (GameObject item in currentlyInstantiatedImages)
        {
            Destroy(item);
        }
        foreach (ItemSO item in items)
        {
            GameObject instantiatedGrid = Instantiate(item.itemWithGridImage, panel);
            instantiatedGrid.GetComponent<ItemIcon>().SetReference(instantiatedGrid);
            SetData(items[0]);
            currentlyInstantiatedImages.Add(instantiatedGrid);
        }
    }

    public void SetData(ItemSO itemData){
        itemImage.sprite = itemData.itemImage;
        name.text = itemData.name;
        description.text = itemData.description;
        useButton.gameObject.SetActive(true);
    }

    public void SetItemReference(ItemSO itemData, GameObject instantiatedGrid) {
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
