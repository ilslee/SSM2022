using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class DeathShield : BasicShield
    {
        private float[] healthLossCounter;
        public DeathShield(int grade = 0): base(grade){
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionDefence, GainPowerPerHealthLossOnDefence));            
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionCharge, GainPowerPerHealthLossOnDOffence));            
        }
        internal override void InitializeNumbers()
        {
            defencePower = new float[3]{4f,5f,6f};
            chargePower = new float[3]{0f,1f,2f};
            chargeMaxEnergeConsumption = new float[3]{3f,4f,5f};
            chargeEnergeConversionRate = new float[3]{1f,1.25f,1.5f};

            healthLossCounter = new float[3]{5f, 4f, 3f};
        }
        /*
        private float GetPowerGain(Character me){
            float healthLoss = me.maxStat.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Max).value0 - 
                                me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current).value0;
            float powerGain = Mathf.Floor(healthLoss / healthLossCounter[grade]);
            return powerGain;
        }
        private void GainPowerPerHealthLossOnDefence(Character me, Character other){            
            me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Defensive, GetPowerGain(me)));
        }
        private void GainPowerPerHealthLossOnDOffence(Character me, Character other){
            me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Offensive, GetPowerGain(me)));
        }
        */
    }
}