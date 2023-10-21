using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantSO", menuName = "PlantSO", order = 1)]
public class PlantSO  : ScriptableObject
{
    public GameObject plantGameObject;
    public string name;
    public int cost;
    public int baseAttack;
}
