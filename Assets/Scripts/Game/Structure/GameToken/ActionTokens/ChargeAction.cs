using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class ChargeAction : StrikeAction // ChargeAction와 Strike 계산 방식이 비슷하여(특히 Yield) 하나로 관리
    {
        public ChargeAction() : base()
        {
            type = GameTerms.TokenType.ChargeAction;
            occasion = GameTerms.TokenOccasion.Static;
            motion = GameTerms.TokenOccasion.Charge; // base.Yield()에서 사용
            
        }
        
    }
}

