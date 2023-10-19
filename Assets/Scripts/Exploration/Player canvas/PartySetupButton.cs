using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySetupButton : MonoBehaviour
{
    private PlayerOpenParty playerOpenParty;
    private void Start(){
        playerOpenParty = GameObject.FindWithTag("MC").GetComponent<PlayerOpenParty>();
    }
    public void OpenParty(){
        playerOpenParty.OpenParty();
    }
}
