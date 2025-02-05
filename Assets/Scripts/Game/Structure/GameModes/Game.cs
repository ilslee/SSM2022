using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
namespace ssm.game.structure{
    /* Game
    게임 흐름을 제어 가능하도록 구조만 가지고 있음 + 애니메이션을 위한 흐름도 제어
    이를 상속하는 하위 클래스에서 구체적인 게임 흐름을 제어
    각 Phase는 기본적으로 Start-(Announce)-Timer(Animation)-End로 구성됨
    Start : Phase 설정, 데이터 처리(ManageBlahBlah) Timer 스타트,혹은 End로 진행
    (Announce) : Game외부에서 해당 Phase에 맞는 역할을 수행하는 트리거. 이벤트명은 빈칸으로 표기
    Timer : 필요한 경우 애니메이션 처리, 애니메이션이 없으면 바로 End로 진행
    End : 다음 지점으로 가는 Event발생

    GameStart
    TransitEnter : Intro Animation (1)
    Countdown(3+0.05)
        TurnReady
            Animation_Idle(Loop)
        TurnCalculate : Calc result, CheckGameEnd
            Animation_Calc1 : Basic Action(1)
            Animation_Calc2 : Follow-up Action(1)
        TurnCheckGameEnd
        ...
            (Optional)
            Animation_End1 : To Idle or FallDown(1)
            Animation_End2 : Dead or Victory(Loop)
    GameEnd
    TransitExit : Outro Animation (1)
    */
    public class Game : MonoBehaviour
    {
        public GameEvent gameEvent;
        public SSMGameData ssmData;
        public bool displayLog = true;
        public float gameSpeed = 1f;
        private float timeUnit = 1f; // 애니메이션 한 동작이 일어나는 단위 시간 (s)
        private float timer = 0f;
        private float currentTime = 0f;
        private bool isTimerOn = false;
        private string gameEventStandBy;
        private void Start(){

        }
        private void Update(){
            if(isTimerOn == true)OnTimerUpdate();
        }
        
        internal void StartPhase(GameTerms.Phase p){
            GameBoard.Instance().phase = p;
            switch(p){
                case GameTerms.Phase.Game_Start:
                    
                break;
                
            }
        }
        internal void EndPhase(string eventString, float t = -1f){
            if(t < 0) gameEvent.Raise(eventString);
            else{
                gameEventStandBy = eventString;
                StartTimer(t);
            }            
        }
        private void StartTimer(float t){
            timer = t+0.05f;
            currentTime = 0f;
            isTimerOn = true;
        }

        private void OnTimerUpdate(){
            //이벤트를 보내는가
            currentTime += Time.deltaTime * gameSpeed;
            if(currentTime >= timer) EndTimer();
        }

        private void EndTimer(){
            // Debug.Log("Game.EndTimer : " + gameEventStandBy.ToString());
            isTimerOn = false;
            EndPhase(gameEventStandBy);
        }
        public virtual void ManageGameEvent(string type, float value){
            switch(type){
                case GameEvent.GAME_START_START:
                ManageGameStart();
                break;
                case GameEvent.GAME_START_END:
                ManageTransitionEnter();
                break;
                case GameEvent.TRANSITION_ENTER_END:
                ManageCountdown();
                break;
                case GameEvent.COUNTDOWN_END:
                case GameEvent.TURN_READY_START:
                ManageTurnReady();
                break;                
                case GameEvent.TURN_READY_END:
                //Wait For Input
                break;
                case GameEvent.TURN_CALCULATE_START:
                ManageTurnCalculate();
                break;
                case GameEvent.ANIMATION_CALC1:
                ManageAnimationCalc1();
                break;
                case GameEvent.ANIMATION_CALC2:
                ManageAnimationCalc2();
                break;
                case GameEvent.GAME_END_START:
                ManageGameEnd();
                break;
                case GameEvent.GAME_END_END:
                ManageTransitionExit();
                break;
            }
        }


        public virtual void PrepareGame(){

            // GameBoard.Instance().maxTurn = maxTurn;
            // GameBoard.Instance().currentTurn = 0;
            // GameBoard.Instance().turnTime = turnTime;
            // GameBoard.Instance().Initialize(c1,c2);
            // GameLogDisplayer.LogGamePreparation();
        }

        
        // public void RunTurn(){}

        // 턴 흐름 관리. 하위 클래스에서 변경, 추가 예정 ------------------------------
        
