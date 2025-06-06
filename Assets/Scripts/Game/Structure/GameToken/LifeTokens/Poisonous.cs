using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    /* 
    [중독]
    작동 : Poisonous - 데미지를 주면 - 상대방 Poisoned:d
    추가 : -
    */
    public class Poisonous : GameToken, IGameTokenCloneable<Poisonous>
    {
        // int duration = 0;
        
        public Poisonous(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.Poisonous;
            occasion = GameTerms.TokenOccasion.Calculation;
            value0 = v0; // posoned duration
            priority = 60;
            isDynamic = true;
            isDisplayed = true;
        }

        public override void Yeild()
        {
            //이번 턴에 공격 성공하였으면 상대에게 Poisoned(d) 전달
            if (GameTool.IsGivingDamage(characterIndex) == true)
            {
                GameBoard.Instance().FindOpponent(characterIndex).GetLastPlayData().Combine(new Poisoned(value0));
                isTrigged = true;
            }
        }
        public new Poisonous Clone()
        {
            return base.Clone() as Poisonous;
        }
    }
}