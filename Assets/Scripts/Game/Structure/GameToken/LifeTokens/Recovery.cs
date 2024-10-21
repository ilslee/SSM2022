using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    public class Recovery : GameToken
    {
        public Recovery() : base(){
            type = GameTerms.TokenType.Recovery;
            occasion = GameTerms.TokenOccasion.Static;
        }

        public override void Yeild()
        {
            
        }
    }

}
