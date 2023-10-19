using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUICanvas : MonoBehaviour
{
    public Slider healthBar;
    private Enemy enemyParentScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyParentScript = GetComponentInParent<Enemy>();
        healthBar.value = 1;
    }

    void Update(){
        healthBar.value = enemyParentScript.GetCurrentHealthRatio();
    }
}
