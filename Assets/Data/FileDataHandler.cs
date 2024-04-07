using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class FileDataHandler {
    private string dataDirPath = "";
    private string subFolderName = "";
    private string dataFileName = "";
    private bool useEncryption = false;
    private readonly string encryptionCodeword = "";

    private static string masterFilename = "Master filename";
    private GameData masterGameData;
    private string masterFilePath;

    //Used for instantiating a save file for that level
    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption){
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    //Used for instantiating a folder to store all save files
    public FileDataHandler(string dataDirPath, string subFolderName){
        this.dataDirPath = dataDirPath;
        this.subFolderName = subFolderName;
    }

    //Load save file
    public GameData LoadSaveFile(){
        masterFilePath = Path.Combine(dataDirPath, masterFilename);
        masterGameData = ConvertJSONFileToGameData(masterFilePath);
        Debug.Log("MASTER GAME DATA PATH");
        Debug.Log(masterGameData.path);

        return ConvertJSONFileToGameData(masterGameData.path);
    }

    public GameData LoadLevel(){
        Debug.Log("LOAD LEVEL");
        masterFilePath = Path.Combine(dataDirPath, masterFilename);
        masterGameData = ConvertJSONFileToGameData(masterFilePath);
        Debug.Log(dataDirPath);
        Debug.Log(this.dataFileName);
        Debug.Log(masterGameData);
        masterGameData.path = Path.Combine(dataDirPath, this.dataFileName);

        return ConvertJSONFileToGameData(dataFileName);
    }

    public GameData ConvertJSONFileToGameData(string path) {
        GameData loadedData = null;
        if (File.Exists(path)){
            try{
                string dataToLoad = "";
                using (FileStream fileStream = new FileStream(path, FileMode.Open)){
                    using (StreamReader reader = new StreamReader(fileStream)){
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if (useEncryption){
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            } catch (Exception e){
                Debug.Log("ERROR loading file to " + path);
            }
        }
        return loadedData;
    }

    public void CreateNewFile(string levelName, GameData gameData) {
        gameData.path = Path.Combine(dataDirPath, levelName);
    }

    //Create a new game
    public void CreateNewGame() {
        try {
            Debug.Log(dataDirPath);
            if (Directory.Exists(dataDirPath)) {
                Directory.Delete(dataDirPath);
            }

            //Initialise the masterGameData to first have the path value
            //of the tutorial cutscene. So that you'll be directed there
            Directory.CreateDirectory(dataDirPath);
            string tutorialCutscenePath = Path.Combine(dataDirPath, "Tutorial Cutscene");
            GameData masterGameData = new GameData(tutorialCutscenePath);

            //We want to create a JSON file that stores the data in masterGameData
            string dataToStore = JsonUtility.ToJson(masterGameData, true);
            string fullPath = Path.Combine(dataDirPath, masterFilename);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create)){
                using (StreamWriter writer = new StreamWriter(stream)){
                    writer.Write(dataToStore);
                }
            }
        } catch (Exception e) {
            Debug.Log("ERROR creating a new directory");
        }
    }

    //Instantiate a save slot with associated data
    public void PopulateSlots(Transform content, int maxGameSlots, GameObject slots, bool isItSave) {
        string[] allSubDirectories = Directory.GetDirectories(dataDirPath);

        List<string> allSaveSlotNumber = new List<string>();
        foreach (string name in allSubDirectories)
        {
            allSaveSlotNumber.Add(name[name.Length - 1].ToString());
        }
        Debug.Log(dataDirPath);
        Debug.Log(allSaveSlotNumber.Count);
        Debug.Log(subFolderName);

        SaveSlots currSaveSlot = null;
        string mainPath = Path.Combine(dataDirPath, subFolderName);
        if (isItSave) {
            //Save slots
            for (int i = 0; i < allSaveSlotNumber.Count; i++) {
                if (allSaveSlotNumber.Contains(allSaveSlotNumber[i])) {
                    currSaveSlot = MonoBehaviour.Instantiate(slots, content).GetComponent<SaveSlots>();
                    currSaveSlot.PopulateData(allSaveSlotNumber[i], mainPath + allSaveSlotNumber[i], true);
                }
            }
        } else {
            //New game
            for (int i = 0; i < maxGameSlots; i++) {
                if (!allSaveSlotNumber.Contains(i.ToString())) {
                    currSaveSlot = MonoBehaviour.Instantiate(slots, content).GetComponent<SaveSlots>();
                    currSaveSlot.PopulateData(i.ToString(), mainPath + i.ToString());
                } 
            }
        }
        
    }

    public void Save(GameData data){
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        masterGameData.path = fullPath;
        ConvertGameDataToJSONFile(fullPath, data);
        ConvertGameDataToJSONFile(masterFilePath, masterGameData);
    }

    public void ConvertGameDataToJSONFile(string fullPath, GameData data) {
        try{
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(data, true);
            
            if (useEncryption){
                dataToStore = EncryptDecrypt(dataToStore);
            }

            using (FileStream stream = new FileStream(fullPath, FileMode.Create)){
                using (StreamWriter writer = new StreamWriter(stream)){
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e){
            Debug.Log("ERROR saving file to " + fullPath);
        }
    }

    private string EncryptDecrypt(string data){
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char) (data[i] ^ encryptionCodeword[i % encryptionCodeword.Length]);
        }
        return modifiedData;
    }
}
