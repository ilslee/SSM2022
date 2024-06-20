using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure{
    public class BasicHead : Item
    {
        public float[] maxHealth;
        public float[] startHealth;
        public float[] damageReduction;

        public BasicHead(int grade = 0): base(grade){
            InitializeNumbers();
            
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartGame, SetStatOnStart));
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnDamageReduction, ReduceDamage));
        }

        internal virtual void InitializeNumbers(){
            maxHealth =     new float[3]{1f,2f,3f};
            startHealth =   new float[3]{1f,2f,3f};
            damageReduction =     new float[3]{0f,1f,2f};
        }

        internal void ReduceDamage(Character me, Character other){
            // me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Damage, GameTerms.StatTokenCategory.Take).value0 -= damageReduction[grade];            
        }

        internal void SetStatOnStart(Character me, Character other){
            
            // me.maxStat.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Max, maxHealth[grade]));
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current, startHealth[grade]));
            
        }
    }
}