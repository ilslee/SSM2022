using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure{
    public class GameItemShield : Item
    {
        
        internal int blockPower;
        internal int DefensivePower;
        internal int chargePower;

        
        public GameItemShield(int grade = 0): base(grade){
            blockPower = 2;
            DefensivePower = 1;
            chargePower = 1;
        }
        /*
        public virtual GameTerms.Motion GetShieldMotion(int characterIndex){
            GameTerms.Motion m = GameTerms.Motion.None;
            GamePlayData data = GameBoard.GetLastGamePlayData(characterIndex);
            
            //-- Check Errors before proceed
            if(data == null){
                GameItemShieldError(0);
                return m;    
            } else if(data.pose != GameTerms.Pose.Shield){
                GameItemShieldError(1);
                return m;    
            }

            switch(data.poseConseqence){
                case GameTerms.Consequence.None:
                GameItemShieldError(2);
                break;
                case GameTerms.Consequence.Win:
                m = GameTerms.Motion.Block;
                break;
                case GameTerms.Consequence.Lose:
                m = GameTerms.Motion.Defence;
                break;
                case GameTerms.Consequence.Draw:
                m = GameTerms.Motion.Defence;
                break;
                case GameTerms.Consequence.DrawWin:
                m = GameTerms.Motion.Charge;
                break;
                case GameTerms.Consequence.DrawLose:
                m = GameTerms.Motion.Defence;
                break;
            }
            return m;
        }

        public virtual int CalcShieldPower(int characterIndex){
            int p = 0;
            GamePlayData data = GameBoard.GetLastGamePlayData(characterIndex);
            
            //-- Check Errors before proceed
            if(data == null){
                GameItemShieldError(0);
                return p;    
            }else if(data.motion == GameTerms.Motion.None){
                GameItemShieldError(3);
                return p;   
            }

            switch(data.motion){
                case GameTerms.Motion.Block:
                // p = blockPower + data.energy;
                break;
                case GameTerms.Motion.Defence:
                p = DefensivePower;
                break;
                case GameTerms.Motion.Charge:
                p = chargePower;
                break;
            }
            return p;
        }

        internal void GameItemShieldError(int errorIndex){
            switch(errorIndex){
                case 0:
                Debug.LogError("GameItemShield.GetShieldMotion : No Game Data");
                break;
                case 1:
                Debug.LogError("GameItemShield.GetShieldMotion : Pose is not available.");
                break;
                case 2:
                Debug.LogError("GameItemShield.GetShieldMotion : No Conseqence");
                break;
                case 3:
                Debug.LogError("GameItemShield.CalcShieldPower : Motion is Not Valid");
                break;
            }
            
        }
        */
    }
}