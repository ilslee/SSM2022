using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace ssm.game.structure.token{
    /* 
    [소생]
    작동 : Recovery를 강화. 7>5
    추가 : -
    */
    public class Recovery : GameToken
    {
        private int timer;
        private int currentTime;
        public Recovery() : base(){
            type = GameTerms.TokenType.Recovery;
            occasion = GameTerms.TokenOccasion.Static;
            
        }

        
        

    }

}
