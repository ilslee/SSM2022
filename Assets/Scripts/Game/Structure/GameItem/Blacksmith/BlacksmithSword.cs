using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class Sword : BasicSword
    {
        private float[] poisonDamage;
        public Sword(int grade = 0): base(grade){
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnConsequence, PoisonWhenGivingDamageWithSword));            
        }
        internal override void InitializeNumbers()
        {
            attackPower = new float[3]{1f, 2f, 3f};
            strikePower = new float[3]{1f, 2f, 3f};
            strikeMaxEnergeConsumption = new float[3]{2f, 3f, 4f};
            strikeEnergeConversionRate = new float[3]{1f, 1.25f, 1.5f};

         
        }
    }
}