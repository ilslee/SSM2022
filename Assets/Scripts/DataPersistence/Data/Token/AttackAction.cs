using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;
namespace ssm.data.token{
    public class AttackAction : Token
    {
        public AttackAction(int chaID) : base(chaID){
            type = GameTerms.TokenType.AttackAction;
            occasion = GameTerms.TokenOccasion.Attack;
        }

        public override TokenList Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            game.structure.Character other = GameBoard.Instance().FindOpponent(characterIndex);
            
            TokenList returnVal = new TokenList();
            PlayData meCurrent = me.GetLastPlayData();
            PlayData otherCurrent = other.GetLastPlayData();
            //basePower
            float attackBasePower = meCurrent.Find(GameTerms.TokenType.AttackPower).value0; 
            Token basePower = new Token(characterIndex, GameTerms.TokenType.BasePower, GameTerms.TokenOccasion.Attack, attackBasePower);
            //energy power
            float currentEnergy = meCurrent.Find(GameTerms.TokenType.EPCurrent).value0;
            Token energePower = new Token(characterIndex, GameTerms.TokenType.EnergyPower, GameTerms.TokenOccasion.Attack, currentEnergy);
            float offensivePower = attackBasePower + currentEnergy;
            Token offensiveMinPower = new Token(characterIndex, GameTerms.TokenType.OffensiveMinPower, GameTerms.TokenOccasion.Attack, offensivePower);
            Token offensiveMaxPower = new Token(characterIndex, GameTerms.TokenType.OffensiveMaxPower, GameTerms.TokenOccasion.Attack, offensivePower);
            returnVal.Add(basePower);
            returnVal.Add(energePower);
            returnVal.Add(offensiveMinPower);
            returnVal.Add(offensiveMaxPower);
            return returnVal;
        }
    }
}