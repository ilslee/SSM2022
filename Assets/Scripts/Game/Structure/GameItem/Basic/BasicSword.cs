using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class BasicSword : Item
    {
        internal float[] attackPower;
        internal float[] strikePower;
        internal float[] strikeMaxEnergeConsumption;
        internal float[] strikeEnergeConversionRate;
        public BasicSword(int grade = 0): base(grade){
            InitializeNumbers();
            
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionAttack, CalculateAttack));
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionStrike, CalculateStrike));
        }
        internal virtual void InitializeNumbers(){
            attackPower = new float[3]{1f, 2f, 3f};
            strikePower = new float[3]{1f, 2f, 3f};
            strikeMaxEnergeConsumption = new float[3]{2f, 3f, 4f};
            strikeEnergeConversionRate = new float[3]{1f, 1.5f, 2f};
        }
        /*
        private float GetCurrentSwordPower(Character me){
            return me.GetLastPlayData().token.Find(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Current).value0;
        }
        internal void CalculateAttack(Character me, Character other){
            float offensivePower = attackPower[grade] + GetCurrentSwordPower(me);

            StatTokenList target = me.expectation[(int)GameTerms.Motion.Attack];
            target.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Offensive, offensivePower));  
            AdjustSwordShieldPower(target);
        }
        internal void CalculateStrike(Character me, Character other){
            float currentEnergy = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current).value0;
            float energeConsumption = Mathf.Min(strikeMaxEnergeConsumption[grade], currentEnergy);
            float energyPower = Mathf.Floor(strikeEnergeConversionRate[grade] * energeConsumption);
            float offensivePower = strikePower[grade] + GetCurrentSwordPower(me) + energyPower;
            
            StatTokenList target = me.expectation[(int)GameTerms.Motion.Attack];
            target.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Loss, energeConsumption));
            target.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Offensive, offensivePower));    
            AdjustSwordShieldPower(target);
            target.Combine(new StatToken(GameTerms.StatTokenType.InvalidDefenceShieldPowerRecoveryOther, GameTerms.StatTokenCategory.Current));
        }
        internal void AdjustSwordShieldPower(StatTokenList t){
            t.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.GainNextTurn,1f));            
            t.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.LossNextTurn,1f));            
        }
        */
        // public void SetStatOnCalculation(Character me, Character other){
        //     if(GameBoard.Phase == GameTerms.Phase.Expectation){
        //         CalculateAttack(me, me.expectation[(int)GameTerms.Motion.Attack]);
        //         SetAttackAdjustment(me, me.expectation[(int)GameTerms.Motion.Attack]);

        //         CalculateStrike(me, me.expectation[(int)GameTerms.Motion.Strike]);
        //         SetStrikeAdjustment(me, me.expectation[(int)GameTerms.Motion.Strike]);

        //     }else if(GameBoard.Phase == GameTerms.Phase.Calculate){                
        //         if(me.GetLastPlayData().motion == GameTerms.Motion.Attack){
        //             CalculateAttack(me, me.GetLastPlayData().token);
        //             SetAttackAdjustment(me, me.GetLastPlayData().token);
        //         }else if(me.GetLastPlayData().motion == GameTerms.Motion.Strike){ 
        //             CalculateStrike(me, me.GetLastPlayData().token);
        //             SetStrikeAdjustment(me, me.GetLastPlayData().token);
        //         }
        //     }
        // }

        // internal void CalculateAttack(Character me, StatTokenList address){
        //     float aggressionPower = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Current).value0;
        //     float basePower = me.powerSource[(int)GameTerms.Motion.Attack].Find(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Base).value0;
        //     float offensivePower = basePower + aggressionPower;
        //     address.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Offensive, offensivePower));            
        // }
        // internal void CalculateStrike(Character me, StatTokenList address){
        //     float aggressionPower = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Current).value0;
        //     float currentEnergy = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current).value0;
        //     float energeMaxConsumption = me.powerSource[(int)GameTerms.Motion.Strike].Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.MaxConsumption).value0;
        //     float energeConsumption = Mathf.Min(energeMaxConsumption, currentEnergy);
        //     float energyConversionRate = me.powerSource[(int)GameTerms.Motion.Strike].Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.ConversionRate).value0;
        //     float energyPower = Mathf.Floor(energyConversionRate * energeConsumption);
        //     float basePower = me.powerSource[(int)GameTerms.Motion.Strike].Find(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Base).value0;
        //     float offensivePower = basePower + aggressionPower + energyPower;
            
        //     address.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Loss, energeConsumption));
        //     address.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Offensive, offensivePower));            
        // }
        // //----------[Motion: Agg/Sol modification]------------------------------------------------------------
       
        // internal void SetAttackAdjustment(Character me, StatTokenList address){
        //     address.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.GainNextTurn,1f));
        //     address.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.LossNextTurn,1f));
        // }
        // internal void SetStrikeAdjustment(Character me, StatTokenList address){
        //     SetAttackAdjustment(me, address);
        //     address.Combine(new StatToken(GameTerms.StatTokenType.InvalidDefenceShieldPowerRecoveryOther, GameTerms.StatTokenCategory.Current));
        // }

        // public void GetPowerSource(Character me, Character other){
        //     //Attack
        //     me.powerSource[(int)GameTerms.Motion.Attack].Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Base, attackPower[grade]));
        //     //Strike
        //     me.powerSource[(int)GameTerms.Motion.Strike].Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Base, strikePower[grade]));
        //     me.powerSource[(int)GameTerms.Motion.Strike].Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.MaxConsumption, strikeMaxEnergeConsumption[grade]));
        //     me.powerSource[(int)GameTerms.Motion.Strike].Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.ConversionRate, strikeEnergeConversionRate[grade]));
        // }

        
    }
}