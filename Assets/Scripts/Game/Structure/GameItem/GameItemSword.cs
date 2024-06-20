using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure{
    public class GameItemSword : Item
    {
        
        internal int fastOffensivePower;
        internal int OffensivePower;
        internal int strikePower;

        
        public GameItemSword(int grade = 0): base(grade){
            fastOffensivePower = 1;
            OffensivePower = 1;
            strikePower = 1;
        }
        /*
        public virtual GameTerms.Motion GetSwordMotion(int characterIndex){
            GameTerms.Motion m = GameTerms.Motion.None;
            GamePlayData data = GameBoard.GetLastGamePlayData(characterIndex);
            
            //-- Check Errors before proceed
            if(data == null){
                GameItemSwordError(0);
                return m;    
            } else if(data.pose != GameTerms.Pose.Sword){
                GameItemSwordError(1);
                return m;    
            }

            switch(data.poseConseqence){
                case GameTerms.Consequence.None:
                GameItemSwordError(2);
                break;
                case GameTerms.Consequence.Win:
                m = GameTerms.Motion.FastAttack;
                break;
                case GameTerms.Consequence.Lose:
                m = GameTerms.Motion.Strike;
                break;
                case GameTerms.Consequence.Draw:
                m = GameTerms.Motion.Attack;
                break;
                case GameTerms.Consequence.DrawWin:
                m = GameTerms.Motion.Attack;
                break;
                case GameTerms.Consequence.DrawLose:
                m = GameTerms.Motion.Attack;
                break;
            }
            return m;
        }

        public virtual int CalcSwordPower(int characterIndex){
            int p = 0;
            GamePlayData data = GameBoard.GetLastGamePlayData(characterIndex);
            
            //-- Check Errors before proceed
            if(data == null){
                GameItemSwordError(0);
                return p;    
            }else if(data.motion == GameTerms.Motion.None){
                GameItemSwordError(3);
                return p;   
            }

            switch(data.motion){
                case GameTerms.Motion.FastAttack:
                p = fastOffensivePower;
                break;
                case GameTerms.Motion.Attack:
                p = OffensivePower;
                break;
                case GameTerms.Motion.Strike:
                // p = strikePower + data.energy;
                break;
            }
            return p;
        }

        internal void GameItemSwordError(int errorIndex){
            switch(errorIndex){
                case 0:
                Debug.LogError("GameItemSword.GetSwordMotion : No Game Data");
                break;
                case 1:
                Debug.LogError("GameItemSword.GetSwordMotion : Pose is not available.");
                break;
                case 2:
                Debug.LogError("GameItemSword.GetSwordMotion : No Conseqence");
                break;
                case 3:
                Debug.LogError("GameItemSword.CalcSwordPower : Motion is Not Valid");
                break;
            }
            
            
        }
        */
    }
}