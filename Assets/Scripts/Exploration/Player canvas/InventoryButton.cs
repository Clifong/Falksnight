using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    private PlayerOpenInventory playerOpenInventory;
    private void Start(){
        playerOpenInventory = GameObject.FindWithTag("MC").GetComponent<PlayerOpenInventory>();
    }
    public void OpenInventory(){
        playerOpenInventory.OpenInventory();
    }
}
