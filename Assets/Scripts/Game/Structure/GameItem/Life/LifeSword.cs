using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure{
    public class LifeSword : BasicSword
    {
        private float[] poisonDamage;
        public LifeSword(int grade = 0): base(grade){
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnConsequence, PoisonWhenGivingDamageWithSword));            
        }
        internal override void InitializeNumbers()
        {
            attackPower = new float[3]{1f, 2f, 3f};
            strikePower = new float[3]{1f, 2f, 3f};
            strikeMaxEnergeConsumption = new float[3]{2f, 3f, 4f};
            strikeEnergeConversionRate = new float[3]{1f, 1.25f, 1.5f};

            poisonDamage = new float[3]{1f, 2f, 3f};
        }

        private void PoisonWhenGivingDamageWithSword(Character me, Character other){
            // if(me.GetLastPlayData().motion == GameTerms.Motion.Attack || me.GetLastPlayData().motion == GameTerms.Motion.Strike){
            //     if(me.GetLastPlayData().token.Has(GameTerms.StatTokenType.Damage, GameTerms.StatTokenCategory.Give) == true){
            //         me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Poison, GameTerms.StatTokenCategory.Give, poisonDamage[grade]));
            //         other.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Poison, GameTerms.StatTokenCategory.Take, poisonDamage[grade]));
            //         // me.item.Operate(StatTokenFactory.OperateType.OnPoisonGive, me, other);
            //     }
            // }
        }
    }
}