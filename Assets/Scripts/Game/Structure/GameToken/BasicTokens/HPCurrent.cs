using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class HPCurrent : GameToken
    {
        public HPCurrent(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.HPCurrent;
            occasion = GameTerms.TokenOccasion.Dynamic;
        }

        
        public override void Combine(GameToken t)
        {
            if(type != t.type) return;
            value0 += t.value0;
            float maxHP = GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.HPMax).value0;
            if(value0 > maxHP) value0 = maxHP;
            else if(value0 < 0f) value0 = 0f;

        }
        public new HPCurrent Clone(){
            HPCurrent returnVal = new HPCurrent(characterIndex);
            returnVal.characterIndex = this.characterIndex;
            returnVal.type = this.type;
            returnVal.occasion = this.occasion;
            returnVal.value0 = this.value0;        
            returnVal.priority = this.priority;        
            return returnVal;
        }
    }
    
}
