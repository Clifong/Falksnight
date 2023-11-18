using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ebonstatue : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField]
    private string id;
    private static int counter = 0;
    private int totalStatue;
    [SerializeField]
    private GameObject interactCanvas;
    private Animator anime;
    public UnityEvent ActivateStatueEffect;
    private bool activated = false;

    [ContextMenu("Generate GUID for chest")]
    public void GenerateGuid() {
        id = System.Guid.NewGuid().ToString();
    }

    private void Start() {
        Ebonstatue.counter = 0;
        totalStatue = GameObject.FindGameObjectsWithTag("Ebonstatue").Length;
    }

    public void Interact() {
        if (!activated) {
            anime.SetBool("Purify", true);
            activated = true;
            IncrementCounter();
        }
    }

    public void Purified() {
        anime.SetBool("Purified", true);
    }

    public void ShowInteractCanvas() {
        if (!activated) {
            interactCanvas.SetActive(true);
        }
    }

    public void HideInteractCanvas() {
        interactCanvas.SetActive(false);
    }

    public void IncrementCounter() {
        Ebonstatue.counter++;
        if (counter == totalStatue) {
            ActivateStatueEffect?.Invoke();
        }
    }

    public void LoadData(GameData gameData){
        gameData.ebonActivatedDict.TryGetValue(id, out activated);
        anime = GetComponent<Animator>();
        if (this.activated) {
            Ebonstatue.counter++;
            anime.SetBool("Purified", true);
        }
    }

    public void SaveData(GameData gameData){
        if (gameData.ebonActivatedDict.ContainsKey(id)) {
            gameData.ebonActivatedDict.Remove(id);
        } 
        gameData.ebonActivatedDict.Add(id, this.activated);
    }
}
