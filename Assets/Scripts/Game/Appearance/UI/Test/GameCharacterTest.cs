using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using TMPro;
using ssm.game.structure;
using ssm.game.structure.token;
namespace ssm.game.appearance{
    public class GameCharacterTest : MonoBehaviour
    {
        // public GameEvent gameEvent;
        public GameBoard gameBoard;
        public int targtCharacterIndex;
        public TMP_Text characterName;
        public TMP_Text statHealth;
        public TMP_Text statEnergy;
        public TMP_Text statAttack;
        public TMP_Text statDefence;
        public TMP_Text motion;
        public TMP_Text power;
        public TMP_Text damage;
        public TMP_Text damagedHealth;
        public TMP_Text damagedEnergy;
        public TMP_Text damagedAttack;
        public TMP_Text damagedDefence;
        public TMP_Text damagedOther;
        public TMP_Text recoveryHealth;
        public TMP_Text recoveryEnergy;
        public TMP_Text recoveryAttack;
        public TMP_Text recoveryDefence;
        public TMP_Text recoveryOther;
        
        private Character GetCharacter(){
            if(targtCharacterIndex == 1){
                return gameBoard.character1;
            }else{
                return gameBoard.character2;

            }
        }
        private string GetStat(){
            // string value = "N.D.";
            // float val = GetCharacter().GetLastPlayData().token.Find(cat, GameToken.Behaviour.Current).value0;
            // return val.ToString();
            return "";
        }

        private string GetDamage(GameTerms.MTType type){
            // int otherCount = 0;
            int value = 0;
            /*
            foreach(var item in GetCharacter().GetLastPlayData().modifier){
                if(IsMainCategory(item.type) == true){
                    if(item.type == type){
                        switch(item.how){
                            case GameTerms.MTHow.LossNextTurn:
                            case GameTerms.MTHow.Loss:
                            case GameTerms.MTHow.Decline:
                            value += item.value;
                            break;
                        }
                    }
                }
                else{
                    otherCount ++;
                }                
            }
            */
            return value.ToString();
            // if(value > 0) return value.ToString();
            // else return "N/A";
        }
        private bool IsMainCategory(GameTerms.MTType t){
            if(t == GameTerms.MTType.Health || t == GameTerms.MTType.Energy || t == GameTerms.MTType.SwordPower  || t == GameTerms.MTType.ShieldPower ){
                return true;      
            }else return false;
        }
        private string GetRecovery(GameTerms.MTType type){
            // int otherCount = 0;
            int value = 0;
            /*
            foreach(var item in GetCharacter().GetLastPlayData().modifier){
                if(IsMainCategory(item.type) == true){
                    if(item.type == type){
                        switch(item.how){
                            case GameTerms.MTHow.GainNextTurn:
                            case GameTerms.MTHow.Recover:
                            value += item.value;
                            break;
                        }
                    }
                }
                else{
                    otherCount ++;
                }                
            }
            */
            return value.ToString();
        }

        public void ManageGameEvent(string type, int index, int value){
            switch(type){
                case GameEvent.START_PHASE_OVER:
                //게임 시작 : 캐릭터 이름, 
                characterName.text = "Character " + targtCharacterIndex;
                statHealth.text = GetStat();
                statEnergy.text = GetStat();
                statAttack.text = GetStat();
                statDefence.text = GetStat();
                break;
                // case GameEvent.READY_PHASE_OVER:
                // break;
                // case GameEvent.POSE_PHASE_OVER:
                // break;

                case GameEvent.CALCULATIION_PHASE_OVER:
                /*
                // case GameEvent.FINISH_PHASE_OVER:
                statHealth.text = GetStat(GameToken.Category.Health);
                statEnergy.text = GetStat(GameToken.Category.Energy);
                statAttack.text = GetStat(GameToken.Category.SwordPower);
                statDefence.text = GetStat(GameToken.Category.ShieldPower);
                motion.text = GetCharacter().GetLastPlayData().motion.ToString();
                
                string powerText = "";
                GameToken powerST = GetCharacter().GetLastPlayData().token.Find(GameToken.Category.Power);
                if(powerST.behaviour == GameToken.Behaviour.Offensive) powerText += "O: ";
                else if(powerST.behaviour == GameToken.Behaviour.Defensive) powerText += "D: ";
                else powerText += "No Power: ";
                powerText += powerST.value0.ToString();
                power.text = powerText;
                // damage.text = GetCharacter().GetLastPlayData().modifier.FindModifierToken(GameTerms.MTType.Damage).value.ToString();
                string damageText = "";
                GameToken damageST = GetCharacter().GetLastPlayData().token.Find(GameToken.Category.Damage);
                if(damageST.behaviour == GameToken.Behaviour.Give) damageText += "G: ";
                else if(damageST.behaviour == GameToken.Behaviour.Take) damageText += "T: ";
                else damageText += "No Damage: ";
                damage.text = damageText;
                */
                // damagedHealth.text = GetDamage(GameTerms.MTType.Health);
                // damagedEnergy.text = GetDamage(GameTerms.MTType.Energy);
                // damagedAttack.text = GetDamage(GameTerms.MTType.SwordPower);
                // damagedDefence.text = GetDamage(GameTerms.MTType.ShieldPower);
                // damagedOther.text = GetDamage(GameTerms.MTType.None);
                // recoveryHealth.text = GetRecovery(GameTerms.MTType.Health);
                // recoveryEnergy.text = GetRecovery(GameTerms.MTType.Energy);
                // recoveryAttack.text = GetRecovery(GameTerms.MTType.SwordPower);
                // recoveryDefence.text = GetRecovery(GameTerms.MTType.ShieldPower);
                // recoveryOther.text = GetRecovery(GameTerms.MTType.None);
                
                break;
                // case GameEvent.FEEDBACK_PHASE_OVER:
                // break;
                // case GameEvent.START_FINISH_PHASE:
                // break;

            }
        }
    }
}