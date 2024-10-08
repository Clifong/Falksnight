using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponInSphereGrid;
    public GameObject weaponInSphereGridForShop;
    public GameObject weaponInSphereAndName;
    public Sprite weaponImage;
    public string name;
    public int cost;
    [TextAreaAttribute]
    public string description;
    public int healthBoost;
    public int attackBoost;
    public int defenceBoost;
    public int critRateBoost;
    public int critDamageBoost;
}
