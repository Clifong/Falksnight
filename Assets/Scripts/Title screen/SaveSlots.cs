using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveSlots : MonoBehaviour
{
    public TextMeshProUGUI title;
    private string path;
    private bool loadSave = false;
    public CrossObjectEventWithData broadcastData;
    public CrossObjectEvent accessSaveFile;
    public CrossObjectEvent createNewSave;
    private bool selected;

    //Instantiating an existing save slot
    public void PopulateData(string title, string path, bool loadSave) {
        this.loadSave = loadSave;
        this.path = path;
        this.title.text = title;
    }

    //Instantiating save slots that have no information
    public void PopulateData(string title, string path) {
        this.path = path;
        this.title.text = "EMPTY";
    }

    public void AccessingSaveFile() {
        selected = true;
        if (loadSave) {
            accessSaveFile.TriggerEvent();
        } else {
            createNewSave.TriggerEvent();
        }
    }

    public void Deselect() {
        selected = false;
    }

    //Tell required managers what to do once the save slot is clicked
    //loadSave == true, meaning we want to load a game file
    //laodSave == false, meaning we want to create a new game/reset
    //an existing save file
    public void BroadcastData() {
        if (selected) {
            broadcastData.TriggerEvent(this, path, loadSave);
        }
    }
}
