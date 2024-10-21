using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.token;
namespace ssm.data.item{
    [CreateAssetMenu(fileName = "LegItem", menuName = "SSM/Item/Leg")]
    public class LegData : ItemData
    {
        public override void Reset(){
            base.Reset();
            part = Part.Leg;
            tokens = new List<Token>();
            
            Token restPower = new Token();
            restPower.type = GameTerms.TokenType.RestPower;
            restPower.value = 0f;
            
            Token avoidPower = new Token();
            avoidPower.type = GameTerms.TokenType.AvoidPower;
            avoidPower.value = 0f;
            Token avoidEfficiency = new Token();
            avoidEfficiency.type = GameTerms.TokenType.AvoidEfficiency;
            avoidEfficiency.value = 0f;
            Token avoidConsumption = new Token();
            avoidConsumption.type = GameTerms.TokenType.AvoidAdaptiveConsumption;
            avoidConsumption.value = 0f;

            Token restGeneration = new Token();
            restGeneration.type = GameTerms.TokenType.RestGeneration;
            restGeneration.value = 0f;
            Token avoidGeneration = new Token();
            avoidGeneration.type = GameTerms.TokenType.AvoidGeneration;
            avoidGeneration.value = 0f;

            tokens.Add(restPower);   
            
            tokens.Add(avoidPower);   
            tokens.Add(avoidEfficiency);   
            tokens.Add(avoidConsumption);   

            tokens.Add(restGeneration);   
            tokens.Add(avoidGeneration);   
        }
    }
}