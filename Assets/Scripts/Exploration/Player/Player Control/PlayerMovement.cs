using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private Vector2 offset;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value){
        offset = value.Get<Vector2>();
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + offset * speed);
    }

    public void LoadData(GameData gameData){
        if (rb == null){
            rb = GetComponent<Rigidbody2D>();
        }
        rb.position = gameData.playerPosition;
    }

    public void SaveData(GameData gameData){
        gameData.playerPosition = rb.position;
    }
}
