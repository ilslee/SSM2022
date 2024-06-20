using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class LifeLegs : BasicLegs
    {
        public LifeLegs(int grade = 0): base(grade){
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnConsequence, RecoverHealthWithTaunt));            
        }
        internal override void InitializeNumbers()
        {
            avoidSteal = new float[3]{1f, 2f, 3f};
            avoidEnergeConversionRate = new float[3]{1f, 1f, 1f};
            tauntSteal = new float[3]{1f, 2f, 3f};
        }

        private void RecoverHealthWithTaunt(Character me, Character other){
            // if(me.GetLastPlayData().motion == GameTerms.Motion.Taunt && me.GetLastPlayData().collision == false){
            //     me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Gain, 1f));
            // }
        }
    }
}