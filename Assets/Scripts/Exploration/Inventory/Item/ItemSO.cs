using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Item", order = 1)]
public class ItemSO : ScriptableObject
{
    public GameObject itemWithGridImage;
    public GameObject itemWithGridImageForBattle;
    public GameObject itemWithGridImageForShop;
    public GameObject itemWithGridImageAndName;
    public Sprite itemImage;
    public string name;
    public int cost;
    [TextAreaAttribute]
    public string description;
    public int recoverEnergy;
    public int recoverHealth;
}
