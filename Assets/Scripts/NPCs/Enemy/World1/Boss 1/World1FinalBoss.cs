using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World1FinalBoss : Boss
{
    void Start()
    {
        oldBaseHealth = enemySO.baseHealth;
        this.Initialise();
    }
}
