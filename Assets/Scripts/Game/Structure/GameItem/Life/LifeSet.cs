using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class LifeSet : Item
    {
        public LifeSet(int grade = 0): base(grade){
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartGame, SetStatOnStart));
            if(grade == 0) stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnPoisonGive, EnhancePoison));
            if(grade == 1) stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnConsequence, GainTrueDamageOnPoisonedEnemy));
            if(grade == 2) stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartGame, FasterHealthRecovery));
        }

        private void EnhancePoison(Character me, Character other){ //중독 상태 1증가
            // other.GetLastPlayData().token.Find(GameTerms.StatTokenType.Poison, GameTerms.StatTokenCategory.Take).value0 += 1f;
        }
        private void GainTrueDamageOnPoisonedEnemy(Character me, Character other){ // 중독수치만큼 고정데미지
            // if(me.GetLastPlayData().token.Has(GameTerms.StatTokenType.Damage, GameTerms.StatTokenCategory.Give) == true){
            //     other.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.TrueDamage, GameTerms.StatTokenCategory.Take, 1f));
            // }
        }
        private void FasterHealthRecovery(Character me, Character other){ // 체력회복 주기 1턴씩 감소
        /*
            LifeChest lifeChestItem = (LifeChest) me.item.Find(i => i is LifeChest);
            if(lifeChestItem == null) {
                Debug.LogError("LifeSet.FasterHealthRecovery : Cannot Fine lifeChestItem.");
                return;
            }
            for (int i = 0; i < lifeChestItem.healthRecoveryTurnCounter.Length; i++)
            {
                lifeChestItem.healthRecoveryTurnCounter[i] -= 1f;
            }
          */  
        }
    }
}