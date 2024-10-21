using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace ssm.game.structure.token{
    public class Power2 : Power
    {
        //Power2는 추가 값을 가짐
        public float value1;
        public Power2(GameTerms.TokenType t, GameTerms.TokenOccasion o, bool isOffensive, float v0 = 0f, float v1 = 0f) : base(t, o, isOffensive, v0){
            this.isOffensive = isOffensive;
            value1 = v1;
        }
        public new Power2 Clone()
        {
            return new Power2(type, occasion, isOffensive, value0, value1);
        }
    }
}