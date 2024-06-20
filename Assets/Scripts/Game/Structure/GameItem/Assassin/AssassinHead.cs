using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class AssassinHead : BasicHead
    {
        public AssassinHead(int grade = 0): base(grade){
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnDamageReduction, ReduceAdditionalDamage));            
        }
        internal override void InitializeNumbers(){
            maxHealth =     new float[3]{2f,5f,9f};
            startHealth =   new float[3]{2f,5f,9f};
            damageReduction =     new float[3]{0f,1f,2f};
        }
    
    }
    
}