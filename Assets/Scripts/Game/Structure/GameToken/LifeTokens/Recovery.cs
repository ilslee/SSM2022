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
    public class Recovery : Regeneration
    {
        
        public Recovery() : base(){
            type = GameTerms.TokenType.Recovery;
            occasion = GameTerms.TokenOccasion.TurnStart;
            timer = 5;            
            currentTime = timer;
            isDisplayed = true;
            
            //강화 전 토큰 강제 삭제. Recovery는 세트 추가시 발생하니까 꼬일 일 없음
            Regeneration regen = Me().GetLastPlayData().Find(GameTerms.TokenType.Regeneration) as Regeneration;
            Me().GetLastPlayData().Remove(regen);
            
        }

        
        

    }

}
