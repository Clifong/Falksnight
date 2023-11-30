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
    public List<Item> itemDrop;
    public int minMoneyEarned;
    public int maxMoneyEarned;
    public int level;
    public int levelMultiplier;
    public float levelExponent = 1.5f;

    public int returnRandomMoney() {
        return Random.Range(minMoneyEarned, maxMoneyEarned);
    }

    public int CalculateExp() {
        return (int)Mathf.Ceil((float)(50.0f + (level * levelMultiplier * Mathf.Pow(50, levelExponent))));
    }
}
