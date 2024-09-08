using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;
namespace ssm.data.token{
    public class Power : Token
    {
        public float value1;
        public Power(int chaID, GameTerms.TokenType t, GameTerms.TokenOccasion o, float v0 = 0f, float v1 = -1f) : base(chaID, t, o, v0){
            value1 = v1;
        }

        public override TokenList Yeild()
        {
            TokenList returnValue = new TokenList();
            if(type ==  GameTerms.TokenType.TotalPower){
                Power otherPower = GameBoard.Instance().FindOpponent(characterIndex).GetLastPlayData().Find(GameTerms.TokenType.TotalPower) as Power;
                if(occasion == GameTerms.TokenOccasion.Offensive || otherPower.occasion == GameTerms.TokenOccasion.Offensive){
                    float deltaPower =  otherPower.value0 - value0;
                    if(deltaPower < 0){
                        Damage damageTaken = new Damage(characterIndex, GameTerms.TokenType.Damage, GameTerms.TokenOccasion.Take, Mathf.Abs(deltaPower));
                        returnValue.Add(damageTaken);
                    }else if(deltaPower > 0){
                        Damage damageGive = new Damage(characterIndex, GameTerms.TokenType.Damage, GameTerms.TokenOccasion.Give, Mathf.Abs(deltaPower));
                        returnValue.Add(damageGive);
                    }
                }
            }
            return returnValue;
        }
    }
}