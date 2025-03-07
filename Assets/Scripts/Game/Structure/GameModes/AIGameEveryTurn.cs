using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using Unity.PlasticSCM.Editor.WebApi;
using ssm.data.league;
namespace ssm.game.structure{
    
    //매 턴 인터페이스를 통해 갱신되는 게임    
    public class AIGameEveryTurn : Game
    {
        public AIGame aiGameData;
        public override void PrepareGame(){
            Debug.Log("AIGameEveryTurn.PrepareGame");
            League curLeague = ssmData.leagues[ssmData.currentWorld];
            if(curLeague == null){
                Debug.LogError("AIGameEveryTurn.PrepareGame : No league data found!");
                return;
            }
            GameBoard.Instance().maxTurn = curLeague.maxTurn;
            GameBoard.Instance().currentTurn = 0;
            GameBoard.Instance().turnTime = curLeague.turnTime;
            GameBoard.Instance().Initialize(aiGameData.opponent,aiGameData.opponent2);
            GameLogDisplayer.LogGamePreparation("AIGameEveryTurn");
        }
        
        public override bool CheckGameEnd(){

            Debug.Log("--Check Game End : " + (GameBoard.Instance().currentTurn >= GameBoard.Instance().maxTurn).ToString());
            if( GameBoard.Instance().currentTurn >= GameBoard.Instance().maxTurn){
                return true;
            }
            return false;
        
        }
        /*
        public override void ManageGameEvent(string type, float value){
            switch(type){
                case GameEvent.GAME_START:
                base.StartGame();
                break;
                case GameEvent.START_PHASE_OVER:
                gameEvent.Raise(GameEvent.TURN_START);
                break;
                case GameEvent.TURN_START:
                ManageTurnReady();
                break;
                case GameEvent.READY_PHASE_OVER:
                ManagePosePhase();
                break;
                case GameEvent.POSE_PHASE_OVER:
                ManageTurnCalculate();
                break;
                case GameEvent.CALCULATIION_PHASE_OVER:
                ManageResult();
                break;
                case GameEvent.RESULT_PHASE_OVER:
                if(CheckGameEnd() == true) ManageFinishPhase();
                // else ManageTurnReady(); // 여기서 일시 정지
                
                break;
                case GameEvent.START_FINISH_PHASE:
                Debug.Log("GameEnd");
                
                break;

            }
        }
        */
    }
}