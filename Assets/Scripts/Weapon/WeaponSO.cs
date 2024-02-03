using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    public GameObject equipmentInSphereGrid;
    public GameObject equipmentInSphereGridForShop;
    public GameObject equipmentInSphereAndName;
    public Sprite equipmentImage;
    public string name;
    [TextAreaAttribute]
    public string description;
    public int healthBoost;
    public int attackBoost;
    public int defenceBoost;
    public int critRateBoost;
    public int critDamageBoost;
}
