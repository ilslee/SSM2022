using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ssm.game.structure;
using System;
using UnityEngine.Rendering;
namespace ssm.game.appearance{
    public class GameCharacterTest2 : MonoBehaviour
    {
        public GameBoard gameBoard;
        public int targtCharacterIndex;
        public TMP_Text characterName;
        public TMP_Text motion;
        public TMP_Text power;
        public TMP_Text damage;
        public TMP_Text previousStat;
        public TMP_Text currentStat;
        public TMP_Text other;

        private Character GetCharacter(){
            if(targtCharacterIndex == 1){
                return gameBoard.character1;
            }else{
                return gameBoard.character2;

            }
        }
        private void UpdateText(){
            /*
            Debug.Log("<GameCharacterTest2.UpdateText>");
            TokenList curStat = GetCharacter().GetLastPlayData().token;
            TokenList prevStat = GetCharacter().GetLastPlayData(1).token;

            characterName.text = "Character " + targtCharacterIndex;
            motion.text = GetCharacter().GetLastPlayData().motion.ToString();

            string powerText = "";
            // Debug.Log("GameCharacterTest2.UpdateText curStat : " + curStat.ToString());
            if(curStat.Has(Token.Category.Power, Token.Behaviour.Offensive) == true){
                powerText = "O-Pow: " + curStat.Find(Token.Category.Power, Token.Behaviour.Offensive).value0.ToString();
            } 
            else if(curStat.Has(Token.Category.Power, Token.Behaviour.Defensive) == true) {
                powerText = "D-Pow: " + curStat.Find(Token.Category.Power, Token.Behaviour.Defensive).value0.ToString();;
            }
            else powerText = "No Pow: ";
            
            power.text = powerText;

            
            string damageGiveText = "D-Give : ";
            damageGiveText += curStat.Find(Token.Category.Damage, Token.Behaviour.Give).value0.ToString();
            string damageTakeText = "D-Take : ";
            float damageTake = curStat.Find(Token.Category.Damage, Token.Behaviour.Take).value0;;
            float damageLoss = curStat.Find(Token.Category.Damage, Token.Behaviour.Loss).value0;;
            float damageReduce = curStat.Find(Token.Category.Damage, Token.Behaviour.Reduce).value0;;
            float actualDamage = Mathf.Max(damageTake - damageLoss - damageReduce, 0f);
            damageTakeText += actualDamage.ToString() + " (" + damageLoss.ToString() + ", " + damageReduce.ToString() + ")";
            
            string damageText = damageGiveText + "\n" + damageTakeText;
            
            damage.text = damageText;
            
            

            string GetStatString(Token.Category c, bool isPrevious = false){
                string returnVal = "";
                int playdataIndex = isPrevious == true ? 1 : 0 ;
                string curStat = GetCharacter().GetLastPlayData(playdataIndex).token.Find(c, Token.Behaviour.Current).value0.ToString();
                Token.Behaviour gainBhv = isPrevious == true ? Token.Behaviour.GainNextTurn : Token.Behaviour.Gain ;
                Token.Behaviour lossBhv = isPrevious == true ? Token.Behaviour.LossNextTurn : Token.Behaviour.Loss ;
                float statGain =  GetCharacter().GetLastPlayData(playdataIndex).token.Find(c, gainBhv).value0;
                float statLoss =  GetCharacter().GetLastPlayData(playdataIndex).token.Find(c, lossBhv).value0;
                // Debug.Log("GameCharacterTest2.UpdateText.GetStatString : " + c.ToString() + " << + " + statGain.ToString() + " - " + statLoss.ToString()    );
                string statModifiedText = (statGain - statLoss == 0f) ?  "" : " (" + (statGain - statLoss).ToString() + ")";
                if(isPrevious == true) returnVal = curStat + statModifiedText;
                else returnVal = statModifiedText + curStat;
                return returnVal;
            }
            

            string prevStatText = GetStatString(Token.Category.Health, true);
            prevStatText += "\n" + GetStatString(Token.Category.Energy, true);
            prevStatText += "\n" + GetStatString(Token.Category.SwordPower, true);
            prevStatText += "\n" + GetStatString(Token.Category.ShieldPower, true);
            previousStat.text = prevStatText;

            string curStatText = GetStatString(Token.Category.Health);
            curStatText += "\n" + GetStatString(Token.Category.Energy);
            curStatText += "\n" + GetStatString(Token.Category.SwordPower);
            curStatText += "\n" + GetStatString(Token.Category.ShieldPower);
            currentStat.text = curStatText;

            //TODO: Other
            string otherText = "";
            bool isFirstItem = true;
            foreach (Token item in curStat)
            {
                if(CheckOtherBan(item.category, item.behaviour) == false){
                    if(isFirstItem == true) isFirstItem = false;
                    else otherText += " / ";
                    otherText += item.ToString();
                }
            }
            bool CheckOtherBan(Token.Category t, Token.Behaviour c){
                if(t == Token.Category.Health && c == Token.Behaviour.Current) return true;
                if(t == Token.Category.Energy && c == Token.Behaviour.Current) return true;
                // if(t == Token.Category.Energy && c == Token.Behaviour.Loss) return true;
                if(t == Token.Category.SwordPower && c == Token.Behaviour.Current) return true;
                if(t == Token.Category.ShieldPower && c == Token.Behaviour.Current) return true;
                if(t == Token.Category.Power && c == Token.Behaviour.Offensive) return true;
                if(t == Token.Category.Power && c == Token.Behaviour.Defensive) return true;
                if(t == Token.Category.Damage && c == Token.Behaviour.Give) return true;
                if(t == Token.Category.Damage && c == Token.Behaviour.Take) return true;
                if(t == Token.Category.Damage && c == Token.Behaviour.Loss) return true;
                return false; 
            }

            other.text = otherText;
            */
        }
        public void ManageGameEvent(string type, int index, int value){
             switch(type){
                case GameEvent.RESULT_PHASE_OVER:
                UpdateText();
                break;
             }
        }
    }
}