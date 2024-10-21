using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.token;
namespace ssm.data.item{
    [CreateAssetMenu(fileName = "SwordItem", menuName = "SSM/Item/Sword")]
    public class SwordData : ItemData
    {
        public override void Reset(){
            base.Reset();
            part = Part.Sword;
            tokens = new List<Token>();
            
            Token attackPower = new Token();
            attackPower.type = GameTerms.TokenType.AttackPower;
            attackPower.value = 0f;
            Token attackEfficiency = new Token();
            attackEfficiency.type = GameTerms.TokenType.AttackEfficiency;
            attackEfficiency.value = 0f;
            
            Token strikePower = new Token();
            strikePower.type = GameTerms.TokenType.StrikePower;
            strikePower.value = 0f;
            Token strikeEfficiency = new Token();
            strikeEfficiency.type = GameTerms.TokenType.StrikeEfficiency;
            strikeEfficiency.value = 0f;
            Token strikeConsumption = new Token();
            strikeConsumption.type = GameTerms.TokenType.StrikeConsumption;
            strikeConsumption.value = 0f;

            tokens.Add(attackPower);   
            tokens.Add(attackEfficiency);   
            tokens.Add(strikePower);   
            tokens.Add(strikeEfficiency);   
            tokens.Add(strikeConsumption);   
        }
    }
}