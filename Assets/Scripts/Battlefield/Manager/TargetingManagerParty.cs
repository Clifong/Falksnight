using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingManagerParty : MonoBehaviour
{
    public GameObject selectTarget;
    public static TargetingManagerParty targetingManagerParty;
    void Awake()
    {
        if (targetingManagerParty != null){
            Destroy(targetingManagerParty);
        }    
        targetingManagerParty = this;
    }

    public void SetSelectedPlayer(Player player){
        AttackUIManager.attackUIManager.SelectPlayer(player);
        CharacterManager.characterManager.SetSelectedPlayer(player);
        Transform playerTransform = player.gameObject.transform;
        selectTarget.transform.position = new Vector2(playerTransform.position.x, playerTransform.position.y + 1.0f);    
    }
}
