using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardButton : MonoBehaviour
{
    public void TellCharacterToAttackEnemy(){
        CharacterManager.characterManager.Guard();
    }
}
