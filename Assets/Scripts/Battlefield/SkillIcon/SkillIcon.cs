using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIcon : MonoBehaviour
{
    private SkillsSO skillSO;

    public void SetSkillSO(SkillsSO skillSO){
        this.skillSO = skillSO;
    }

    public void TellCharacterToAttackEnemy(){
        CharacterManager.characterManager.IncrementAction(this.skillSO);
    }
}
