using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ssm.data.token;
namespace ssm.data.item{
    [CreateAssetMenu(fileName = "SwordItem", menuName = "SSM/Item/Sword")]
    public class SwordItem : ItemData
    {
        
        public override void Reset(){
            base.Reset();
            part = Part.Sword;
            family = Family.None;            
        }
        public override void UpdateItemData()
        {
            SwordItemDataContainer s = GetData();
            tokens = new List<Token>();
            tokens.Add(new Token(GameTerms.TokenType.AttackPower, s.attackPower));
            tokens.Add(new Token(GameTerms.TokenType.AttackEfficiency, s.attackEfficiency));
            tokens.Add(new Token(GameTerms.TokenType.StrikePower, s.StrikePower));
            tokens.Add(new Token(GameTerms.TokenType.StrikeEfficiency, s.strikeEfficiency));
            tokens.Add(new Token(GameTerms.TokenType.StrikeConsumption, s.strikeConsumption));
            if(s.additionalToken == GameTerms.TokenType.None)return;
            else{
                tokens.Add(new Token(s.additionalToken, s.additionalValue));
            }
        }
        
        private SwordItemDataContainer GetData(){
            switch(family){
                case Family.Basic:
                switch(grade){
                    case 0:
                    return new SwordItemDataContainer(3f, .5f, 2f, 3f, 2f, GameTerms.TokenType.None, 0f);
                    case 1:
                    return new SwordItemDataContainer(3f, .5f, 2f, 3f, 2f, GameTerms.TokenType.None, 0f);
                    case 2:
                    return new SwordItemDataContainer(4f, .5f, 3f, 3f, 3f, GameTerms.TokenType.None, 0f);
                    case 3:
                    return new SwordItemDataContainer(5f, .5f, 4f, 3f, 4f, GameTerms.TokenType.None, 0f);
                }
                break;
                case Family.Life:
                switch(grade){
                    case 0:
                    return new SwordItemDataContainer(4f, .5f, 3f, 3f, 2f, GameTerms.TokenType.None, 0f);
                    case 1:
                    return new SwordItemDataContainer(4f, .5f, 3f, 3f, 2f, GameTerms.TokenType.Poisonous, 2f);
                    case 2:
                    return new SwordItemDataContainer(5f, .5f, 4f, 3f, 3f, GameTerms.TokenType.Poisonous, 3f);
                    case 3:
                    return new SwordItemDataContainer(6f, .5f, 5f, 3f, 4f, GameTerms.TokenType.Poisonous, 4f);
                }
                break;
                default:
                return new SwordItemDataContainer(0f, 0f, 0f, 0f, 0f, GameTerms.TokenType.None, 0f);
            }
            
            return new SwordItemDataContainer(0f, 0f, 0f, 0f, 0f, GameTerms.TokenType.None, 0f);

        }

         

        private class SwordItemDataContainer{
            internal float attackPower;
            internal float attackEfficiency;
            internal float StrikePower;
            internal float strikeEfficiency;
            internal float strikeConsumption;
            internal GameTerms.TokenType additionalToken;
            internal float additionalValue;

            internal SwordItemDataContainer(float ap, float ae, float sp, float se, float sc, GameTerms.TokenType adt, float adv){
                attackPower = ap;
                attackEfficiency = ae;
                StrikePower = sp;
                strikeEfficiency = se;
                strikeConsumption = sc;
                additionalToken = adt;
                additionalValue = adv;
            }
        }    
    }
   
}