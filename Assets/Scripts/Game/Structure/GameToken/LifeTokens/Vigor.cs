using System;
using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;

namespace ssm.game.structure.token{
    /* 
    [활기]
    작동 : Calculation 최대 체력의 n배 이상인 경우 P+1
    추가 : 데이터상으로 100,90,80으로 되어 있어 계산 시 .01f 곱함
    */
    public class Vigor : GameToken, IGameTokenCloneable<Vigor>
    {
        private float vigorPoint;
        public Vigor(float v0) : base(v0)
        {
            type = GameTerms.TokenType.Vigor;
            occasion = GameTerms.TokenOccasion.TurnStart;
            priority = 60;

            isDynamic = true;
            isDisplayed = true;
            vigorPoint = 0f;
            //value0 :  vigorRatio
        }
        public void SetVigorPoint()
        {
            float maxHP = Me().SearchToken(GameTerms.TokenType.HPMax).value0;
            vigorPoint = Mathf.Ceil(maxHP * value0 * 0.01f);
        }
        public override void Yeild()
        {
            if (vigorPoint <= 0f) SetVigorPoint();
            if (HealthRatioGreaterThan() == true)
            {
                GameTerms.TokenOccasion o = Me().GetLastPlayData().Find(GameTerms.TokenType.BasePower).occasion;
                GameToken additionalPower = new GameToken(GameTerms.TokenType.AdditionalPower, o, 1f);
                Me().GetLastPlayData().Combine(additionalPower);
                isTrigged = true;
            }
        }

        private bool HealthRatioGreaterThan()
        {
            float currentHP = Me().GetLastPlayData(0).Find(GameTerms.TokenType.HPCurrent).value0;
            if (currentHP >= vigorPoint) return true;
            else return false;

        }

        public override int GetTokenValue()
        {
            return (int)vigorPoint;
        }
        
        public new Vigor Clone()
        {
            Vigor returnVal = base.Clone() as Vigor;
            returnVal.vigorPoint = this.vigorPoint;
            return returnVal;
        }
    }

}
