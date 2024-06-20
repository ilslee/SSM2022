using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class LifeArms : BasicArms
    {
        private float[] maxHealth;
        private float[] startHealth;
        public LifeArms(int grade = 0): base(grade){
            
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartGame, SetStatOnStart));
        }
        internal override void InitializeNumbers()
        {
            maxSwordPower =     new float[3]{3f,4f,5f};
            startSwordPower =   new float[3]{1f,1f,2f};
            maxShieldPower =       new float[3]{3f,4f,5f};
            startShieldPower =     new float[3]{1f,1f,2f};

            maxHealth =     new float[3]{1f,2f,3f};
            startHealth =   new float[3]{1f,2f,3f};
        }
        public override void SetStatOnStart(Character me, Character other){
            // base.SetStatOnStart(me, other);
            // me.maxStat.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Max, maxHealth[grade]));
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current, startHealth[grade]));
        }
    }
}