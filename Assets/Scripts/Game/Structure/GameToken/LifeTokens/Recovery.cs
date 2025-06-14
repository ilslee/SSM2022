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
    public class Recovery : Regeneration, IGameTokenCloneable<Recovery>
    {
        
        public Recovery(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.Recovery;            
        }

        
        public void RemoveRegeneration(){
            Debug.Log("*** Recovery.RemoveRegeneration : is called on a special occation");
            //강화 전 토큰 강제 삭제. Recovery는 세트 추가시 발생하니까 꼬일 일 없음
            Regeneration regen = Me().SearchToken(GameTerms.TokenType.Regeneration) as Regeneration;
            if (regen.type == GameTerms.TokenType.Regeneration)
            {
                Me().GetLastPlayData().Remove(regen);
                isTrigged = true;
            }
        }
        public new Recovery Clone()
        {
            Recovery returnVal = base.Clone() as Recovery;
            returnVal.currentTime = this.currentTime;
            return returnVal;
        }
    }

}
