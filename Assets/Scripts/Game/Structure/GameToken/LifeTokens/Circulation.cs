using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    /* 
    [순환]
    작동 : TurnStart - 지난 턴 체력 증가가 있다면 - d동안 
    2턴 이상의 데이터가 필요
    추가 : 없음
    */
    public class Circulation : GameToken, IGameTokenCloneable<Circulation>
    {
        public Circulation(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.Circulation;
            occasion = GameTerms.TokenOccasion.Feedback;
            value0 = v0; // circulationDuration
            isDynamic = true;
            isDisplayed = true;
        }

        public override void Yeild()
        {
            if(Me().playData.Count > 1){
                float lastHP = Me().GetLastPlayData(1).Find(GameTerms.TokenType.HPCurrent).value0;
                float currentHP = Me().GetLastPlayData().Find(GameTerms.TokenType.HPCurrent).value0;
                if (currentHP > lastHP)
                {
                    Me().GetLastPlayData().Combine(new Circulating(value0));
                    isTrigged = true;
                }
            }
            
        }
        public new Circulation Clone()
        {
            return base.Clone() as Circulation;
        }
        
    }

}