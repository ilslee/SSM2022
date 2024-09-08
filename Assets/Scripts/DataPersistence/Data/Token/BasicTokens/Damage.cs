using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;
namespace ssm.data.token{
    public class Damage : Token
    {
        public Damage( int chaID, GameTerms.TokenType t, GameTerms.TokenOccasion o, float v0 = 0f) : base(chaID, t, o, v0){
        }
        public override TokenList Yeild()
        {
            TokenList returnVal = new TokenList();
            if(occasion == GameTerms.TokenOccasion.Take){
                // HPCurrent 
            }
            return returnVal;
        }
    }
}
