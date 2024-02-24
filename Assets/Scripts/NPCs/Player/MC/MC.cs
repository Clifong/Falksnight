using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC : Player
{
    // Start is called before the first frame update
    void Start()
    {
        this.Initialise();
    }

    protected override void Attack(){
        base.Attack();
    }
}
