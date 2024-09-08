using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.data.token{
    public class AttackAction : Token
    {
        public AttackAction() : base(){
            type = GameTerms.TokenType.AttackAction;
            occasion = GameTerms.TokenOccasion.Attack;
        }

        public override TokenList Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameBoard.Instance().phase == GameTerms.Phase.Expectation ? GameTerms.TokenOccasion.Attack : GameTerms.TokenOccasion.Offensive;
            TokenList returnVal = new TokenList();
            //basePower
            float attackBasePower = me.SearchToken(GameTerms.TokenType.AttackPower).value0; 
            Power basePowerToken = new Power(characterIndex, GameTerms.TokenType.BasePower, o, attackBasePower);
            //energy power
            float currentEnergy = me.GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            float attackEfficiency = me.SearchToken(GameTerms.TokenType.AttackEfficiency).value0;
            float eneryPower = Mathf.Floor(currentEnergy * attackEfficiency); 
            Power energePowerToken = new Power(characterIndex, GameTerms.TokenType.EnergyPower, o, eneryPower);
            
            float offensivePower = attackBasePower + eneryPower;
            Power offensivePowerToken = new Power(characterIndex, GameTerms.TokenType.TotalPower, o, offensivePower);
            returnVal.Add(basePowerToken);
            returnVal.Add(energePowerToken);
            returnVal.Add(offensivePowerToken);
            return returnVal;
        }
    }
}