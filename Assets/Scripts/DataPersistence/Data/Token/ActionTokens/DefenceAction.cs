using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.data.token{
    public class DefenceAction : Token
    {
        public DefenceAction() : base(){
            type = GameTerms.TokenType.DefenceAction;
            occasion = GameTerms.TokenOccasion.Defence;
        }

        public override TokenList Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameBoard.Instance().phase == GameTerms.Phase.Expectation ? GameTerms.TokenOccasion.Defence : GameTerms.TokenOccasion.Defensive;
            TokenList returnVal = new TokenList();
            //basePower
            float defencaBasePower = me.SearchToken(GameTerms.TokenType.DefencePower).value0; 
            Power basePowerToken = new Power(characterIndex, GameTerms.TokenType.BasePower, o, defencaBasePower);
            //energy power
            float currentEnergy = me.GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            float defenceEfficiency = me.SearchToken(GameTerms.TokenType.DefenceEfficiency).value0;
            float eneryPower = Mathf.Floor(currentEnergy * defenceEfficiency); 
            Power energePowerToken = new Power(characterIndex, GameTerms.TokenType.EnergyPower, o, eneryPower);
            
            float totalPower = defencaBasePower + eneryPower;
            Power totalPowerToken = new Power(characterIndex, GameTerms.TokenType.TotalPower, o, totalPower);
            returnVal.Add(basePowerToken);
            returnVal.Add(energePowerToken);
            returnVal.Add(totalPowerToken);
            return returnVal;
        }
    }
}

