using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure.token{
    /* 
    [중독]
    작동 : Poisonous - 데미지를 주면 - 상대방 Poisoned:d
    추가 : -
    */
    public class Transfusion : GameToken
    {
        private float transfusionAmount;    
        public Transfusion() : base(){
            transfusionAmount = 1f;
        }

        public override void Yeild()
        {
            //이번 턴에 공격 성공하였으면 상대에게 Poisoned(d) 전달
            Damage currentDamage = Me().GetLastPlayData().Find(GameTerms.TokenType.Damage) as Damage;
            if(currentDamage.isGivingDamage == true){
                Me().GetLastPlayData().Combine(new HPCurrent((float)transfusionAmount));
            }
        }
        public override int GetTokenValue()
        {
            return (int)transfusionAmount;
        }
    }

}