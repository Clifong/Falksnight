using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDisabler : MonoBehaviour
{
    public static PlayerAttackDisabler playerAttackDisabler;
    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        if (playerAttackDisabler != null){
            Destroy(playerAttackDisabler);
        }
        playerAttackDisabler = this;
        playerAttack = GetComponent<PlayerAttack>();
    }

    public void ChangeEnable(){
        playerAttack.enabled = !playerAttack.enabled;
    }
}
