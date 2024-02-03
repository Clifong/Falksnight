using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableIndicator : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField]
    private string id;
    [SerializeField]
    private GameObject interactCanvas;
    [SerializeField]
    private List<ItemSO> itemList;
    private bool collected = false;

    [ContextMenu("Generate GUID for chest")]
    public void GenerateGuid() {
        id = System.Guid.NewGuid().ToString();
    }

    public void Interact() {
        collected = true;
        InventoryManager.inventoryManager.AddNewItems(itemList);
        Destroy(this.gameObject);
    }

    public void ShowInteractCanvas() {
        interactCanvas.SetActive(true);
    }

    public void HideInteractCanvas() {
        interactCanvas.SetActive(false);
    }

    public void LoadData(GameData gameData){
        gameData.itemTakenDict.TryGetValue(id, out collected);
        if (this.collected) {
            Destroy(this.gameObject);
        }
    }

    public void SaveData(GameData gameData){
        if (gameData.itemTakenDict.ContainsKey(id)) {
            gameData.itemTakenDict.Remove(id);
        }
        gameData.itemTakenDict.Add(id, this.collected);
    }
}
