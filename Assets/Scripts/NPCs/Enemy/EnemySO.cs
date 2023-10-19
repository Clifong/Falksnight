using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "EnemySO", order = 1)]
public class EnemySO : ScriptableObject
{
    public GameObject enemyGameObject;
    public string name;
    public int baseHealth;
    public int baseAttack;
    public int baseDefence;
    public int baseCritRate;
    public int baseCritDamage;
    public List<SkillsSO> skillSet;
}
