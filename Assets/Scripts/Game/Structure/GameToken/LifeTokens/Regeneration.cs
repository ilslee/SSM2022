using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure.token{
    public class Regeneration : GameToken
    {
        public Regeneration() : base(){
            type = GameTerms.TokenType.Regeneration;
            occasion = GameTerms.TokenOccasion.Static;
        }

        public override void Yeild()
        {
            
        }
    }

}
