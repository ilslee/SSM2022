using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class BasicShield : Item
    {
         internal float[] defencePower;
        internal float[] chargePower;
        internal float[] chargeMaxEnergeConsumption;
        internal float[] chargeEnergeConversionRate;
        public BasicShield(int grade = 0): base(grade){
            InitializeNumbers();


            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionDefence, CalculateDefence));
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionCharge, CalculateCharge));

            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnPower, OnCalculation));
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnSource, GetPowerSource));
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnConsequence, CheckDefenceShieldPowerRecovery));
            
        }
        internal virtual void InitializeNumbers(){
            defencePower = new float[3]{2f,3f,4f};
            chargePower = new float[3]{0f,1f,2f};
            chargeMaxEnergeConsumption = new float[3]{3f,4f,5f};
            chargeEnergeConversionRate = new float[3]{0f,1.5f,2f};
        }

        internal void CalculateDefence(Character me, Character other){
            
            // float currentShieldPower = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Current).value0;
            // float defensivePower = defencePower[grade] + currentShieldPower;
            
            // StatTokenList target = me.expectation[(int)GameTerms.Motion.Defence];
            // target.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Defensive, defensivePower));
            // target.Combine(new StatToken(GameTerms.StatTokenType.InvalidDamageTakeByAttack, GameTerms.StatTokenCategory.Current));
            // AdjustSwordShieldPower(target);
        }
        internal void CalculateCharge(Character me, Character other){
            // float currentShieldPower = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Current).value0;
            // float currentEnergy = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current).value0;            
            // float energeConsumption = Mathf.Min(chargeMaxEnergeConsumption[grade], currentEnergy);
            // float energyPower = Mathf.Floor(chargeEnergeConversionRate[grade] * energeConsumption);
            // float offensivePower = chargePower[grade] + currentShieldPower + energyPower;

            // StatTokenList target = me.expectation[(int)GameTerms.Motion.Charge];
            // target.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Loss, energeConsumption));
            // target.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Offensive, offensivePower));
            // AdjustSwordShieldPower(target);

        }
        internal void AdjustSwordShieldPower(StatTokenList t){
            t.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.GainNextTurn,1f));
            t.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.LossNextTurn,1f));            
        }
        // public void OnCalculation(Character me, Character other){
        //     if(GameBoard.Phase == GameTerms.Phase.Expectation){
        //         CalculateDefence(me, me.expectation[(int)GameTerms.Motion.Defence]);
        //         CalculateCharge(me, me.expectation[(int)GameTerms.Motion.Charge]);

        //         SetDefenceAdjustment(me, me.expectation[(int)GameTerms.Motion.Defence]);
        //         SetChargeAdjustment(me, me.expectation[(int)GameTerms.Motion.Charge]);
        //     }else if(GameBoard.Phase == GameTerms.Phase.Calculate){                
        //         if(me.GetLastPlayData().motion == GameTerms.Motion.Defence){
        //             CalculateDefence(me, me.GetLastPlayData().token);
        //             SetDefenceAdjustment(me, me.GetLastPlayData().token);
        //         }
        //         else if(me.GetLastPlayData().motion == GameTerms.Motion.Charge){
        //             CalculateCharge(me, me.GetLastPlayData().token);
        //             SetChargeAdjustment(me, me.GetLastPlayData().token);
        //         }
        //     }
        // }

        // internal void CalculateDefence(Character me, StatTokenList address){
        //     float shieldPower = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Current).value0;
        //     float basePower = me.powerSource[(int)GameTerms.Motion.Defence].Find(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Base).value0;
        //     float defensivePower = basePower + shieldPower;
        //     if(defensivePower > 0) address.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Defensive, defensivePower));
            
            
        // }
        // internal void CalculateCharge(Character me, StatTokenList address){
        //     float shieldPower = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Current).value0;
        //     float currentEnergy = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current).value0;
        //     float energeMaxConsumption = me.powerSource[(int)GameTerms.Motion.Charge].Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.MaxConsumption).value0;
        //     float energeConsumption = Mathf.Min(energeMaxConsumption, currentEnergy);
        //     float energyConversionRate = me.powerSource[(int)GameTerms.Motion.Charge].Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.ConversionRate).value0;
        //     float energyPower = Mathf.Floor(energyConversionRate * energeConsumption);
        //     float basePower = me.powerSource[(int)GameTerms.Motion.Charge].Find(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Base).value0;
        //     float offensivePower = basePower + shieldPower + energyPower;
            
        //     if(energeConsumption > 0) address.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Loss, energeConsumption));
        //     if(offensivePower > 0) address.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Offensive, offensivePower));
        // }

        //----------[Motion: Agg/Sol modification]------------------------------------------------------------
       
       
        

        // public void GetPowerSource(Character me, Character other){
        //     //Defence
        //     me.powerSource[(int)GameTerms.Motion.Defence].Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Base, defencePower[grade]));
        //     //Charge
        //     me.powerSource[(int)GameTerms.Motion.Charge].Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Base, chargePower[grade]));
        //     me.powerSource[(int)GameTerms.Motion.Charge].Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.MaxConsumption, chargeMaxEnergeConsumption[grade]));
        //     me.powerSource[(int)GameTerms.Motion.Charge].Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.ConversionRate, chargeEnergeConversionRate[grade]));
        // }

        // public void CheckDefenceShieldPowerRecovery(Character me, Character other){
        //     if(other.GetLastPlayData().token.Has(GameTerms.StatTokenType.InvalidDefenceShieldPowerRecoveryOther) && me.GetLastPlayData().motion == GameTerms.Motion.Defence){
        //         me.GetLastPlayData().token.RemoveAll(st => st.type == GameTerms.StatTokenType.ShieldPower && st.category == GameTerms.StatTokenCategory.GainNextTurn);
        //     }
        // }
    }
}       
