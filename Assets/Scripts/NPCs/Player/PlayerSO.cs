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
    public int currLevel;
    public int expNeeded;
    public List<SkillsSO> skillSet;
    public double expMultiplier;
    private float expExponent = 1.5f;
    private int totalExp;
    [SerializeField]
    private int currentExp = 0;

    public float getHealthRatio() {
        return (float)currentHealth/(float)baseHealth;
    }

    public void RecoverHealth(int recoverHealth) {
        currentHealth = Mathf.Min(currentHealth + recoverHealth, baseHealth);
    }

    public void CalculateTotalExpNeeded() {
        totalExp = (int)Mathf.Ceil((float)(100.0f + (currLevel * expMultiplier * Mathf.Pow(10, expExponent))));
        expNeeded = totalExp - currentExp;
    }

    public float ReturnExpRatio() {
        CalculateTotalExpNeeded();
        return (float)currentExp/(float)totalExp;
    }

    public void AddExp(int exp) {
        currentExp += exp;
        while (currentExp >= totalExp) {
            currentExp -= expNeeded;
            LevelUp();
            CalculateTotalExpNeeded();
        }
        CalculateTotalExpNeeded();
    }

    public void LevelUp() {
        currLevel += 1;
    }

}
