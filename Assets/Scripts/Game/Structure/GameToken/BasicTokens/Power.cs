using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    public class Power : GameToken
    {
        //Power는 offensive, deffensive 구분 bool이 있음
        public bool isOffensive;
        public Power(GameTerms.TokenType t, GameTerms.TokenOccasion o, bool isOffensive, float v0 = 0f) : base(t, o, v0){
            this.isOffensive = isOffensive;
            isDynamic = true;
        }
        public new Power Clone()
        {
            return new Power(type, occasion, isOffensive, value0);
        }
    }
}