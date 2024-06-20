using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class DeathLegs : BasicLegs
    {
        private float[] healthLossCounter;
        public DeathLegs(int grade = 0): base(grade){
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionDefence, GainPowerPerHealthLossOnDefence));
        }
        internal override void InitializeNumbers()
        {
            avoidSteal = new float[3]{1f, 2f, 3f};
            avoidEnergeConversionRate = new float[3]{1f, 1f, 1f};
            tauntSteal = new float[3]{1f, 2f, 3f};
            healthLossCounter = new float[3]{5f, 4f, 3f};

        }

        private void GainPowerPerHealthLossOnDefence(Character me, Character other){            
            // float healthLoss = me.maxStat.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Max).value0 - 
            //                     me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current).value0;
            // float powerGain = Mathf.Floor(healthLoss / healthLossCounter[grade]);
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Defensive, powerGain));
        }
    }
}