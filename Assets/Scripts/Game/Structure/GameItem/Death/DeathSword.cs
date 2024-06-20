using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class DeathSword : BasicSword
    {
        private float[] healthLossCounter;
        public DeathSword(int grade = 0): base(grade){
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionAttack, GainPowerPerHealthLoss));            
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionStrike, GainPowerPerHealthLoss));            
        }
        internal override void InitializeNumbers()
        {
            attackPower = new float[3]{1f, 2f, 3f};
            strikePower = new float[3]{1f, 2f, 3f};
            strikeMaxEnergeConsumption = new float[3]{2f, 3f, 4f};
            strikeEnergeConversionRate = new float[3]{1f, 1.25f, 1.5f};

            healthLossCounter = new float[3]{5f, 4f, 3f};
        }

        private void GainPowerPerHealthLoss(Character me, Character other){
            // float healthLoss = me.maxStat.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Max).value0 - 
            //                     me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current).value0;
            // float powerGain = Mathf.Floor(healthLoss / healthLossCounter[grade]);
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Offensive, powerGain));
        }
    }
}