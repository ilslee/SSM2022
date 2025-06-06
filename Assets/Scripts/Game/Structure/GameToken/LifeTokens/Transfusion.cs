using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure.token{
    /* 
    [수혈]
    작동 : Calculation - 데미지를 주면 - 상대방 Poisoned:d
    추가 : -
    */
    public class Transfusion : GameToken, IGameTokenCloneable<Transfusion>
    {
        // private float transfusionAmount;    
        public Transfusion(float v0 = 0f) : base(v0)
        {
            type = GameTerms.TokenType.Transfusion;
            occasion = GameTerms.TokenOccasion.Calculation;
            isDynamic = true;
            isDisplayed = true;
            value0 = v0; // transfusionAmount
        }

        public override void Yeild()
        {
            //이번 턴에 공격 성공하였으면 체력 회복 transfusionAmount
            if (GameTool.IsGivingDamage(characterIndex) == true)
            {
                Me().GetLastPlayData().Combine(new HPCurrent((float)value0));
                isTrigged = true;
            }
        }
        
        public new Transfusion Clone()
        {
            return base.Clone() as Transfusion;
        }
        
    }

}