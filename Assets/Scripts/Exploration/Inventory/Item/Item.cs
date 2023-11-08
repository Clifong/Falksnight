using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    public GameObject itemWithGridImage;
    public Sprite itemImage;
    public string name;
    [TextAreaAttribute]
    public string description;
    public int recoverEnergy;
    public int recoverHealth;
}
