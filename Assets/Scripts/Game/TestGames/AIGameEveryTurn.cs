using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    
    //매 턴 인터페이스를 통해 갱신되는 게임    
    public class AIGameEveryTurn : Game
    {
        
        public override void ManageStartPhase(){
            Debug.Log("------------AIGame : Game Start-");
            base.ManageStartPhase();
        }
        public override void ManageReadyPhase(){
            Debug.Log("--------TURN [" + (GameBoard.Turn +1).ToString() +"]-");
            base.ManageReadyPhase();
        }
        
        public override void ManageCalculatePhase(){
            Debug.Log("----Calculate");
            base.ManageCalculatePhase();            
        }
        
        public override bool CheckGameEnd(){
            Debug.Log("--Check Game End");
            if( GameBoard.Turn >= GameBoard.MaxTurn){
                return true;
            }
            return false;
        
        }
        
        public override void ManageGameEvent(string type, int index, int value){
            switch(type){
                case GameEvent.GAME_START:
                base.StartGame();
                break;
                case GameEvent.START_PHASE_OVER:
                gameEvent.Raise(GameEvent.TURN_START);
                break;
                case GameEvent.TURN_START:
                ManageReadyPhase();
                break;
                case GameEvent.READY_PHASE_OVER:
                ManagePosePhase();
                break;
                case GameEvent.POSE_PHASE_OVER:
                ManageCalculatePhase();
                break;
                case GameEvent.CALCULATIION_PHASE_OVER:
                ManageResult();
                break;
                case GameEvent.RESULT_PHASE_OVER:
                if(CheckGameEnd() == true) ManageFinishPhase();
                // else ManageReadyPhase(); // 여기서 일시 정지
                
                break;
                case GameEvent.START_FINISH_PHASE:
                Debug.Log("GameEnd");
                
                break;

            }
        }
        
    }
}