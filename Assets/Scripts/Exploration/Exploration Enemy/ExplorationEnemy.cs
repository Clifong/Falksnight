using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationEnemy : MonoBehaviour
{
    [SerializeField]
    
    private Rigidbody2D rb;
    public ExplorationEnemySO explorationEnemySO;

    // Start is called before the first frame update
    void Start()
    {
        if (explorationEnemySO.dead){
            Destroy(this.gameObject);
        }
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "target"){
            EnemyPartyManager.enemyPartyManager.SetEnemyParty(explorationEnemySO);
            LevelManager.LoadLevel(this, "battlefield");
        }
    }
}
