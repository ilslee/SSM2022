using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.input{
    public class GameTestInput : MonoBehaviour
    {
        public GameEvent gameEvent;
        public GameBoard gameBoard;

        public void Start(){
            if(gameEvent == null) Debug.LogError("GameTestInput : Bind gameEvent instance first!");
            if(gameBoard == null) Debug.LogError("GameTestInput : Bind gameBoard instance first!");
        }

        public void Update()
        {
            InputTurn();
        }

        private void InputTurn(){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(GameBoard.Instance().currentTurn == 0){
                    gameEvent.Raise(GameEvent.GAME_START);
                }else{
                    if(GameBoard.Instance().phase == GameTerms.Phase.Feedback){
                        gameEvent.Raise(GameEvent.TURN_START);
                    }else{
                        Debug.LogError("GameTestInput : Not Appropriate phase to send input.");
                    }
                }
                
            }
        }
        
    }

}
