using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure{
    public class BasicArms : Item
    {
        internal float[] maxSwordPower;
        internal float[] startSwordPower;
        internal float[] maxShieldPower;
        internal float[] startShieldPower;
        public BasicArms(int grade = 0): base(grade){
            InitializeNumbers();

            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartGame, SetStatOnStart));
        }
        internal virtual void InitializeNumbers(){
            maxSwordPower =     new float[3]{2f,3f,4f};
            startSwordPower =   new float[3]{0f,0f,0f};
            maxShieldPower =       new float[3]{2f,3f,4f};
            startShieldPower =     new float[3]{0f,0f,0f};
        }

        public virtual void SetStatOnStart(Character me, Character other){
            
            // me.maxStat.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Max, maxSwordPower[grade]));
            // me.maxStat.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Max, maxShieldPower[grade]));
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Current, startSwordPower[grade]));
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Current, startShieldPower[grade]));
            
        }
    }
}