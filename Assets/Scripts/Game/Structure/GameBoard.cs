using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ssm.data;
using System;
using ssm.game.structure.token;
using UnityEditor.PackageManager.Requests;
namespace ssm.game.structure{
        
    public class GameBoard {
       
        private static GameBoard staticGameBoard; 
        public int currentTurn = 0;
        public int maxTurn = 0;
        public float turnTime = 0f;
        public GameTerms.Phase phase = GameTerms.Phase.None;
        
        //Character 
        public Character character1;
        public Character character2;
        
        public static GameBoard Instance(){
            if(staticGameBoard == null) staticGameBoard = new GameBoard();
            return staticGameBoard; 
        } 
        public Character FindCharacter(int id){
            if(id == 1) return character1;
            else if (id == 2) return character2;
            else {
                Debug.LogError("GameBoard.FindCharacter : index ERROR " + id);
                return null;
            }
        }
        public Character FindOpponent(int id){
            if(id == 1) return character2;
            else if (id == 2) return character1;
            else return null;
        }
        //초기 값 세팅
        public void Initialize(PlayableCharacter c1, PlayableCharacter c2){
            // Clone & Convert Character data
            character1 = new Character(c1,1);   
            character2 = new Character(c2,2);  
            //Init Tokens
            character1.InitializeTokens(c1);
            character2.InitializeTokens(c2);
        }
       
        //------------------------------[Ready]------------------------------
        public void AddPlayData(){
            character1.AddPlayData();
            character2.AddPlayData();
        }

        public void CalculateOnRecovery(){
            character1.ApplyTurnStart();
            character2.ApplyTurnStart();
            
        }
        public void CalculateExpectations(){
            character1.ExpectPower();
            character2.ExpectPower();
        }
        //------------------------------[Pose]------------------------------
        public void ProcessMotions(){
            //Getting Motion From BP
            character1.GetLastPlayData().motion = character1.bpManager.Calculate(character1, character2);
            character2.GetLastPlayData().motion = character2.bpManager.Calculate(character2, character1);

            //Get GameToken via Motion
            
        }
        

        //------------------------------[Calculate]------------------------------
        public void CalcuateCollision(){
            character1.CalcuateCollision();
            character2.CalcuateCollision();
        }
        
       
        
        public void CalculateConseqence(){
            //Finalize Power : 최종 파워 결정 - Avoid는 Adaptive라는 특성이 있어 한차례 나중에 계산
            if(character1.GetLastPlayData().motion != GameTerms.Motion.Avoid) character1.FinalizePower();
            if(character2.GetLastPlayData().motion != GameTerms.Motion.Avoid) character2.FinalizePower();
            if(character1.GetLastPlayData().motion == GameTerms.Motion.Avoid) character1.FinalizePower();
            if(character2.GetLastPlayData().motion == GameTerms.Motion.Avoid) character2.FinalizePower();
            
            //ComparePower : Damage, Consumption 결정
            // string ttPower = "[Check Total Power]";
            // ttPower += "\n Character 1 : " + character1.SearchToken(GameTerms.TokenType.TotalPower).ToString();
            // ttPower += "\n Character 2 : " + character2.SearchToken(GameTerms.TokenType.TotalPower).ToString();
            // Debug.Log(ttPower);
            character1.ComparePower();
            character2.ComparePower();
            
            //Consumption : Modify Stats
            //OnConsumption은 priority로 처리
            character1.ApplyConsumption();
            character2.ApplyConsumption();

            //CalculateDamage : Modify Stats
            //OnDamage은 priority로 처리
            character1.ApplyDamage();
            character2.ApplyDamage();

            
            //CalculateFeedback
            character1.Feedback();
            character2.Feedback();

            //Log Report
            Report(character1);
            Report(character2);
            void Report(Character c){
                string returnValue = "<Log Report> \n";
                returnValue += "Motion : " + c.GetLastPlayData().motion.ToString()+"\n";
                returnValue += "Power : " + c.GetLastPlayData().Find(GameTerms.TokenType.TotalPower).value0.ToString();
                Debug.Log(returnValue);
            }
        }

        public void Reset(){
            GameTerms.Phase phase = GameTerms.Phase.None;
            currentTurn = 0;
            maxTurn = 0;
            turnTime = 0f;
            character1 = null;
            character2 = null;
        }
    }
    
    

   


}