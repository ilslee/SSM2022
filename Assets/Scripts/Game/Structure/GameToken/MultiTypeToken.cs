using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace ssm.game.structure.token
{

    public class MultiTypeToken : GameToken
    {
        public enum SubType
        {
            None, Base, EP, Additional
        }
        public GameTerms.TokenType motionType;
        
        public SubType subType;
        public MultiTypeToken() : base()
        {
            
        }
        public MultiTypeToken(GameTerms.TokenType t, SubType t2, GameTerms.TokenOccasion o, float v) : base(t, o, v)
        {
            subType = t2;
        }        
    }    

}