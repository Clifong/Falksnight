using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillIcon : MonoBehaviour
{
    private SkillsSO skillSO;
    [SerializeField]
    private TextMeshProUGUI skillName;

    private void Start() {
        skillName.text = skillSO.name;
    }

    public void SetSkillSO(SkillsSO skillSO){
        this.skillSO = skillSO;
    }

    public void TellCharacterToAttackEnemy(){
        CharacterManager.characterManager.IncrementAction(this.skillSO);
    }
}
