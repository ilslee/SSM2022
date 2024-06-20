using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
namespace ssm.game.structure{
    public class DummyLegs : Item
    {
        internal float[] avoidPower;
        internal float[] avoidMaxEnergeConsumption;
        internal float[] avoidEnergeConversionRate;
        internal float[] tauntPower;

        public DummyLegs(int grade = 0): base(grade){
            avoidPower = new float[3]{0f, 1f, 2f};
            // avoidMaxEnergeConsumption = new float[3]{2f, 3f, 4f};
            avoidEnergeConversionRate = new float[3]{1f, 1f, 1f};
            tauntPower = new float[3]{1f, 2f, 3f};
        }
        public override ModifierList GetModifiersOnME(Character me, Character other, GameTerms.Motion m){
            ModifierList modifier = new ModifierList();
            switch(m){
                case GameTerms.Motion.Avoid:
                // float avoidPowerResultMin = avoidPower[grade];
                // float avoidPowerResult = Mathf.Floor(avoidEnergeConversionRate[grade] *  me.GetLastPlayData().token.energy);                
                // modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.Energy, GameTerms.MTHow.OnPower, me.GetLastPlayData().token.energy));
                // modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.DefensivePower, GameTerms.MTHow.OnPower, avoidPowerResult));
                // modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.SwordPower, GameTerms.MTHow.Steal,avoidPower[grade]));
                // modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.ShieldPower, GameTerms.MTHow.Steal,avoidPower[grade]));
                break;
                case GameTerms.Motion.Taunt:                
                break;
            }
            return modifier;
        }

        public override ModifierList GetModifiersOnCalculation(Character me, Character other, GameTerms.Motion m){
            ModifierList modifier = new ModifierList();
            // float avoidPowerMax = Mathf.Floor(avoidEnergeConversionRate[grade] * me.GetLastPlayData().token.energy); 
            // float otherOffensivePower = other.GetLastPlayData().modifiersCalculation.FindModifierTokenValue(GameTerms.MTType.OffensivePower);
            // if(otherOffensivePower > avoidPowerMax){
            //     modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.Energy, GameTerms.MTHow.OnPower, me.GetLastPlayData().token.energy * -1f));
            //     modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.DefensivePower, GameTerms.MTHow.None, avoidPowerMax));
            // }else{
            //     float avoidEnergeConsumptionResult = Mathf.Ceil(otherOffensivePower / avoidEnergeConversionRate[grade]);
            //     float avoidPowerResult = Mathf.Floor(avoidEnergeConversionRate[grade] * avoidEnergeConsumptionResult); 
            //     modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.Energy, GameTerms.MTHow.OnPower, avoidEnergeConsumptionResult * -1f));
            //     modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.DefensivePower, GameTerms.MTHow.OnPower, avoidPowerResult));
            // }
            return modifier;
        }
        public override ModifierList GetModifiersOnAddition(Character me, Character other){
            ModifierList modifier = new ModifierList();
            //성공 여부에 따른 시나리오가 복잡하니 잘 반영해보자
            if(me.GetLastPlayData().collision == false){
                switch(me.GetLastPlayData().motion){
                    case GameTerms.Motion.Avoid:
                    switch(other.GetLastPlayData().motion){
                        case GameTerms.Motion.Strike:
                        modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.SwordPower, GameTerms.MTHow.Steal,avoidPower[grade]));
                        break;
                        case GameTerms.Motion.Charge:
                        modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.ShieldPower, GameTerms.MTHow.Steal,avoidPower[grade]));
                        break;
                    }
                    break;
                    case GameTerms.Motion.Taunt:
                    modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.SwordPower, GameTerms.MTHow.Steal,tauntPower[grade]));
                    modifier.AddModifierToken(new ModifierToken(GameTerms.MTType.ShieldPower, GameTerms.MTHow.Steal,tauntPower[grade]));

                    break;
                }
            }
            return modifier;
        }
        
    }
}
*/