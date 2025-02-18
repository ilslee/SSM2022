using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure.token{
    /* 
    [재생]
    작동 : Turn Start 매 d 턴마다 H+1
    추가 : -
    */
    public class Regeneration : GameToken
    {
        public int timer;
        private int currentTime;
        public Regeneration() : base(){
            type = GameTerms.TokenType.Regeneration;
            occasion = GameTerms.TokenOccasion.TurnStart;
            timer = 7;            
            currentTime = timer;
        }

        public override void Yeild()
        {
            currentTime --;
            if(currentTime == 0){
                Me().GetLastPlayData().Combine(new HPCurrent(1f));
                currentTime = timer;
            }    
        }
        public override int GetTokenValue()
        {
            return currentTime + 1;

        }
        
    }

}
