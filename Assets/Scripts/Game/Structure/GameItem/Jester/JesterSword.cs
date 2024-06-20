using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class JesterSword : BasicSword
    {
        private float[] poisonDamage;
        public JesterSword(int grade = 0): base(grade){
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionAttack, GiveShieldPowerOtherWithDefendingSword));            
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionStrike, GiveShieldPowerOtherWithDefendingSword));            
        }
        internal override void InitializeNumbers()
        {
            attackPower = new float[3]{1f, 2f, 3f};
            strikePower = new float[3]{1f, 2f, 3f};
            strikeMaxEnergeConsumption = new float[3]{2f, 3f, 4f};
            strikeEnergeConversionRate = new float[3]{1f, 1.25f, 1.5f};
        }

        private void GiveShieldPowerOtherWithDefendingSword(Character me, Character other){
            // other.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.ShieldPowerAgainstSword, GameTerms.StatTokenCategory.Gain));
        }
        /*
        private void CalculateAdditionalShieldPowerOther(Character me, Character other){
            bool isMeSword = (me.GetLastPlayData().motion == GameTerms.Motion.Attack || me.GetLastPlayData().motion == GameTerms.Motion.Strike )? true : false;
            bool isOtherShield = (other.GetLastPlayData().motion == GameTerms.Motion.Defence || other.GetLastPlayData().motion == GameTerms.Motion.Charge )? true : false;
            if(isMeSword == true && isOtherShield == true){
                // other.
            }
        }
        */
    }
}