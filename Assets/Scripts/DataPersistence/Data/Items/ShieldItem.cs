using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.token;
namespace ssm.data.item{
    [CreateAssetMenu(fileName = "ShieldItem", menuName = "SSM/Item/Shield")]
    public class ShieldData : ItemData
    {
        public override void Reset(){
            base.Reset();
            part = Part.Shield;
            tokens = new List<Token>();
            
            Token defencePower = new Token();
            defencePower.type = GameTerms.TokenType.DefencePower;
            defencePower.value = 0f;
            Token defenceEfficiency = new Token();
            defenceEfficiency.type = GameTerms.TokenType.DefenceEfficiency  ;
            defenceEfficiency.value = 0f;

            Token collisionGeneration = new Token();
            collisionGeneration.type = GameTerms.TokenType.CollisionGeneration;
            collisionGeneration.value = 1f;

            Token chargePower = new Token();
            chargePower.type = GameTerms.TokenType.ChargePower;
            chargePower.value = 0f;
            Token chargeEfficiency = new Token();
            chargeEfficiency.type = GameTerms.TokenType.ChargeEfficiency;
            chargeEfficiency.value = 0f;
            Token chargeConsumption = new Token();
            chargeConsumption.type = GameTerms.TokenType.ChargeConsumption;
            chargeConsumption.value = 0f;

            tokens.Add(defencePower);   
            tokens.Add(defenceEfficiency);   
            tokens.Add(collisionGeneration);   
            tokens.Add(chargePower);   
            tokens.Add(chargeEfficiency);   
            tokens.Add(chargeConsumption);   
        }
    }
}