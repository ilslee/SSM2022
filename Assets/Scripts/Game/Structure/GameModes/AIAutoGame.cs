using System.Collections;
using System.Collections.Generic;
using ssm.data;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using ssm.data.league;
namespace ssm.game.structure{
    public class AIAutoGame : Game
    {
        public int gameMax = 0;
        private int gameCurrent = 0;
        public AIAutoGameTester appearacne;
        private bool isGameStart;

        public AIGame aiGameData;
        public void Start(){
            gameCurrent = 0;
            isGameStart = false;
        }
        public void Update(){
            // Debug.Log("AIAutoGame.Update - isGameStart : " + isGameStart.ToString() + " / gameID : " + gameCurrent.ToString());
            if(isGameStart == true && gameCurrent < gameMax){
                
                Debug.Log("------------------------------ AI Auto Game: Game number [" + gameCurrent.ToString() + "]-------------------------");
                gameCurrent++;
            }
        }
        public override void PrepareGame()
        {
            League curLeague = ssmData.leagues[ssmData.currentWorld];
            if(curLeague == null){
                Debug.LogError("AIAutoGame.PrepareGame : No league data found!");
                return;
            }
            GameBoard.Instance().Reset();
            GameBoard.Instance().maxTurn = curLeague.maxTurn;
            GameBoard.Instance().currentTurn = 0;
            GameBoard.Instance().turnTime = curLeague.turnTime;

            GameBoard.Instance().Initialize(aiGameData.opponent,aiGameData.opponent2);
            GameLogDisplayer.LogGamePreparation("AIAutoGame");
        }
       
        internal override void ManageAnimationCalc2(){
            Debug.LogError("AIAutoGame.ManageAnimationCalc2");
            if(CheckGameEnd() == true) EndPhase(GameEvent.GAME_END_START, 1);
            //else // 입력 대기
        }
        public override bool CheckGameEnd(){
            Debug.Log("--Check Game End");
            if( GameBoard.Instance().currentTurn >= GameBoard.Instance().maxTurn){
                return true;
            }else if(CheckCharacterDefeat() == true){
                return true;
            }
            bool CheckCharacterDefeat(){
                if(GameBoard.Instance().FindCharacter(1).GetLastPlayData().Find(GameTerms.TokenType.HPCurrent).value0 <= 0f) return true;
                else if(GameBoard.Instance().FindCharacter(2).GetLastPlayData().Find(GameTerms.TokenType.HPCurrent).value0 <= 0f) return true;
                else return false;
            }
            return false;
        }
/*
        public override void ManageFinishPhase(){
            GameBoard.Instance().phase = GameTerms.Phase.FinishGame;
            float char1HP = GameBoard.Instance().FindCharacter(1).GetLastPlayData().Find(GameTerms.TokenType.HPCurrent).value0;
            float char2HP = GameBoard.Instance().FindCharacter(2).GetLastPlayData().Find(GameTerms.TokenType.HPCurrent).value0;

            float char1Score = 0f;
            float char2Score = 0f;
            if(char1HP > char2HP) char1Score = char1HP - char2HP;
            else if(char2HP > char1HP) char2Score = char2HP - char1HP;
            float turnLeft = (float)(GameBoard.Instance().maxTurn - GameBoard.Instance().currentTurn);
            float timeModifier = turnLeft / (float)GameBoard.Instance().maxTurn;
            char1Score *= timeModifier;
            char2Score *= timeModifier;
            Debug.Log("[Score] " + char1Score.ToString() + " : " + char2Score.ToString());
            appearacne.UpdateText(char1Score, char2Score, gameCurrent);
            gameEvent.Raise(GameEvent.START_FINISH_PHASE);
        }
*/
        
    }
}