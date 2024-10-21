using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;

namespace ssm.game.structure.token{
    public class Vigor : GameToken
    {
        public Vigor() : base(){
            type = GameTerms.TokenType.Vigor;
            occasion = GameTerms.TokenOccasion.Calculation;
            priority = 60;
        }

        public override void Yeild()
        {
            if(HealthRatioGreaterThan() == true){
                GameTerms.TokenOccasion o = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Find(GameTerms.TokenType.BasePower).occasion;
                GameToken additionalPower = new GameToken(GameTerms.TokenType.AdditionalPower, o, 1f);
                GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Combine(additionalPower);
            }
        }

        private bool HealthRatioGreaterThan(){
            float lastHP = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData(1).Find(GameTerms.TokenType.HPCurrent).value0;
            float maxHP = GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.HPMax).value0;
            float lastHPRatio = lastHP / maxHP * 100f ;
            if(lastHPRatio > value0) return true;
            else return false;
        }
    }

}
