using System.Collections;
using System.Collections.Generic;
using ssm.data;
using UnityEngine;
namespace ssm.game.structure{
    public class AIGameManyTurn : AIGameEveryTurn
    {
        public override void PrepareGame(int maxTurn, float turnTime, PlayableCharacter c1, PlayableCharacter c2)
        {
            // base.PrepareGame(maxTurn, turnTime, c1, c2);
            GameBoard.Instance().maxTurn = 100;
            GameBoard.Instance().currentTurn = 0;
            GameBoard.Instance().turnTime = turnTime;
            board.Initialize(c1,c2);
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
                else ManageReadyPhase();
                
                break;
                case GameEvent.START_FINISH_PHASE:
                Debug.Log("GameEnd");
                
                break;

            }
        }
    }
}