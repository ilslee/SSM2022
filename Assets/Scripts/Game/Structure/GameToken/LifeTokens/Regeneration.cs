using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure.token{
    /* 
    [재생]
    작동 : Turn Start 매 d 턴마다 H+1
    추가 : -
    */
    public class Regeneration : GameToken, IGameTokenCloneable<Regeneration>
    {
        // internal int timer;
        internal float currentTime;
        public Regeneration(float v0 = 0f) : base(v0)
        {
            type = GameTerms.TokenType.Regeneration;
            occasion = GameTerms.TokenOccasion.TurnStart;
            value0 = (int)v0; // timer
            currentTime = value0;
            isDynamic = true;
            isDisplayed = true;

        }

        public override void Yeild()
        {
            currentTime--;
            if (currentTime == 0f)
            {
                Me().GetLastPlayData().Combine(new HPCurrent(1f));
                currentTime = value0;
                isTrigged = true;
            }
        }
        public override int GetTokenValue()
        {
            return (int)currentTime;

        }

        public new Regeneration Clone()
        {
            Regeneration returnVal = base.Clone() as Regeneration;
            returnVal.currentTime = this.currentTime;
            return returnVal;
        }
    }

}
