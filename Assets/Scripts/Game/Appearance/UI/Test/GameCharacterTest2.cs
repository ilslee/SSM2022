using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ssm.game.structure;
using ssm.game.structure.token;
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

        private bool isInitiated = false;
        private Character GetCharacter(){
            if(targtCharacterIndex == 1){
                return gameBoard.character1;
            }else{
                return gameBoard.character2;

            }
        }
        private void InitText(){
            characterName.text = "Character " + targtCharacterIndex;
        }
        private void UpdateText(){
            Debug.Log("<GameCharacterTest2.UpdateText>");
            
            PlayData current = GameBoard.Instance().FindCharacter(targtCharacterIndex).GetLastPlayData();
            PlayData prev = GameBoard.Instance().FindCharacter(targtCharacterIndex).GetLastPlayData(1);
            
            motion.text = current.motion.ToString();
            //Power
            float powerVal = (current.Find(GameTerms.TokenType.TotalPower) as TotalPower).value0;
            bool isOffensive = (current.Find(GameTerms.TokenType.TotalPower) as TotalPower).isOffensive;
            string powerText = isOffensive == true ? "O-POW : " : "D-POW : ";
            powerText += powerVal.ToString();
            power.text = powerText;

            //Damage
            bool hasDamage = current.Has(GameTerms.TokenType.Damage);
            string damageText = "";
            if(hasDamage == true){
                float damageValue = (current.Find(GameTerms.TokenType.Damage)as Damage).value0;
                bool isGiving = (current.Find(GameTerms.TokenType.Damage)as Damage).isGivingDamage;
                if(isGiving == true) damageText = "Give D : " + damageValue.ToString();
                else  damageText = "Take D : " + damageValue.ToString();
            }else{
                damageText = "No Damage";
            }
            damage.text = damageText;

            //PrevStat
            float prevHP = prev.Find(GameTerms.TokenType.HPCurrent).value0;
            float prevEP = prev.Find(GameTerms.TokenType.EPCurrent).value0;
            previousStat.text = prevHP + "\n" + prevEP;
            //CurrnentStat
            float curHP = current.Find(GameTerms.TokenType.HPCurrent).value0;
            float curEP = current.Find(GameTerms.TokenType.EPCurrent).value0;
            currentStat.text = curHP + "\n" + curEP;
        }
        public void ManageGameEvent(string type, int index, int value){
            switch(type){
                case GameEvent.START_PHASE_OVER:
                InitText();

                break;
                case GameEvent.RESULT_PHASE_OVER:
                UpdateText();
                break;
            }
        }
    }
}