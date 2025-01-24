using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
namespace ssm.game.structure{
    /* Game
    게임 흐름을 제어 가능하도록 구조만 가지고 있음
    이를 상속하는 하위 클래스에서 구체적인 게임 흐름을 제어
    */
    public class Game : MonoBehaviour
    {
        public GameEvent gameEvent;
        public SSMGameData ssmData;
        

        public virtual void PrepareGame(){

            // GameBoard.Instance().maxTurn = maxTurn;
            // GameBoard.Instance().currentTurn = 0;
            // GameBoard.Instance().turnTime = turnTime;
            // GameBoard.Instance().Initialize(c1,c2);
            // GameLogDisplayer.LogGamePreparation();
        }
        
        public void StartGame(){
            PrepareGame();
            ManageStartPhase();
        }
                
        // public void RunTurn(){}

        // 턴 흐름 관리. 하위 클래스에서 변경, 추가 예정 ------------------------------
        
        //게임 처음 시작시
        public virtual void ManageStartPhase(){
            GameBoard.Instance().phase = GameTerms.Phase.StartGame;
            //시작 준비 완료. 
            //게임 UI 업데이트, 캐릭터 아이들 모션
            //Todo 카운트다운으로 이동
            gameEvent.Raise(GameEvent.START_PHASE_OVER); 
        }
        //입력 
        public virtual void ManageReadyPhase(){
            GameBoard.Instance().phase = GameTerms.Phase.Recovery;
            GameBoard.Instance().currentTurn ++;
            GameBoard.Instance().AddPlayData();
            GameBoard.Instance().CalculateOnRecovery();
            GameBoard.Instance().phase = GameTerms.Phase.Expectation;
            GameBoard.Instance().CalculateExpectations();
            gameEvent.Raise(GameEvent.READY_PHASE_OVER);
        }
        // 상호 Pose 선택
        public virtual void ManagePosePhase(){
            GameBoard.Instance().phase = GameTerms.Phase.Motion;
            GameBoard.Instance().ProcessMotions();
            gameEvent.Raise(GameEvent.POSE_PHASE_OVER);
        }
        public virtual void ManageCalculatePhase(){
            GameBoard.Instance().phase = GameTerms.Phase.Calculation;
            GameBoard.Instance().CalcuateCollision();
            GameBoard.Instance().CalculateConseqence();
            gameEvent.Raise(GameEvent.CALCULATIION_PHASE_OVER);
        }
        public virtual void ManageResult(){
            GameBoard.Instance().phase = GameTerms.Phase.Feedback;
            gameEvent.Raise(GameEvent.RESULT_PHASE_OVER);
        }
        public virtual void ManageFinishPhase(){
            GameBoard.Instance().phase = GameTerms.Phase.FinishGame;
            gameEvent.Raise(GameEvent.FINISH_PHASE_OVER);
        }
        

        /* 나중에 튜토리얼 등 특수 상황에서 확장/변경될 수 있음, virtual 선언 고려
        */
        public virtual bool CheckGameEnd(){
            return true;
        }

        public virtual void ManageGameEvent(string type, int index, int value){

        }
    }
}