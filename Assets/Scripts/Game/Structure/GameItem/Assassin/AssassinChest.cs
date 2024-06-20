using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class AssassinChest : BasicChest
    {
        public AssassinChest(int grade = 0): base(grade){
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartTurn, RecoverHealthOccasionally));            
        }
        internal override void InitializeNumbers()
        {
            maxHealth =     new float[3]{3f,7f,11f};
            startHealth =   new float[3]{3f,7f,11f};
            maxEnergy =     new float[3]{3f,4f,5f};
        }
    }
}