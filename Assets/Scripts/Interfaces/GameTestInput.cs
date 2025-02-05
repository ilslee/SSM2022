using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.input{
    public class GameTestInput : MonoBehaviour
    {
        public GameEvent gameEvent;
        // public GameBoard gameBoard;

        public void Start(){
            if(gameEvent == null) Debug.LogError("GameTestInput : Bind gameEvent instance first!");
        }

        public void Update()
        {
            InputTurn();
        }

        private void InputTurn(){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("GameTestInput.InputTurn : Current Phase " + GameBoard.Instance().phase);
                switch(GameBoard.Instance().phase){
                    case GameTerms.Phase.None:
                    gameEvent.Raise(GameEvent.GAME_START_START);
                    break;
                    case GameTerms.Phase.Turn_Ready:
                    gameEvent.Raise(GameEvent.TURN_CALCULATE_START);
                    break;
                    default:
                    Debug.LogError("GameTestInput : Not Appropriate phase to send input.");
                    break;
                }
                
                
            }
        }
        
    }

}
