using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/*
namespace ssm.game.structure{
    public class GameToken 
    {
        
        public GameTerms.TokenType type = GameTerms.TokenType.None;
        public float value = 0f;
        public GameToken(float v = 0f){
            value = v;
        }
        public virtual void OnGameStart(Character me, Character other){
        }
        public virtual void OnTurnStart(Character me, Character other){
        }
        public virtual void OnExpectation(Character me, Character other, GameTerms.Motion m){
        }
        public virtual void OnCalculation(Character me, Character other){
        }
        //public virtual void OnCombine(Character me, Character other){
        //}
        public virtual void Combine(GameToken t){
            value += t.value;            
        }
    }

    public class GameTokenList : List<GameToken>{
        public void Calc(){

        }

        public void OnGameStart(Character me, Character other){
            this.Sort((x,y) => GetGameTokenOrder(x.type).CompareTo(GetGameTokenOrder(y.type)));
            int GetGameTokenOrder(GameTerms.TokenType t){
                return 0;
                // switch (t)
                // {
                //     case GameTerms.TokenType.Health : return 0;
                //     case GameTerms.TokenType.Energy : return 1;
                //     default: return int.MaxValue; // 다른 경우에는 가장 큰 값으로 처리
                // }
            }
            foreach(GameToken i in this){
                i.OnGameStart(me, other);
            }
        }
        public void OnTurnStart(Character me, Character other){

        }
       
        public void OnCalculation(){

        }
        public float GetGameTokenValue(GameTerms.TokenType t){
            GameToken foundToken = this.Find(x=>x.type == t);
            if(foundToken == null){
                return 0f;
            }else return foundToken.value;
        }
        public bool Has(GameToken t){
            GameToken foundToken = this.Find(x => x.type == t.type);
            if(foundToken == null){
                return false;
            }else return true;
        }
        public void Combine(GameToken t){
            GameToken foundToken = this.Find(x=>x.type == t.type);
            if(foundToken.type != t.type){
                this.Add(t);
            }else{

            }
        }


    }

    public class Expectation : List<GameTokenList>{
        public void Reset(Character me, Character other){
            this.Clear();
            this.Add(new GameTokenList()); // None
            this.Add(ExpectAttack(me, other)); // Attack
            this.Add(ExpectStrike(me, other)); // Strike
            this.Add(ExpectDefence(me, other)); // Defence 
            this.Add(ExpectCharge(me, other)); // Charge
            this.Add(ExpectAvoid(me, other)); // Avoid
            this.Add(ExpectTaunt(me, other)); // Taunt
            
        }
        public GameTokenList CloneExpectationViaMotion(GameTerms.Motion m){
            switch(m){
                case GameTerms.Motion.Attack:
                return this[1];
                case GameTerms.Motion.Strike:
                return this[2];
                case GameTerms.Motion.Defence:
                return this[3];
                case GameTerms.Motion.Charge:
                return this[4];
                case GameTerms.Motion.Avoid:
                return this[5];
                case GameTerms.Motion.Taunt:
                return this[6];
            }
            return this[0];
        }
        private GameTokenList ExpectAttack(Character me, Character other){
            GameTokenList returnVal = new GameTokenList();
            float value = me.token.GetGameTokenValue(GameTerms.TokenType.AttackPower);
            returnVal.Add(new BasePower(value));
            returnVal.Add(new OffensivePower(value));
            //TODO : AdditionalPower Sword & Attack
            return returnVal;
        }

        private GameTokenList ExpectStrike(Character me, Character other){
            GameTokenList returnVal = new GameTokenList();
            float value = me.token.GetGameTokenValue(GameTerms.TokenType.StrikePower);
            returnVal.Add(new BasePower(value));

            float conversionRate = me.token.GetGameTokenValue(GameTerms.TokenType.StrikeConversionRate);
            float conversionMax = me.token.GetGameTokenValue(GameTerms.TokenType.StrikeConversionMax);
            float currnetE = me.GetLastPlayData().token.GetGameTokenValue(GameTerms.TokenType.Energy);
            float conversionE = Mathf.Min(conversionMax, currnetE);
            float conversionValue = Mathf.Floor(conversionRate * conversionE);
            returnVal.Add(new EnergyPower(conversionValue));
            //TODO : AdditionalPower Sword & Strike

            returnVal.Add(new OffensivePower(value + conversionValue));
            return returnVal;
        }

        private GameTokenList ExpectDefence(Character me, Character other){
            GameTokenList returnVal = new GameTokenList();
            float value = me.token.GetGameTokenValue(GameTerms.TokenType.DefencePower);
            returnVal.Add(new BasePower(value));
            returnVal.Add(new DefensivePower(value));
            //TODO : AdditionalPower Shield & Defence
            return returnVal;
        }   

        private GameTokenList ExpectCharge(Character me, Character other){
            GameTokenList returnVal = new GameTokenList();
            float value = me.token.GetGameTokenValue(GameTerms.TokenType.ChargePower);
            returnVal.Add(new BasePower(value));

            float conversionRate = me.token.GetGameTokenValue(GameTerms.TokenType.ChargeConversionRate);
            float conversionMax = me.token.GetGameTokenValue(GameTerms.TokenType.ChargeConversionMax);
            float currnetE = me.GetLastPlayData().token.GetGameTokenValue(GameTerms.TokenType.Energy);
            float conversionE = Mathf.Min(conversionMax, currnetE);
            float conversionValue = Mathf.Floor(conversionRate * conversionE);
            returnVal.Add(new EnergyPower(conversionValue));
            //TODO : AdditionalPower Sword & Attack

            returnVal.Add(new OffensivePower(value + conversionValue));
            return returnVal;
        }

        private GameTokenList ExpectAvoid(Character me, Character other){
            GameTokenList returnVal = new GameTokenList();
            float value = me.token.GetGameTokenValue(GameTerms.TokenType.AvoidPower);
            returnVal.Add(new BasePower(value));

            float conversionRate = me.token.GetGameTokenValue(GameTerms.TokenType.MoveConversionRate);
            float conversionE = me.GetLastPlayData().token.GetGameTokenValue(GameTerms.TokenType.Energy);
            float conversionValue = Mathf.Floor(conversionRate * conversionE);
            returnVal.Add(new EnergyPower(conversionValue));
            //TODO : AdditionalPower Sword & Attack

            returnVal.Add(new DefensivePower(value + conversionValue));
            return returnVal;
        }

        private GameTokenList ExpectTaunt(Character me, Character other){
            GameTokenList returnVal = new GameTokenList();
            float value = me.token.GetGameTokenValue(GameTerms.TokenType.TauntPower);
            returnVal.Add(new BasePower(value));

            float conversionRate = me.token.GetGameTokenValue(GameTerms.TokenType.MoveConversionRate);
            float conversionE = me.GetLastPlayData().token.GetGameTokenValue(GameTerms.TokenType.Energy);
            float conversionValue = Mathf.Floor(conversionRate * conversionE);
            returnVal.Add(new EnergyPower(conversionValue));
            //TODO : AdditionalPower Sword & Attack

            returnVal.Add(new DefensivePower(value + conversionValue));
            return returnVal;
        }
    }
}
*/