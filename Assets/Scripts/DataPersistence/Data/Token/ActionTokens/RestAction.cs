using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.data.token{
    public class RestAction : Token
    {
        public RestAction() : base(){
            type = GameTerms.TokenType.RestAction;
            occasion = GameTerms.TokenOccasion.Rest;
        }

        public override TokenList Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameBoard.Instance().phase == GameTerms.Phase.Expectation ? GameTerms.TokenOccasion.Rest : GameTerms.TokenOccasion.Defensive;
            TokenList returnVal = new TokenList();
            //basePower
            float restBasePower = me.SearchToken(GameTerms.TokenType.RestPower).value0; 
            Power basePowerToken = new Power(characterIndex, GameTerms.TokenType.BasePower, o, restBasePower);
            //energy power
            float totalPower = restBasePower;
            Power totalPowerToken = new Power(characterIndex, GameTerms.TokenType.TotalPower, o, totalPower);
            returnVal.Add(basePowerToken);
            returnVal.Add(totalPowerToken);
            return returnVal;
        }
    }
}
