using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class EmperorArms : BasicArms
    {
        public EmperorArms(int grade = 0): base(grade){
            
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartGame, SetStatOnStart));
        }
        internal override void InitializeNumbers()
        {
            maxSwordPower =     new float[3]{3f,4f,5f};
            startSwordPower =   new float[3]{1f,1f,2f};
            maxShieldPower =       new float[3]{3f,4f,5f};
            startShieldPower =     new float[3]{1f,1f,2f};
            
        }
    }
}