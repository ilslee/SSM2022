using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ssm.game.structure;
using ssm.data.token;
namespace ssm.game.structure.token{
    public class AvoidAction : Action
    {
        private float otherOffensiveValue = 0f; // 다른 캐릭터의 공격값
        public AvoidAction() : base()
        {
            type = GameTerms.TokenType.AvoidAction;
            occasion = GameTerms.TokenOccasion.Static;
            motion = GameTerms.TokenOccasion.Avoid; // base.Yield()에서 사용
        }
        public void Yeild1()
        {
            otherOffensiveValue = 0f;
            //상대의 최대 공격형 Power를 찾는다
            Power maxOffensiveToken = Other().temporaryTokens.Where(x => x is Power && (x as Power).isOffensive == true).OrderBy(y => y.value0).FirstOrDefault() as Power;

            if (maxOffensiveToken == null)
            {
                Debug.LogError("AvoidAction.Yeild1 : Other Character has no Offensive Power item!");
                return;
            }
            else
            {
                otherOffensiveValue = maxOffensiveToken.value0;
                Yeild();
            }


        }

        public override void Yeild()
        {
            base.Yeild(); //1,2 수행
            //3.1 상대방 파워에서 기본 파워 제외
            float basePower = Me().SearchMTT(GameTerms.TokenType.Power, MultiTypeToken.SubType.Base, motion).value0;
            float additionalPower = Me().SearchMTT(GameTerms.TokenType.Power, MultiTypeToken.SubType.Additional, motion).value0;
            otherOffensiveValue -= (basePower + additionalPower);
            if (otherOffensiveValue <= 0f)
            {
                YieldDefault();
                return;
            }

            //3.2. Effficiency 먼저 계산
            float baseEfficiency = Me().staticTokens.FindMTT(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Base, motion).value0;
            float additionalEfficiency = Me().GetLastPlayData().FindMTT(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Additional, motion).value0;
            float totalEfficiency = baseEfficiency + additionalEfficiency;

            //3.3 EP계산
            float needEP = Mathf.Ceil(otherOffensiveValue / totalEfficiency);
            float currentEnergy = Me().SearchToken(GameTerms.TokenType.EPCurrent).value0;
            float additionalEnergy = Me().SearchMTT(GameTerms.TokenType.Energy, MultiTypeToken.SubType.Additional, motion).value0;
            float usingEP = Mathf.Min(needEP, currentEnergy);
            float ConsumingEP = usingEP - additionalEnergy;
            if (usingEP <= 0f)
            {
                YieldDefault();
                return;
            }

            float totalEPPower = Mathf.Floor(totalEfficiency * usingEP);
            float baseEPPower = Mathf.Floor(baseEfficiency * usingEP);
            float additionalEPPower = totalEPPower - baseEPPower;

            //4. BaseEPPower 추가
            if (baseEPPower > 0f) Me().temporaryTokens.CombineMTT(new MultiTypeToken(GameTerms.TokenType.Power, MultiTypeToken.SubType.EP, motion, baseEPPower));
            //이건 특수 경로로만 1,2에서 작성. 수치 한 차례 업데이트 Additional Poower는 additionalBasePower와 additionalEPPower의 합
            if (additionalEPPower > 0f)
            {
                Me().temporaryTokens.CombineMTT(new MultiTypeToken(GameTerms.TokenType.Power, MultiTypeToken.SubType.Additional, motion, additionalEPPower));
            }
            
            //5. TotalPower, Concumption추가
            float totalPower = basePower + baseEPPower + additionalPower;            
            YeildPowerAndConsumption(totalPower, ConsumingEP);
        }

        //추가 계산을 하지 않아도 될 때 : 기본 파워와 additional 파워만으로 total power 계산
        private void YieldDefault()
        {

        }
    }
}

