using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int money;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> explorationEnemyDict;

    public GameData() {
        this.money = 0;
        playerPosition = Vector3.zero;
        explorationEnemyDict = new SerializableDictionary<string, bool>();
    }
}
