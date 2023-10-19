using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    public GameObject playerGameObject;
    public GameObject partyIcon;
    public string name;
    public int baseHealth;
    public int currentHealth;
    public int baseAttack;
    public int baseDefence;
    public int baseCritRate;
    public int baseCritDamage;
    public List<SkillsSO> skillSet;

    public float getHealthRatio(){
        return (float)currentHealth/(float)baseHealth;
    }
}
