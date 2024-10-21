using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    public class EPConsumption : GameToken
    {
        public float value1;
        public EPConsumption(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.EPConsumption;
            occasion = GameTerms.TokenOccasion.Consumption;
        }

        public override void Yeild()
        {
            //TODO
        }

        
    }
    
}
