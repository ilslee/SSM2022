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
    public class Poisonous : GameToken
    {
        int duration = 0;
        
        public Poisonous(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.Poisonous;
            occasion = GameTerms.TokenOccasion.Calculation;
            duration = (int)v0;
            priority = 60;
            isDynamic = false;
            isDisplayed = true;
        }

        public override void Yeild()
        {
            //이번 턴에 공격 성공하였으면 상대에게 Poisoned(d) 전달
            if(GameTool.IsGivingDamage(characterIndex) == true){
                GameBoard.Instance().FindOpponent(characterIndex).GetLastPlayData().Combine(new Poisoned((float)duration));
            }
        }
        public override int GetTokenValue()
        {
            return duration;
        }
    }
}