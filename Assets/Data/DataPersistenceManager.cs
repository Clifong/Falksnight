using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File storage config")]
    [SerializeField]
    private string fileName;
    [SerializeField]
    private bool useEncryption;
    public static DataPersistenceManager dataPersistenceManager;
    private FileDataHandler dataHandler;
    private List<IDataPersistence> dataPersistenceObjects;
    private GameData gameData;
    // Start is called before the first frame update
    void Awake()
    {
        if (dataPersistenceManager != null){
            Destroy(dataPersistenceManager);
        }
        dataPersistenceManager = this;
    }

    private void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        Debug.Log(Application.persistentDataPath);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void setDataFileName(string name) {
        this.fileName = name;
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){
        this.gameData = dataHandler.Load();

        if (this.gameData == null){
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame(){
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        this.dataHandler.Save(gameData);
    }

    private void OnApplicationQuit(){
        SaveGame();
    }
    
    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
