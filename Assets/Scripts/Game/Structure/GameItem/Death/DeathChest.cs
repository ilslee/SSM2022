using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class DeathChest : BasicChest
    {
        public float[] overcomingDeathThreshold;
        public DeathChest(int grade = 0): base(grade){
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartTurn, OvercomeDeath));            
        }
        internal override void InitializeNumbers()
        {
            maxHealth =     new float[3]{3f,7f,11f};
            startHealth =   new float[3]{3f,7f,11f};
            maxEnergy =     new float[3]{3f,4f,5f};
            overcomingDeathThreshold =     new float[3]{1f,2f,3f};
        }

        private void OvercomeDeath(Character me, Character othre){
            // StatTokenList target = me.GetLastPlayData().token;
            // float currentHealth =  target.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current).value0;
            // if(currentHealth <= overcomingDeathThreshold[grade] && target.Has(GameTerms.StatTokenType.OvercomingDeath) == false){
            //     target.Combine(new StatToken(GameTerms.StatTokenType.OvercomingDeath, GameTerms.StatTokenCategory.Gain, overcomingDeathThreshold[grade]));
            // }
        }
    }
}