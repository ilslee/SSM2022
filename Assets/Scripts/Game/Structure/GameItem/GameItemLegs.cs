using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure{
    public class GameItemLegs : Item
    {
        internal int blitzPower;
        internal int avoidPower;
        

        
        public GameItemLegs(int grade = 0): base(grade){
            blitzPower = 0;
            avoidPower = 0;
            
        }
        /*
        public virtual GameTerms.Motion GetLegsMotion(int characterIndex){
            GameTerms.Motion m = GameTerms.Motion.None;
            GamePlayData data = GameBoard.GetLastGamePlayData(characterIndex);
            
            //-- Check Errors before proceed
            if(data == null){
                GameItemLegsError(0);
                return m;    
            } else if(data.pose != GameTerms.Pose.Move){
                GameItemLegsError(1);
                return m;    
            }

            switch(data.poseConseqence){
                case GameTerms.Consequence.None:
                GameItemLegsError(2);
                break;
                case GameTerms.Consequence.Win:
                m = GameTerms.Motion.Blitz;
                break;
                case GameTerms.Consequence.Lose:
                m = GameTerms.Motion.Avoid;
                break;
                case GameTerms.Consequence.Draw:
                m = GameTerms.Motion.Avoid;
                break;
                case GameTerms.Consequence.DrawWin:
                m = GameTerms.Motion.Blitz;
                break;
                case GameTerms.Consequence.DrawLose:
                m = GameTerms.Motion.Avoid;
                break;
            }
            return m;
        }

        public virtual int CalcLegsPower(int characterIndex){
            int p = 0;
            GamePlayData data = GameBoard.GetLastGamePlayData(characterIndex);
            
            //-- Check Errors before proceed
            if(data == null){
                GameItemLegsError(0);
                return p;    
            }else if(data.motion == GameTerms.Motion.None){
                GameItemLegsError(3);
                return p;   
            }

            switch(data.motion){
                case GameTerms.Motion.Blitz:
                // p = blitzPower + data.energy;
                break;
                case GameTerms.Motion.Avoid:
                // p = avoidPower + data.energy;
                break;
                
            }
            return p;
        }

        internal void GameItemLegsError(int errorIndex){
            switch(errorIndex){
                case 0:
                Debug.LogError("GameItemLegs.GetLegsMotion : No Game Data");
                break;
                case 1:
                Debug.LogError("GameItemLegs.GetLegsMotion : Pose is not available.");
                break;
                case 2:
                Debug.LogError("GameItemLegs.GetLegsMotion : No Conseqence");
                break;
                case 3:
                Debug.LogError("GameItemLegs.CalcLegsPower : Motion is Not Valid");
                break;
            }
            
        }
        */
    }
}