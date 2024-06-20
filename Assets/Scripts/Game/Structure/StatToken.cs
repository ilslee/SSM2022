using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
namespace ssm.game.structure{
    
    public class StatToken
    {
        public GameTerms.StatTokenType type;
        public GameTerms.StatTokenCategory category;
        public float value0;
        public float value1;

        public StatToken(GameTerms.StatTokenType t, GameTerms.StatTokenCategory c, float v0 = 0f, float v1 = 0f){
            type = t;
            category = c;
            value0 = v0;
            value1 = v1;
        }

        
    }


    public class StatTokenList : List<StatToken>{

        public void Initialize(){
            //초기화시에는 최소 4개의 StatToken이 필요하다
            if(this.Count > 0) Debug.LogError("StatTokenList.Initialize : the List already has other items of - " + this.Count);
            this.Add(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current, 0f, 0f));
            this.Add(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current, 0f, 0f));
            this.Add(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Current, 0f, 0f));
            this.Add(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Current, 0f, 0f));
            
        }
        public void Combine(StatToken st){
            foreach (StatToken item in this)
            {
                if(item.type == st.type && item.category == st.category){
                    switch(st.type){
                        default:
                        item.value0 += st.value0;
                        item.value1 += st.value1;
                        return;
                    }
                }
            }
            this.Add(new StatToken(st.type, st.category, st.value0, st.value1));
        }
        public StatToken Find(GameTerms.StatTokenType t, GameTerms.StatTokenCategory c){
            StatToken resultToken = this.Find(m => m.type == t && m.category == c);
            if(resultToken == null){
                Debug.LogError("StatTokenList.Find(2) : There is no matching type of " + t.ToString() + " & " + c.ToString() );
                return new StatToken(GameTerms.StatTokenType.None, GameTerms.StatTokenCategory.None);
            }else{
                return resultToken;
            }
        }

        public StatToken Find(GameTerms.StatTokenType t){
            StatToken resultToken = this.Find(m => m.type == t);
            if(resultToken == null){
                // Debug.LogError("StatTokenList.Find(1) : There is no matching type of " + t.ToString() );
                return new StatToken(GameTerms.StatTokenType.None, GameTerms.StatTokenCategory.None);
            }else{
                return resultToken;
            }
        }

        public bool Has(GameTerms.StatTokenType t){
            StatToken resultToken = this.Find(m => m.type == t);
            if(resultToken == null){
                return false;
            }else{
                return true;
            }
        }
        public bool Has(GameTerms.StatTokenType t, GameTerms.StatTokenCategory c){
            StatToken resultToken = this.Find(m => m.type == t && m.category == c);
            if(resultToken == null){
                return false;
            }else{
                return true;
            }
        }

        public void CapStat(StatTokenList max){
            foreach (StatToken item in this){
                StatToken maxToken = max.Find(m => m.type == item.type);
                if(maxToken == null){
                    Debug.LogError("StatTokenList.CapStat : There is no matching type for " + item.type.ToString() );
                }else{
                    if(item.value0 < 0f) item.value0 = 0f;
                    else item.value0 = Mathf.Min(item.value0, maxToken.value0);
                    if(item.value1 < 0f) item.value1 = 0f;
                    else item.value1 = Mathf.Min(item.value1, maxToken.value1);
                }
            }
        }

        public void CalculatePreviousStatOnTurnStart(Character me, Character Other){
            //Energe
            // StatToken energy = Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current);
            // float energyGainVal = me.GetLastPlayData(1).token.Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.GainNextTurn).value0;
            // float energyLossVal = me.GetLastPlayData(1).token.Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.LossNextTurn).value0;
            // Debug.Log(" ** Energy [Current] : " + energy.value0 + " / [Gain] : " + energyGainVal + " / [Loss] : " + energyLossVal);
            // energy.value0 = energy.value0 + energyGainVal - energyLossVal;
            // //SwordPower
            // StatToken swordPower = Find(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Current);
            // // Debug.Log("Sword Power and Shield Power : " + swordPower.value0 + " / " + shieldPower.value0);
            // float swordPowerGainVal = me.GetLastPlayData(1).token.Find(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.GainNextTurn).value0;
            // float swordPowerLossVal = me.GetLastPlayData(1).token.Find(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.LossNextTurn).value0;
            // swordPower.value0 = swordPower.value0 + swordPowerGainVal - swordPowerLossVal;
            // //ShieldPower
            // StatToken shieldPower = Find(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Current);
            // float shieldPowerGainVal = me.GetLastPlayData(1).token.Find(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.GainNextTurn).value0;
            // float shieldPowerLossVal = me.GetLastPlayData(1).token.Find(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.LossNextTurn).value0;
            // shieldPower.value0 = shieldPower.value0 + shieldPowerGainVal - shieldPowerLossVal;
        }

        public void CalculatOneResult(StatTokenList other){
            //Health (Damage to Health)
            StatToken health = Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current);
            StatToken healthGain = Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Gain);
            
            StatToken damage = Find(GameTerms.StatTokenType.Damage, GameTerms.StatTokenCategory.Take);
            StatToken trueDamage = Find(GameTerms.StatTokenType.TrueDamage, GameTerms.StatTokenCategory.Take);
            StatToken poison = Find(GameTerms.StatTokenType.Poison, GameTerms.StatTokenCategory.Current);

            health.value0 -= Mathf.Max(damage.value0, 0f); // damage가 음수인 경우 체력이 회복됨을 방지
            health.value0 -= Mathf.Max(trueDamage.value0, 0f); // damage가 음수인 경우 체력이 회복됨을 방지
            if(poison.value0 > 0) {
                health.value0 --;
                poison.value0 --;
            }
            health.value0 += healthGain.value0;

            //추가 피해를 주는 방식들 계속 추가

            //Energy (Consumption to Energy)
            StatToken energy = Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current);
            StatToken energyLoss = Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Loss);
            StatToken energyGain = Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Gain);
            // Debug.Log(" * Energy [Current] : " + energy.value0 + " / [Concumption] : " + energyConsumption.value0);
            energy.value0 = energy.value0 + energyGain.value0 - energyLoss.value0;
            //추가 피해를 주는 방식들 계속 추가

            //Poison: Take -> Current, 여기에 위치함으로 인해 1턴 후부터 데미지에 적용        
            float poisonTaken = Find(GameTerms.StatTokenType.Poison, GameTerms.StatTokenCategory.Take).value0;
            if(poisonTaken > 0f){
                Combine(new StatToken(GameTerms.StatTokenType.Poison, GameTerms.StatTokenCategory.Current, poisonTaken));
            }
            
        }
        public StatTokenList InheritStat(){
            StatTokenList returnVal = new StatTokenList();
            //옮길 것
            //Current Health
            StatToken currentHealth = Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current);
            returnVal.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current, currentHealth.value0, currentHealth.value1));
            //Current Energy
            StatToken currentEnergy = Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current);
            returnVal.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current, currentEnergy.value0, currentEnergy.value1));
            //Current ShieldPower
            StatToken currentSwordPower = Find(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Current);
            returnVal.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Current, currentSwordPower.value0, currentSwordPower.value1));
            //Current Health
            StatToken currentShieldPower = Find(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Current);
            returnVal.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Current, currentShieldPower.value0, currentShieldPower.value1));
            
            //Others
            //Poison
            float poisonVal = Find(GameTerms.StatTokenType.Poison).value0;
            if(poisonVal > 0){
                returnVal.Combine(new StatToken(GameTerms.StatTokenType.Poison, GameTerms.StatTokenCategory.Current, poisonVal));
            }
            return returnVal;
        }

        public override string ToString()
        {
            string returnVal = "";
            bool isFirstItem = true;
            foreach (StatToken item in this)
            {            
                if(isFirstItem == true) isFirstItem = false;
                else returnVal += " / ";
                returnVal += item.type.ToString() + "." + item.category.ToString()+"."+item.value0+"."+item.value1;
            }
            return returnVal;
        }
    }


    public class StatTokenFactory
    {
        /*
        OnStartGame : 게임 시작시
        OnStartTurn : 턴 시작시
        OnFeedback : 결과에 따른 효과
        */
        public enum OperateType {None, OnStartGame, OnStartTurn, OnSource,OnPower, OnExceedEnergyTakeBack, OnDamageGain, OnDamageReduction, OnConsequence, OnFeedback,
                                OnPoisonGive, OnMotionAttack, OnMotionStrike, OnMotionDefence, OnMotionCharge, OnMotionAvoid, OnMotionTaunt, OnMotionNone};
        public delegate void Operate(Character me, Character ohter);
        public OperateType type;
        public Operate operate;
        public StatTokenFactory(OperateType t, Operate o){
            type = t;
            operate = o;
        }
        
    }

    


}