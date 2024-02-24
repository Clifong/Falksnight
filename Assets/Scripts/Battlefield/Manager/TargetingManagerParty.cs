using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingManagerParty : MonoBehaviour
{
    public GameObject selectTarget;
    private bool itemUsageMode = false;

    public void SetSelectedPlayer(Component component, object data){
        object[] temp = (object[]) data;
        Player player = (Player) temp[0];
        Transform playerTransform = player.gameObject.transform;
        selectTarget.transform.position = new Vector2(playerTransform.position.x, playerTransform.position.y + 1.0f);    
    }

    // public void SelectPlayerToUseItemOn() {
    //     itemUsageMode = true;
    // }
}
