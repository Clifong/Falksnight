using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationEnemy : MonoBehaviour
{
    [SerializeField]
    
    private Rigidbody2D rb;
    public ExplorationEnemySO explorationEnemySO;
    public EnemyPartySO enemyPartySO;

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
            enemyPartySO.SetEnemyParty(explorationEnemySO);
            LevelManager.LoadLevel(this, "battlefield");
        }
    }
}
