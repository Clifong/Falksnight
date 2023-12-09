using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    public GameObject playerGameObject;
    public GameObject partyIcon;
    public GameObject confidantIcon;
    public string name;
    public int currentHealth;
    public int baseHealth;
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
    public WeaponSO currWeapon;
    public int currentHealthWithBuffs;
    public int currentAttackWithBuffs;
    public int currentDefenceWithBuffs;
    public int currentCritRateWithBuffs;
    public int currentCritDamageWithBuffs;
    public int[] relationshipExpRequired;
    private int relationshipLevel = 0;
    private int currentRelationshipExp = 0;

    public void Initialise() {
        currentHealthWithBuffs = baseHealth + currWeapon.healthBoost;
        if (currentHealth > currentHealthWithBuffs) {
            currentHealth = currentHealthWithBuffs;
        }
        currentAttackWithBuffs = baseAttack + currWeapon.attackBoost;
        currentDefenceWithBuffs = baseDefence + currWeapon.defenceBoost;
        currentCritRateWithBuffs = baseCritRate + currWeapon.critRateBoost;
        currentCritDamageWithBuffs = baseCritDamage + currWeapon.critDamageBoost;
    }

    public void GeneralStatsTextInitialization(TextMeshProUGUI healthText, TextMeshProUGUI attackText, TextMeshProUGUI defenceText, TextMeshProUGUI critRateText,TextMeshProUGUI critDamageText){
        Initialise();
        healthText.text = currentHealth.ToString() + "/" + currentHealthWithBuffs.ToString();
        attackText.text = currentAttackWithBuffs.ToString();
        defenceText.text = currentDefenceWithBuffs.ToString();
        critRateText.text = currentCritRateWithBuffs.ToString() + "%";
        critDamageText.text = currentCritDamageWithBuffs.ToString() + "%";
    }

    public void GeneralConfidantTextInitialization(TextMeshProUGUI nameText, TextMeshProUGUI levelText, Slider relationshipSlider) {
        nameText.text = name;
        levelText.text = "Level: " + (relationshipLevel + 1).ToString();
        relationshipSlider.value = (float)currentRelationshipExp/(float)relationshipExpRequired[relationshipLevel];
    }

    public void LevelAndExpRequired(TextMeshProUGUI levelText, TextMeshProUGUI expNeededText){
        levelText.text = "Level: " + currLevel.ToString();
        expNeededText.text = expNeeded.ToString() + " Needed";
    }


    public float getHealthRatio() {
        return (float)currentHealth/(float)currentHealthWithBuffs;
    }

    public void SetHealthText(TextMeshProUGUI healthText) {
        healthText.text = currentHealth.ToString() + "/" + currentHealthWithBuffs.ToString();
    }

    public void RecoverHealth(int recoverHealth) {
        currentHealth = Mathf.Min(currentHealth + recoverHealth, currentHealthWithBuffs);
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

    public void RaiseRelationsipExp(int value) {
        currentRelationshipExp += value;
        while (currentRelationshipExp >= relationshipExpRequired[relationshipLevel]) {
            currentRelationshipExp -= relationshipExpRequired[relationshipLevel];
            relationshipLevel++;
        }
    }

    public void LevelUp() {
        currLevel += 1;
    }

    public void SwitchWeapon(WeaponSO weaponSO) {
        currWeapon = weaponSO;
        PlayerMenuManager.playerMenuManager.SetPlayerStats(this);
    }

}
