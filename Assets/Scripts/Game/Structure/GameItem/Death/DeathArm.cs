using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class DeathArms : BasicArms
    {
        private float[] healthLossCounter;
        
        public DeathArms(int grade = 0): base(grade){
            
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnDamageGain, GainDamagePerHealthLoss));
        }
        internal override void InitializeNumbers()
        {
            maxSwordPower =     new float[3]{3f,4f,5f};
            startSwordPower =   new float[3]{1f,1f,2f};
            maxShieldPower =       new float[3]{3f,4f,5f};
            startShieldPower =     new float[3]{1f,1f,2f};
            
            healthLossCounter = new float[3]{5f, 4f, 3f};
            
        }

        private void GainDamagePerHealthLoss(Character me, Character other){
            // StatTokenList target = me.GetLastPlayData().token;
            // float healthLoss = me.maxStat.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Max).value0 - 
            //                     target.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current).value0;
            // float damageGain = Mathf.Floor(healthLoss / healthLossCounter[grade]);

            // if(target.Find(GameTerms.StatTokenType.Damage, GameTerms.StatTokenCategory.Give).value0 > 0f){
            //     target.Combine(new StatToken(GameTerms.StatTokenType.Damage, GameTerms.StatTokenCategory.Give, damageGain));
            // }
        }
    }
}