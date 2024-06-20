using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
namespace ssm.game.structure{
    public class DummySword : Item
    {
        
        internal float[] OffensivePower;
        internal float[] attackBaseDamage;
        internal float[] strikePower;
        internal float[] strikeMaxEnergeConsumption;
        internal float[] strikeEnergeConversionRate;
        
        public DummySword(int grade = 0): base(grade){
            OffensivePower = new float[3]{1f, 2f, 3f};
            strikePower = new float[3]{0f, 1f, 2f};
            strikeMaxEnergeConsumption = new float[3]{2f, 3f, 4f};
            strikeEnergeConversionRate = new float[3]{1f, 1.5f, 2f};
            
        }
        public override ModifierList GetModifiersOnME(Character me, Character other, GameTerms.Motion m){
            ModifierList returnML = new ModifierList();
            switch(m){
                case GameTerms.Motion.Attack:
                // float OffensivePowerResult = OffensivePower[grade] + me.GetLastPlayData().token.aggression;
                // returnML.Add(new ModifierToken(GameTerms.MTType.OffensivePower, GameTerms.MTHow.OnPower, OffensivePowerResult));
                break;
                case GameTerms.Motion.Strike:
                // float strikeEnergeConsumptionResult = Mathf.Min(strikeMaxEnergeConsumption[grade], me.GetLastPlayData().token.energy);
                // float strikePowerWithEnerge = Mathf.Floor(strikeEnergeConversionRate[grade] * strikeEnergeConsumptionResult);
                // float strikePowerResult = strikePower[grade] + me.GetLastPlayData().token.aggression + strikePowerWithEnerge;
                // returnML.Add(new ModifierToken(GameTerms.MTType.Energy, GameTerms.MTHow.OnPower, strikeEnergeConsumptionResult * -1f));
                // returnML.Add(new ModifierToken(GameTerms.MTType.OffensivePower, GameTerms.MTHow.OnPower, strikePowerResult));

                //부가 효과 : 이건 아이템에 부여되는 것이 아닌 시스템에서 부여
                // returnML.Add(new ModifierToken(GameTerms.MTType.PreventShieldPowerGainNextTurn, GameTerms.MTHow.Additional, 1f));
                break;
            }
            
            //부가 효과 : 이건 아이템에 부여되는 것이 아닌 시스템에서 부여
            // if(m == GameTerms.Motion.Attack || m == GameTerms.Motion.Strike){
            //     returnML.Add(new ModifierToken(GameTerms.MTType.SwordPower, GameTerms.MTHow.Modify, 1f));
            //     returnML.Add(new ModifierToken(GameTerms.MTType.ShieldPower, GameTerms.MTHow.Modify, -1f));
            // }
            
            return returnML;
        }

        public override ModifierList GetModifiersOnCalculation(Character me, Character other, GameTerms.Motion m){
            return GetModifiersOnME(me, other, m);            
        }

        
    }
}
*/