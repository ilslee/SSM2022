using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class StrikeAction : Action
    {
        public StrikeAction() : base()
        {
            type = GameTerms.TokenType.StrikeAction;
            occasion = GameTerms.TokenOccasion.Static;
            motion = GameTerms.TokenOccasion.Strike; // base.Yield()에서 사용
        }
        public override void Yeild()
        {
            base.Yeild(); //1,2 수행
            //3. 추가 계산 Energy Power & Consumption 후 expectation에 넣는다
            float currentEnergy = Me().SearchToken(GameTerms.TokenType.EPCurrent).value0;
            float availableMaxEnergy = Me().SearchToken(GameTerms.TokenType.SwordEPAvailable).value0;
            float additionalEnergy = Me().SearchMTT(GameTerms.TokenType.Energy, MultiTypeToken.SubType.Additional, motion).value0;
            float ConsumingEP = Mathf.Min(currentEnergy, availableMaxEnergy);
            float usingEP = ConsumingEP + additionalEnergy;

            float baseEfficiency = Me().SearchMTT(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Base, motion).value0;
            float additionalEfficiency = Me().SearchMTT(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Additional, motion).value0;
            float totalEfficiency = baseEfficiency + additionalEfficiency;

            float totalEPPower = Mathf.Floor(totalEfficiency * usingEP);
            float baseEPPower = Mathf.Floor(baseEfficiency * usingEP);
            float additionalEPPower = totalEPPower - baseEPPower;

            // 1,2에서 작성
            float basePower = Me().SearchMTT(GameTerms.TokenType.Power, MultiTypeToken.SubType.Base, motion).value0;

            //AdditionalEPPower 추가
            //3. BaseEPPower 추가
            if (baseEPPower > 0f) Me().temporaryTokens.CombineMTT(new MultiTypeToken(GameTerms.TokenType.Power, MultiTypeToken.SubType.EP, motion, baseEPPower));
            //이건 특수 경로로만 1,2에서 작성. 수치 한 차례 업데이트 Additional Poower는 additionalBasePower와 additionalEPPower의 합
            if (additionalEPPower > 0f)
            {
                Me().temporaryTokens.CombineMTT(new MultiTypeToken(GameTerms.TokenType.Power, MultiTypeToken.SubType.Additional, motion, additionalEPPower));
            }
            float additionalPower = Me().SearchMTT(GameTerms.TokenType.Power, MultiTypeToken.SubType.Additional, motion).value0;
            //4. TotalPower, Concumption추가
            float totalPower = basePower + baseEPPower + additionalPower;            
            YeildPowerAndConsumption(totalPower, ConsumingEP);
        }
        internal override void YeildPowerAndConsumption(float p = 0, float c = 0)
        {
            Me().temporaryTokens.Combine(new Power(motion, true, p));
            Me().temporaryTokens.Combine(new GameToken(GameTerms.TokenType.Consumption, motion, c));
        }
    }
}
