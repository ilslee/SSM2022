using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ssm.game.structure;
namespace ssm.game.appearance{
    public class GameTurnCounter : MonoBehaviour
    {
        public GameBoard gameBoard;
        public TMP_Text turn;
        public void Start(){
            if(turn == null) Debug.LogError("GameTurnCounter : Bind turn instance first!");
            if(gameBoard == null) Debug.LogError("GameTurnCounter : Bind gameBoard instance first!");
        }
        public void ManageGameEvent(string type, int index, int value){
            switch(type){
                case GameEvent.READY_PHASE_OVER:
                turn.text = "Turn " + GameBoard.Turn.ToString();
                break;
            }
        }
    }
}