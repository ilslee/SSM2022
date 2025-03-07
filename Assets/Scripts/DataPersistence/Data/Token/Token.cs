using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ssm.data.token{
    [Serializable]
    public class Token
    {
        public GameTerms.TokenType type;
        public float value;
        public Token(){
            type = GameTerms.TokenType.None;
            value = 0f;
        }

        public Token(GameTerms.TokenType t, float v){
            type = t;
            value = v;
        }
    }
}