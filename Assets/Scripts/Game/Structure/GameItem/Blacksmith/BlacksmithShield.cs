using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class BlacksmithShield : BasicShield
    {
        public BlacksmithShield(int grade = 0): base(grade){
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnConsequence, HealOtherWhenDefenceWorks));            
        }
        internal override void InitializeNumbers()
        {
            defencePower = new float[3]{4f,5f,6f};
            chargePower = new float[3]{0f,1f,2f};
            chargeMaxEnergeConsumption = new float[3]{3f,4f,5f};
            chargeEnergeConversionRate = new float[3]{1f,1.25f,1.5f};
        }
    }
}