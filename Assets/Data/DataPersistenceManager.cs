using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File storage config")]
    [SerializeField]
    private string path;
    [SerializeField]
    private bool useEncryption;
    public static DataPersistenceManager dataPersistenceManager;
    private FileDataHandler dataHandler;
    private List<IDataPersistence> dataPersistenceObjects;
    private GameData gameData;
    [SerializeField]
    private bool loadGame = false;
    private bool newGame = false;
 
    //Note that we want to make this a singleton
    //Reason being is that we don't want any information
    //of the selected save slot to be lost.
    //For instance, if we load a save file with 
    //pathName = "x", this information must be retained
    //by the singleton. Consideration: Maybe use SO to store?
    void Awake()
    {
        if (dataPersistenceManager != null){
            Debug.Log("AWAKE");
            Debug.Log(dataPersistenceManager);
            Debug.Log(this);
            Debug.Log(dataPersistenceManager == this);
            Destroy(this);
            dataPersistenceManager.Start();
        }
        else {
            dataPersistenceManager = this;
        }
        DontDestroyOnLoad(dataPersistenceManager);
    }

    //loadGame being true means all necessary data
    //has been stored

    //Steps of how game data should be load:
    //If new game:
    //=> Create new directory/Overrwire directory for nth game data
    //=> Create master save file
    //=> Direct them to tutorial cutscene 1

    //If saved game:
    //=> Locate the directory for nth save slot
    //=> Inspect the master save file
    //=> Load the last path
    private void Start(){
        Debug.Log("RE");
        Debug.Log(dataPersistenceManager.loadGame);
        Debug.Log(LevelManager.GetCurrentLevel());
        if (dataPersistenceManager.loadGame) {
            dataPersistenceManager.dataHandler = new FileDataHandler(dataPersistenceManager.path, LevelManager.GetCurrentLevel(), useEncryption);
            dataPersistenceManager.dataPersistenceObjects = FindAllDataPersistenceObjects();
            dataPersistenceManager.LoadFile();
        }
    }

    //This is only called when loading a save slot
    public void SetPath(Component component, object obj) {
        object[] temp = (object[]) obj;
        dataPersistenceManager.path = (string) temp[0];
        dataPersistenceManager.newGame = !((bool) temp[1]);
        dataPersistenceManager.loadGame = true;
        dataPersistenceManager.dataHandler = new FileDataHandler(dataPersistenceManager.path, "");
        Debug.Log(dataPersistenceManager.loadGame);
        Debug.Log(dataPersistenceManager.dataHandler);
        if (this.newGame) {
            NewGame();
        } else {
            Debug.Log(dataPersistenceManager.path);
            GameData masterSaveData = dataPersistenceManager.dataHandler.LoadSaveFile();
            Debug.Log("LOADING");
            Debug.Log(masterSaveData.path);
            string lastLevelName = "";
            for (int i = masterSaveData.path.Length - 1; i > 0 ; i--) {
                if (masterSaveData.path[i] == '\\') {
                    char[] charArray = lastLevelName.ToCharArray();
                    Array.Reverse(charArray);
                    lastLevelName = new string(charArray);
                    break;
                }
                else {
                    lastLevelName += masterSaveData.path[i];
                }
            }
            LevelManager.LoadLevel(dataPersistenceManager, lastLevelName);
        }
    }

    public void NewFile(){
        dataPersistenceManager.gameData = new GameData();
        dataPersistenceManager.dataHandler.CreateNewFile(LevelManager.GetCurrentLevel(), dataPersistenceManager.gameData);
    }

    public void NewGame() {
        dataPersistenceManager.dataHandler.CreateNewGame();
        LevelManager.LoadLevel(this, "Tutorial Cutscene");
    }

    public void LoadFile(){
        dataPersistenceManager.gameData = dataPersistenceManager.dataHandler.LoadLevel();

        if (dataPersistenceManager.gameData == null){
            NewFile();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(dataPersistenceManager.gameData);
        }
    }

    public void SaveGame(){
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(dataPersistenceManager.gameData);
        }
        Debug.Log("SAVING");
        Debug.Log(dataPersistenceManager.gameData.path);
        dataPersistenceManager.dataHandler.Save(dataPersistenceManager.gameData);
    }

    private void OnApplicationQuit(){
        SaveGame();
    }
    
    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
