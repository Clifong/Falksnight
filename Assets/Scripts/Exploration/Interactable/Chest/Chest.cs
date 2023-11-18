using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField]
    private string id;
    [SerializeField]
    private GameObject interactCanvas;
    private bool opened = false;
    private Animator anime;
    public List<Item> chestItems;

    [ContextMenu("Generate GUID for chest")]
    public void GenerateGuid() {
        id = System.Guid.NewGuid().ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    public void LoadData(GameData gameData){
        gameData.chestOpenedDict.TryGetValue(id, out opened);
        if (this.opened) {
            Destroy(this.gameObject);
        }
        else {
            opened = false;
        }
    }

    public void SaveData(GameData gameData){
        if (gameData.chestOpenedDict.ContainsKey(id)) {
            gameData.chestOpenedDict.Remove(id);
        } 
        gameData.chestOpenedDict.Add(id, opened);
    }

    public void ShowInteractCanvas() {
        interactCanvas.SetActive(true);
    }

    public void HideInteractCanvas() {
        interactCanvas.SetActive(false);
    }

    public void Interact() {
        InventoryManager.inventoryManager.AddNewItems(chestItems);
        opened = true;
        anime.SetTrigger("Open");
        Destroy(this);
    }
}
