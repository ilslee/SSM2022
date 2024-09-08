using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.data.token{
    public class StrikeAction : Token
    {
        public StrikeAction() : base(){
            type = GameTerms.TokenType.StrikeAction;
            occasion = GameTerms.TokenOccasion.Strike;
        }
        public override TokenList Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameBoard.Instance().phase == GameTerms.Phase.Expectation ? GameTerms.TokenOccasion.Strike : GameTerms.TokenOccasion.Offensive;
            TokenList returnVal = new TokenList();
            //basePower
            float strikeBasePower = me.SearchToken(GameTerms.TokenType.StrikePower).value0; 
            Power basePowerToken = new Power(characterIndex, GameTerms.TokenType.BasePower, o, strikeBasePower);
            //energy power
            float currentEnergy = me.GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            float strikeEfficiency = me.SearchToken(GameTerms.TokenType.StrikeEfficiency).value0;
            float strikeConsumptionMax = me.SearchToken(GameTerms.TokenType.StrikeConsumption).value0;
            float strikeConsumption = Mathf.Min(currentEnergy, strikeConsumptionMax);
            float energyPower = Mathf.Floor(strikeConsumption * strikeEfficiency); 
            Power energePowerToken = new Power(characterIndex, GameTerms.TokenType.EnergyPower, o, energyPower);
            
            float offensivePower = strikeBasePower + energyPower;
            
            Power offensivePowerToken = new Power(characterIndex, GameTerms.TokenType.TotalPower, o, offensivePower);
            returnVal.Add(basePowerToken);
            returnVal.Add(energePowerToken);
            returnVal.Add(offensivePowerToken);
            return returnVal; 
        }
    }
}
