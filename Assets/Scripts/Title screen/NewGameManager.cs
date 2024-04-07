using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameManager : MonoBehaviour
{
    public Transform content;
    [SerializeField]
    private string subFolderName;
    [SerializeField]
    private bool useEncryption;
    [SerializeField]
    private int maxGameSlots;
    private FileDataHandler dataHandler;
    public GameObject saveSlots;


    void Start()
    {
        //Since "New game" is clicked. We want to check all 10 save slots 
        //Hence, the constructor is supplied with the
        //path of the game and ain folder name for the nth save slot
        //is the subfoldername 
        //Then, populate a space with all available save slots
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, subFolderName);
        this.dataHandler.PopulateSlots(content, maxGameSlots, saveSlots, false);
    }
}
