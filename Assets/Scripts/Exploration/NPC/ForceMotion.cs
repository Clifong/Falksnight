using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForceMotion : MonoBehaviour
{
    public List<Transform> positionsForceToGoTo;
    public List<UnityEvent> onReachDestination;
    public float speed;
    private int index = 0;
    private Rigidbody2D rb;
    private Animator anime;
    private bool canMove = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    void Update() {
        if (canMove) {
            rb.position = Vector3.MoveTowards(rb.position, positionsForceToGoTo[index].position, speed);
            if (rb.position.Equals(positionsForceToGoTo[index].position)) {
                canMove = false;
                anime.SetBool("move", false);
                if (onReachDestination[index] != null) {
                    onReachDestination[index]?.Invoke();
                }
                index += 1;
            }        
        }
    }
    
    public void GoToPosition() {
        anime.SetBool("move", true);
        canMove = true;
    }
}
