using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class DefenceAction : Action
    {
        public DefenceAction() : base()
        {
            type = GameTerms.TokenType.DefenceAction;
            occasion = GameTerms.TokenOccasion.Static;
            motion = GameTerms.Motion.Defence; // base.Yield()에서 사용
        }

        public override void Yeild()
        {
            base.Yeild(); //1,2 수행
            //3. 추가 계산 Energy Power & Consumption 후 expectation에 넣는다
            float currentEnergy = Me().GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            float availableMaxEnergy = Me().staticTokens.Find(GameTerms.TokenType.ShieldEPAvailable).value0;
            float usingEP = Mathf.Min(currentEnergy, availableMaxEnergy);

            float baseEfficiency = Me().staticTokens.FindMTT(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Defence).value0;
            float additionalEfficiency = Me().staticTokens.FindMTT(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Additional, GameTerms.TokenOccasion.Defence).value0;
            float totalEfficiency = baseEfficiency + additionalEfficiency;

            float totalEPPower = Mathf.Floor(totalEfficiency * usingEP);
            float baseEPPower = Mathf.Floor(baseEfficiency * usingEP);
            float additionalEPPower = totalEPPower - baseEPPower;

            // 1,2에서 작성
            float basePower = Me().temporaryTokens.FindMTT(GameTerms.TokenType.Power, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Defence).value0;

            //AdditionalEPPower 추가
            //3. BaseEPPower 추가
            if (baseEPPower > 0f) Me().temporaryTokens.Add(new MultiTypeToken(GameTerms.TokenType.Power, MultiTypeToken.SubType.EP, GameTerms.TokenOccasion.Defence, baseEPPower));
            //이건 특수 경로로만 1,2에서 작성. 수치 한 차례 업데이트
            if (additionalEPPower > 0f)
            {
                Me().temporaryTokens.CombineMTT(new MultiTypeToken(GameTerms.TokenType.Power, MultiTypeToken.SubType.Additional, GameTerms.TokenOccasion.Defence, additionalEPPower));
            }
            float additionalPower = Me().temporaryTokens.FindMTT(GameTerms.TokenType.Power, MultiTypeToken.SubType.Additional, GameTerms.TokenOccasion.Defence).value0;
            //4. TotalPower추가
            float totalPower = basePower + baseEPPower + additionalPower;
            Me().temporaryTokens.Combine(new Power(GameTerms.TokenOccasion.Defence, false, totalPower));

        }
       
    }
}

