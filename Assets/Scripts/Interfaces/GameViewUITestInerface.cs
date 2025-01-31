using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;
namespace ssm.game.input{
    public class GameViewUITestInerface : MonoBehaviour
    {
        public GameEvent gameEvent;
        // Start is called before the first frame update
        private bool toggleWheelEnable;
        void Start()
        {
            toggleWheelEnable = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W)){

                //Wheel Interfece Open/Close
                if(toggleWheelEnable == true){
                    toggleWheelEnable = false;
                    gameEvent.Raise(GameEvent.TEST_WHEEL_DISABLE);
                }else{
                    toggleWheelEnable = true;
                    gameEvent.Raise(GameEvent.TEST_WHEEL_ENABLE);
                }
                Debug.Log("GameViewUITestInerface : Wheel Enable - " + toggleWheelEnable);
            }else if(Input.GetKeyDown(KeyCode.S)){
                //Open-Close Start View
            }else if(Input.GetKeyDown(KeyCode.N)){
                //Open-Close End View
            }else if(Input.GetKeyDown(KeyCode.B)){
                //Toggle Display BP on PowerInfo
                gameEvent.Raise(GameEvent.TEST_POWERINFO_TOGGLE_BP);
            }else if(Input.GetKeyDown(KeyCode.P)){
                //Open-Close Character Power Window
                gameEvent.Raise(GameEvent.TEST_POWERINFO_TOGGLE_OPEN);
            }else if(Input.GetKeyDown(KeyCode.V)){
                //Open-Close Opponent Power Window
            }else if(Input.GetKeyDown(KeyCode.N)){
                //Open-Close NextAction
            }else if(Input.GetKeyDown(KeyCode.Q)){
                //Modify Character HP to Random Value
            }else if(Input.GetKeyDown(KeyCode.A)){
                //Modify Character EP to Random Value
            }else if(Input.GetKeyDown(KeyCode.E)){
                //Modify Opponent HP to Random Value
            }else if(Input.GetKeyDown(KeyCode.D)){
                //Modify Opponent HP to Random Value
            }else if(Input.GetKeyDown(KeyCode.R)){
                //Modify Character Status
            }else if(Input.GetKeyDown(KeyCode.F)){
                //Modify Opponent Status
            }else if(Input.GetKeyDown(KeyCode.T)){
                //Turn Counter
                // Debug.Log("Test Update Turn");
                gameEvent.Raise(GameEvent.TEST_UPDATE_TUNR); // Done
            }else if(Input.GetKeyDown(KeyCode.H)){ // History
                gameEvent.Raise(GameEvent.TEST_ADD_HISTORY_SWORD); 
            }
        }
    }
}