using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class RestAction : Action
    {
        public RestAction() : base()
        {
            type = GameTerms.TokenType.RestAction;
            occasion = GameTerms.TokenOccasion.Static;
            motion = GameTerms.TokenOccasion.Rest; // base.Yield()에서 사용
        }

        public override void Yeild()
        {
            base.Yeild(); //1,2 수행
            //3. 추가 계산 Energy Power & Consumption 후 expectation에 넣는다
            //Rest는 EP사용 없음
            
            // 1,2에서 작성
            float basePower = Me().SearchMTT(GameTerms.TokenType.Power, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Rest).value0;
            float additionalPower = Me().SearchMTT(GameTerms.TokenType.Power, MultiTypeToken.SubType.Additional, GameTerms.TokenOccasion.Rest).value0;
            //4. TotalPower추가
            float totalPower = basePower + additionalPower;
            Me().temporaryTokens.Combine(new Power(GameTerms.TokenOccasion.Rest, false, totalPower));

        }        
    }
}
