using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.data.token{
    public class Power : Token
    {
        public float value1;
        public Power(int chaID, GameTerms.TokenType t, GameTerms.TokenOccasion o, float v0 = 0f, float v1 = 0f) : base(chaID, t, o, v0){
            value1 = v1;
        }
    }
}