using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token
{
    public class Action : GameToken
    {
        internal float basePower;
        internal float additionalPower;
        internal float baseefficiency;
        internal float additionalEfficiency;
        internal float baseEnergy;
        internal float additionalEnergy;
        internal GameTerms.Motion motion;
        public override void Yeild()
        {
            //1. static과 playData에서 PowerInfoGenerator를 찾음
            //2. 결과에 따라 파싱하여 expectation에 넣는다
            //3. 추가 계산 Energy Power & Consumption 후 expectation에 넣는다(개별 구현)

            foreach (GameToken st in Me().staticTokens)
            {
                if (st is PowerInfoGenerator)
                {
                    MultiTypeToken? mtt = (st as PowerInfoGenerator).YieldMTT(motion);
                    if (mtt != null) Me().temporaryTokens.CombineMTT(mtt);
                }
            }
            foreach (GameToken st in Me().GetLastPlayData())
            {
                if (st is PowerInfoGenerator)
                {
                    MultiTypeToken? mtt = (st as PowerInfoGenerator).YieldMTT(motion);
                    if (mtt != null) Me().temporaryTokens.CombineMTT(mtt);
                }
            }
        }
    }
}