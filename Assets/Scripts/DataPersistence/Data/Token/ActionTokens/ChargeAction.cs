using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.data.token{
    public class ChargeAction : Token
    {
        public ChargeAction() : base(){
            type = GameTerms.TokenType.ChargeAction;
            occasion = GameTerms.TokenOccasion.Charge;
        }
        public override TokenList Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameBoard.Instance().phase == GameTerms.Phase.Expectation ? GameTerms.TokenOccasion.Charge : GameTerms.TokenOccasion.Offensive;
            TokenList returnVal = new TokenList();
            //basePower
            float chargeBasePower = me.SearchToken(GameTerms.TokenType.ChargePower).value0; 
            Power basePowerToken = new Power(characterIndex, GameTerms.TokenType.BasePower, o, chargeBasePower);
            //energy power
            float currentEnergy = me.GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            float chargeEfficiency = me.SearchToken(GameTerms.TokenType.ChargeEfficiency).value0;
            float chargeConsumptionMax = me.SearchToken(GameTerms.TokenType.StrikeConsumption).value0;
            float chargeConsumption = Mathf.Min(currentEnergy, chargeConsumptionMax);
            float energyPower = Mathf.Floor(chargeConsumption * chargeEfficiency); 
            Power energePowerToken = new Power(characterIndex, GameTerms.TokenType.EnergyPower, o, energyPower);
            
            float totalPower = chargeBasePower + energyPower;
            
            Power totalPowerToken = new Power(characterIndex, GameTerms.TokenType.TotalPower, o, totalPower);
            returnVal.Add(basePowerToken);
            returnVal.Add(energePowerToken);
            returnVal.Add(totalPowerToken);
            return returnVal; 
        }
    }
}

