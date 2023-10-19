using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExplorationEnemySO", menuName = "ExplorationEnemySO", order = 1)]
public class ExplorationEnemySO : ScriptableObject
{
    // [ContextMenu("Generate random Id for enemy")]
    // private void GenerateId(){
    //     id = System.Guid.NewGuid().ToString();
    // }
    // public string id;
    public bool dead;
    public List<EnemySO> enemies;
    public ExplorationEnemySO Copy(){
        return Instantiate(this);
    }
}
