using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    /* 
    [순환중 : 순환을 통해 발동]
    작동 :d동안 e+1
    추가 : d추가
    */
    public class Circulating : GameToken, IGameTokenCloneable<Circulating>
    {
        // private int duration;
        //value0 : duration
        public Circulating(float v0 = 0f) : base(v0)
        {
            type = GameTerms.TokenType.Circulating;
            occasion = GameTerms.TokenOccasion.TurnStart;
            value0 = (int)v0;
            priority = 40;
            isDynamic = true;
            isDisplayed = true;
        }
        public override void Combine(GameToken t)
        {
            value0 += (int)t.value0;
        }
        public override void Yeild()
        {
            // CurDuration이 남아있으면 EP Current +1하고 횟수 차감
            if (value0 > 0)
            {
                Me().GetLastPlayData().Combine(new EPCurrent(1f));
                value0--;
                isTrigged = true;
            }
            
        }
        public override bool IsRemobable()
        {
            if(value0 <= 0f) return true; //값이 0보다 작아지면 삭제
            else return false;
        }
        public new Circulating Clone()
        {
            return base.Clone() as Circulating;
        }
        
    }
}