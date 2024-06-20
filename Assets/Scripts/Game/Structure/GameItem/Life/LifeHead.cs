using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class LifeHead : BasicHead
    {
        public LifeHead(int grade = 0): base(grade){
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnDamageReduction, ReduceAdditionalDamage));            
        }
        internal override void InitializeNumbers(){
            maxHealth =     new float[3]{2f,5f,9f};
            startHealth =   new float[3]{2f,5f,9f};
            damageReduction =     new float[3]{0f,1f,2f};
        }

        internal void ReduceAdditionalDamage(Character me, Character other){
            // float currentHealth = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current).value0;
            // float maxHealth = me.maxStat.Find(GameTerms.StatTokenType.Health).value0;
            // if(currentHealth >= maxHealth){
            //     me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Damage, GameTerms.StatTokenCategory.Take).value0 -= 1f;            
            // }
        }
    }
    
}