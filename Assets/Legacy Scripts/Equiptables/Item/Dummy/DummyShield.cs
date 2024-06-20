using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
namespace ssm.game.structure{
    public class DummyShield : Item
    {
        
        internal float[] DefensivePower;
        internal float[] chargePower;
        internal float[] chargeMaxEnergeConsumption;
        internal float[] chargeEnergeConversionRate;
        
        public DummyShield(int grade = 0): base(grade){
            DefensivePower = new float[3]{2f,3f,4f};
            chargePower = new float[3]{0f,1f,2f};
            chargeMaxEnergeConsumption = new float[3]{3f,4f,5f};
            chargeEnergeConversionRate = new float[3]{0f,1.5f,2f};
            
        }
        public override ModifierList GetModifiersOnME(Character me, Character other, GameTerms.Motion m){
            ModifierList modifier = new ModifierList();
            // int currentDefence = me.GetStat(GameTerms.MTType.ShieldPower);
            switch(m){
                case GameTerms.Motion.Defence:
                // float DefensivePowerResult = DefensivePower[grade] + me.GetLastPlayData().token.solidity;
                // modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.DefensivePower,GameTerms.MTHow.OnPower, DefensivePowerResult));
                
                break;
                case GameTerms.Motion.Charge:
                // float chargeEnergeConsumptionResult = Mathf.Min(chargeMaxEnergeConsumption[grade], me.GetLastPlayData().token.energy);
                // float chargePowerWithEnerge = Mathf.Floor(chargeEnergeConversionRate[grade] * chargeEnergeConsumptionResult);
                // float chargePowerResult = chargePower[grade] + me.GetLastPlayData().token.solidity + chargePowerWithEnerge;

                // modifier.Add(new ModifierToken(GameTerms.MTType.Energy, GameTerms.MTHow.OnPower, chargeEnergeConsumptionResult * -1f));
                // modifier.Add(new ModifierToken(GameTerms.MTType.OffensivePower, GameTerms.MTHow.OnPower, chargePowerResult));
                break;
            }
            
            return modifier;
        }
        public override ModifierList GetModifiersOnCalculation(Character me, Character other, GameTerms.Motion m){
           return GetModifiersOnME(me, other, m);
        }
        
    }
}
*/