        //게임 처음 시작시
        public virtual void ManageGameStart(){
            if(displayLog == true){Debug.Log("\n [[[ GAME START ]]] ------------------------------");}
            GameBoard.Instance().phase = GameTerms.Phase.Game_Start;
            //시작 준비 완료. 
            PrepareGame();
            //게임 UI 업데이트, 캐릭터 아이들 모션
            gameEvent.Raise(GameEvent.GAME_START);
            EndPhase(GameEvent.GAME_START_END);
        }
        internal void ManageTransitionEnter(){
            if(displayLog == true){Debug.Log("\n [[Transition Enter]] --------------------");}
            GameBoard.Instance().phase = GameTerms.Phase.TransitionEnter;
            //트랜지션 애니메이션 재생(1) 시작(E)
            gameEvent.Raise(GameEvent.TRANSITION_ENTER);
            EndPhase(GameEvent.TRANSITION_ENTER_END, 1f);
        }
        internal void ManageCountdown(){
            if(displayLog == true){Debug.Log("\n [[Countdown]] --------------------");}
            GameBoard.Instance().phase = GameTerms.Phase.Countdown;
            gameEvent.Raise(GameEvent.COUNTDOWN);
            EndPhase(GameEvent.COUNTDOWN_END, 3f);
        }
        //입력 
        public virtual void ManageTurnReady(){
            if(displayLog == true){Debug.Log("\n [[Turn " + (GameBoard.Instance().currentTurn + 1).ToString() + " Ready]] --------------------");}
            GameBoard.Instance().phase = GameTerms.Phase.Turn_Ready;
            GameBoard.Instance().currentTurn ++;
            GameBoard.Instance().AddPlayData();
            GameBoard.Instance().CalculateOnRecovery();
            // GameBoard.Instance().phase = GameTerms.Phase.Turn_Ready;
            GameBoard.Instance().CalculateExpectations();
            gameEvent.Raise(GameEvent.TURN_READY);
            EndPhase(GameEvent.TURN_READY_END);
        }
        // 상호 Pose 선택        
        public virtual void ManageTurnCalculate(){
            if(displayLog == true){Debug.Log("\n [[Turn " + GameBoard.Instance().currentTurn.ToString() + " Calculate]] --------------------");}
            GameBoard.Instance().phase = GameTerms.Phase.Turn_Calculate;
            GameBoard.Instance().ProcessMotions();
            GameBoard.Instance().CalcuateCollision();
            GameBoard.Instance().CalculateConseqence();
            gameEvent.Raise(GameEvent.TURN_CALCULATE);
            EndPhase(GameEvent.ANIMATION_CALC1);
        }
        internal void ManageAnimationCalc1(){
            if(displayLog == true){Debug.Log("\n [Animation Calc 1] ----------");}
            EndPhase(GameEvent.ANIMATION_CALC2, 1);
        }
        internal virtual void ManageAnimationCalc2(){
            if(displayLog == true){Debug.Log("\n [Animation Calc 2] ----------");}
            /*
            Calc 결과값에 따라 각기 다른 애니메이션 제공
            여기서는 CheckGameEnd 결과에 따라 TurnReady 혹은 GameEnd로만 보냄
            */
            if(CheckGameEnd() == false) EndPhase(GameEvent.TURN_READY_START, 1);
            else EndPhase(GameEvent.GAME_END_START, 1);
        }
        public virtual void ManageGameEnd(){
            if(displayLog == true){Debug.Log("\n [[[ GAME END ]]] ------------------------------");}
            GameBoard.Instance().phase = GameTerms.Phase.Game_End;
            gameEvent.Raise(GameEvent.GAME_END);
            EndPhase(GameEvent.GAME_END_END);
        }
        internal void ManageTransitionExit(){
            if(displayLog == true){Debug.Log("\n [[Transition Exit]] --------------------");}
            GameBoard.Instance().phase = GameTerms.Phase.TransitionExit;
            //트랜지션 애니메이션 재생(1) 시작(E)
            gameEvent.Raise(GameEvent.TRANSITION_EXIT);
            EndPhase(GameEvent.TRANSITION_EXIT_END, 1f);
        }
        

        /* 나중에 튜토리얼 등 특수 상황에서 확장/변경될 수 있음, virtual 선언 고려
        */
        public virtual bool CheckGameEnd(){
            return true;
        }

       
    }
}