using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
using Unity.IO.LowLevel.Unsafe;
namespace ssm.game.structure.token{
    public class Poisoned : GameToken
    {
        int curDuration = 0;
        int maxDuration = 0;
        public Poisoned(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.Poisoned;
            occasion = GameTerms.TokenOccasion.Dynamic;
            maxDuration = (int)v0;
            curDuration = maxDuration;
            priority = 40;
        }

        public override void Yeild()
        {
            // CurDuration이 남아있으면 Damage 1반납하고 횟수 차감
            if(curDuration > 0) {
                GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Combine(new Damage(false, 1f));
                curDuration --;
            }
            
        }

        public override void Combine(GameToken t)
        {
            maxDuration = (int)t.value0;
            curDuration = maxDuration;
        }

        public override bool IsRemobable()
        {
            //횟수 없어지면 PlayData에서 제거
            if(curDuration <= 0) return true;
            else return false;
        }
    }
}
