using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuIcon : MonoBehaviour
{
    private PlayerOpenPlayerMenu playerOpenPlayerMenu;
    private void Start(){
        playerOpenPlayerMenu = GameObject.FindWithTag("MC").GetComponent<PlayerOpenPlayerMenu>();
    }
    public void OpenPlayerMenu(){
        playerOpenPlayerMenu.OpenPlayerMenu();
    }
}
