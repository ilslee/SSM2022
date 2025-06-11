using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class DefenceAction : AttackAction // Attack과 Defence 계산 방식이 비슷하여(특히 Yield) 하나로 관리
    {
        public DefenceAction() : base()
        {
            type = GameTerms.TokenType.DefenceAction;
            occasion = GameTerms.TokenOccasion.Static;
            motion = GameTerms.TokenOccasion.Defence; // base.Yield()에서 사용
        }

        internal override void YeildPowerAndConsumption(float p = 0, float c = 0)
        {
            Me().temporaryTokens.Combine(new Power(motion, false, p));
        }
       
    }
}

