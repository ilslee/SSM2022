using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class DeathHead : BasicHead
    {
        private float[] damageReductionMax;
        public DeathHead(int grade = 0): base(grade){
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnDamageReduction, DamageReductionPerHealthLoss));            
        }
        internal override void InitializeNumbers(){
            maxHealth =     new float[3]{2f,5f,9f};
            startHealth =   new float[3]{2f,5f,9f};
            damageReduction =     new float[3]{0f,0f,0f};
            damageReductionMax = new float[3]{2f, 3f, 4f};
        }

        private void DamageReductionPerHealthLoss(Character me, Character other){
            // float healthLossCounter = 5f;
            // StatTokenList target = me.GetLastPlayData().token;
            // float healthLoss = me.maxStat.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Max).value0 - 
            //                     target.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current).value0;
            // float damageReduction = Mathf.Floor(healthLoss / healthLossCounter);
            // damageReduction = Mathf.Min(damageReduction, damageReductionMax[grade]);
            // target.Find(GameTerms.StatTokenType.Damage, GameTerms.StatTokenCategory.Take).value0 -= damageReduction;
        }
    
    }
    
}
