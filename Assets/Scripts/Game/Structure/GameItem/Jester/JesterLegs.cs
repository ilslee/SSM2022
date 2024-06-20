using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class JesterLegs : BasicLegs
    {
        public JesterLegs(int grade = 0): base(grade){
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnConsequence, RecoverHealthWithTaunt));            
        }
        internal override void InitializeNumbers()
        {
            avoidSteal = new float[3]{1f, 2f, 3f};
            avoidEnergeConversionRate = new float[3]{1f, 1f, 1f};
            tauntSteal = new float[3]{1f, 2f, 3f};
        }

        
    }
}