using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class EPCurrent : GameToken
    {
        public float value1;
        public EPCurrent(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.EPCurrent;
            occasion = GameTerms.TokenOccasion.Dynamic;
            isDynamic = true;
        }
        /*
        public override void Yeild()
        {
            PlayData myPlayData = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
            if(myPlayData.Has(GameTerms.TokenType.ActiveEfficieny) == true){
                float energyPower = myPlayData.Find(GameTerms.TokenType.EnergyPower).value0;
                float energyEfficiency = myPlayData.Find(GameTerms.TokenType.ActiveEfficieny).value0;
                float energyConsumption = Mathf.Ceil(energyPower / energyEfficiency);
                this.Combine(new GameToken(GameTerms.TokenType.EPCurrent, GameTerms.TokenOccasion.Dynamic, energyConsumption * -1f));
            }
        }
        */
        public override void Combine(GameToken t)
        {
            // Debug.Log("Hey Hey Hey");
            if(type != t.type) return;
            float prevValue = value0;
            value0 += t.value0;
            float maxEP = GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.EPMax).value0;
            if(value0 > maxEP) value0 = maxEP;
            else if(value0 < 0f) value0 = 0f;
            // Debug.Log("EP Current Modified : " + prevValue + " + " + t.value0 + " > " + value0 + " Out of " + maxEP);
        }

        public new EPCurrent Clone(){
            EPCurrent returnVal = new EPCurrent(characterIndex);
            returnVal.characterIndex = this.characterIndex;
            returnVal.type = this.type;
            returnVal.occasion = this.occasion;
            returnVal.value0 = this.value0;        
            returnVal.priority = this.priority;        
            return returnVal;
        }
    }
    
}
