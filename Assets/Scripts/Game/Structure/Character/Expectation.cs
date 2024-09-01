using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.token;
namespace ssm.game.structure{
    public class Expectation : TokenList{
        public void Reset(Character me, Character other){
            this.Clear();
            // Motion 0 : None
            this.Add(new Token(GameTerms.TokenType.BasePower, GameTerms.TokenOccasion.MotionNone));
            this.Add(new Token(GameTerms.TokenType.EnergyPower, GameTerms.TokenOccasion.MotionNone));
            this.Add(new Token(GameTerms.TokenType.AdditionalPower, GameTerms.TokenOccasion.MotionNone));
            this.Add(new Token(GameTerms.TokenType.DefensiveMinPower, GameTerms.TokenOccasion.MotionNone));
            this.Add(new Token(GameTerms.TokenType.DefensiveMaxPower, GameTerms.TokenOccasion.MotionNone));
            
            // Motion 1 : Attack
            //me.token.Find(GameTerms.TokenType.AttackAction).value0;
            //float attackEnerge
            //float attackEnergePower = me.token.Find(GameTerms.TokenType.BasePower, GameTerms.TokenOccasion.Attack).value0;
            // Motion 2 : Strike
            // Motion 3 : Defence
            // Motion 4 : Charge
            // Motion 5 : Rest
            // Motion 6 : Avoid
        }
    }
}