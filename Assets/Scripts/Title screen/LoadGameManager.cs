using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameManager : MonoBehaviour
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
        //Since "Loaf game" is clicked. We want to check what save slots 
        //are being used. Hence, the constructor is supplied with the
        //path of the game and ain folder name for the nth save slot
        //is the subfoldername 
        //Then, populate a space with all available save slots
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, subFolderName);
        this.dataHandler.PopulateSlots(content, maxGameSlots, saveSlots, true);
    }
}
