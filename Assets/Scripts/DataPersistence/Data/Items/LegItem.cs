using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.token;
using ssm.game.structure.token;
namespace ssm.data.item{
    [CreateAssetMenu(fileName = "LegItem", menuName = "SSM/Item/Leg")]
    public class LegData : ItemData
    {
        public override void Reset(){
            base.Reset();
            part = Part.Leg;
            
        }
        public override void UpdateItemData()
        {
            LegItemDataContainer l = GetData();
            tokens = new List<Token>();
            tokens.Add(new Token(GameTerms.TokenType.RestPower, l.restPower));
            tokens.Add(new Token(GameTerms.TokenType.RestGeneration, l.restGeneration));
            tokens.Add(new Token(GameTerms.TokenType.AvoidPower, l.avoidPower));
            tokens.Add(new Token(GameTerms.TokenType.AvoidEfficiency, l.avoidEfficiency));
            tokens.Add(new Token(GameTerms.TokenType.AvoidAdaptiveConsumption, 0f));
            tokens.Add(new Token(GameTerms.TokenType.AvoidGeneration, l.avoidGeneration));
            
            if(l.additionalToken == GameTerms.TokenType.None)return;
            else{
                tokens.Add(new Token(l.additionalToken, l.additionalValue));
            }
        }
        private LegItemDataContainer GetData(){
            switch(family){
                case Family.Basic:
                switch(grade){
                    case 0:
                    return new LegItemDataContainer(0f, 1f, 1f, 1f, 1f, GameTerms.TokenType.None, 0f);
                    case 1:
                    return new LegItemDataContainer(0f, 1f, 1f, 1f, 1f, GameTerms.TokenType.None, 0f);
                    case 2:
                    return new LegItemDataContainer(1f, 2f, 1f, 2f, 2f, GameTerms.TokenType.None, 0f);
                    case 3:
                    return new LegItemDataContainer(2f, 3f, 1f, 3f, 3f, GameTerms.TokenType.None, 0f);
                }
                break;
                case Family.Life:
                switch(grade){
                    case 0:
                    return new LegItemDataContainer(0f, 1f, 1f, 2f, 1f, GameTerms.TokenType.None, 0f);
                    case 1:
                    return new LegItemDataContainer(0f, 1f, 1f, 2f, 1f, GameTerms.TokenType.Vigor, 100f);
                    case 2:
                    return new LegItemDataContainer(1f, 2f, 1f, 3f, 2f, GameTerms.TokenType.Vigor, 90f);
                    case 3:
                    return new LegItemDataContainer(2f, 3f, 1f, 4f, 3f, GameTerms.TokenType.Vigor, 80f);
                }
                break;
            }
            return new LegItemDataContainer(0f, 0f, 0f, 0f, 0f, GameTerms.TokenType.None, 0f);

        }
        private class LegItemDataContainer {
            internal float restPower;
            internal float restGeneration;
            internal float avoidPower;
            internal float avoidEfficiency;
            // internal float avoidAdaptiveConsumption; // value 필요 없음
            internal float avoidGeneration;
            internal GameTerms.TokenType additionalToken;
            internal float additionalValue;
            internal LegItemDataContainer(float rp, float rg, float ap, float ae, float ag, GameTerms.TokenType adt, float adv){
                restPower = rp;
                restGeneration = rg;
                avoidPower = ap;
                avoidEfficiency = ae;                
                avoidGeneration = ag;
                additionalToken = adt;
                additionalValue = adv;
            }
        }
    }
}