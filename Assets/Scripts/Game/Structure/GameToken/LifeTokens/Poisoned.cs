using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
using Unity.IO.LowLevel.Unsafe;
namespace ssm.game.structure.token{
    /*
    [중독됨]
    작동 : d 턴동안 Feedback 시 H-1
    추가 : d 증가
    */
    public class Poisoned : GameToken, IGameTokenCloneable<Poisoned>
    {
        // int curDuration = 0;
        // int maxDuration = 0;
        public Poisoned(float v0 = 0f) : base(v0)
        {
            type = GameTerms.TokenType.Poisoned;
            occasion = GameTerms.TokenOccasion.Feedback;
            value0 = v0; // duration
            priority = 40;
            isDynamic = true;
            isDisplayed = true;
        }

        public override void Yeild()
        {
            // CurDuration이 남아있으면 Damage 1반납하고 횟수 차감
            if (value0 > 0)
            {
                Me().GetLastPlayData().Combine(new Damage(false, 1f));
                value0--;
                isTrigged = true;
            }

        }

        
        public override bool IsRemobable()
        {
            //횟수 없어지면 PlayData에서 제거
            if (value0 <= 0) return true;
            else return false;
        }
        
        public new Poisoned Clone()
        {
            return base.Clone() as Poisoned;
        }
    }
}
