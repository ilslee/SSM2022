using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    /* 
    [순환중]
    작동 :d동안 e+1
    추가 : d추가
    */
    public class Circulating : GameToken
    {
        private int duration;
        public Circulating(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.Circulating;
            occasion = GameTerms.TokenOccasion.TurnStart;
            duration = (int)v0;
            priority = 40;
            isDynamic = false;
            isDisplayed = true;
        }
        public override void Combine(GameToken t)
        {
            duration += (int)t.value0;
        }
        public override void Yeild()
        {
            // CurDuration이 남아있으면 EP Current +1하고 횟수 차감
            if(duration > 0) {
                Me().GetLastPlayData().Combine(new EPCurrent(1f));
                duration --;
            }
            
        }
        public override int GetTokenValue()
        {
            return duration;
        }
    }
}