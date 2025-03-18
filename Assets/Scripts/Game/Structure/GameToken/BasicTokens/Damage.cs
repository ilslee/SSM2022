using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;
namespace ssm.game.structure.token{
    public class Damage : GameToken
    {
        public bool isGivingDamage;
        public Damage(bool i, float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.Damage;
            occasion = GameTerms.TokenOccasion.Calculation;
            isGivingDamage = i;
            isDynamic = true;
        }
        public override void Yeild()
        {
            if(isGivingDamage == false){
                HPCurrent hpModifier = new HPCurrent(value0 * -1f);
                // HPCurrent 
                GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Combine(hpModifier);
            }
            
        }
    }
}
