using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string nextLevel;
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "MC"){
            LevelManager.LoadLevel(this, nextLevel);
        }
    }
}
