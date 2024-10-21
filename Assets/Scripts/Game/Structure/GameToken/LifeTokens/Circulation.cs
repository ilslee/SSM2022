using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class Circulation : GameToken
    {
        public Circulation() : base(){
            type = GameTerms.TokenType.Circulation;
            occasion = GameTerms.TokenOccasion.Static;
        }

        public override void Yeild()
        {
            
        }
    }

}