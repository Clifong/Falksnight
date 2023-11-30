using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDisabler : MonoBehaviour
{
    public static PlayerMovementDisabler playerMovementDisabler;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        if (playerMovementDisabler != null){
            Destroy(playerMovementDisabler);
        }
        playerMovementDisabler = this;
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void ChangeEnable(){
        playerMovement.enabled = !playerMovement.enabled;
    }
}
