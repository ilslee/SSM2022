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
        internal int timer;
        internal int currentTime;
        public Regeneration(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.Regeneration;
            occasion = GameTerms.TokenOccasion.TurnStart;
            timer = (int)v0;            
            currentTime = timer;
            isDynamic = false;
            isDisplayed = true;
            
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
        public override bool IsRemobable()
        {
            return base.IsRemobable();
        }
    }

}
