using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager turnManager;
    public CrossObjectEvent playerTurn;
    public CrossObjectEvent enemyTurn;
    [SerializeField]
    Turns turnName;
    private enum Turns
    {
        PLAYER_TURN,
        ENEMY_TURN,
    }

    // Start is called before the first frame update
    void Start()
    {
        if (turnManager != null){
            Destroy(turnManager);
        }
        turnManager = this;
        turnName = Turns.PLAYER_TURN;
    }

    public void ChangeTurn(){
        if (turnName == Turns.PLAYER_TURN){
            turnName = Turns.ENEMY_TURN;
            enemyTurn.TriggerEvent();
        }
        else{
            turnName = Turns.PLAYER_TURN;
            playerTurn.TriggerEvent();
        }
    }
}
