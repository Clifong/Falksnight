using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject targeting;

    void OnAttack(){
        if (this.enabled){
            Instantiate(targeting, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
        }
    }

    void Update(){
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}
