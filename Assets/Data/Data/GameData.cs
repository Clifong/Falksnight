using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public string path;
    public int money;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> explorationEnemyDict;
    public SerializableDictionary<string, bool> chestOpenedDict;
    public SerializableDictionary<string, bool> itemTakenDict;
    public SerializableDictionary<string, bool> ebonActivatedDict;

    public GameData() {
        this.path = "";
        this.money = 0;
        playerPosition = Vector3.zero;
        explorationEnemyDict = new SerializableDictionary<string, bool>();
        chestOpenedDict = new SerializableDictionary<string, bool>();
        ebonActivatedDict = new SerializableDictionary<string, bool>();
        itemTakenDict = new SerializableDictionary<string, bool>();
    }

    //Master game data remembers the last path
    //you revisited before logging out
    public GameData(string masterPath) {
        this.path = masterPath;
    }
}
