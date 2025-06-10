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
            family = Family.None;
            
        }
        private ShieldItemDataContainer GetData(){
            switch(family){
                case Family.Basic:
                switch(grade){
                    case 0:
                    return new ShieldItemDataContainer(5f, .5f, 1f, 1f, 3f, 3f, GameTerms.TokenType.None, 0f);
                    case 1:
                    return new ShieldItemDataContainer(5f, .5f, 1f, 1f, 3f, 3f, GameTerms.TokenType.None, 0f);
                    case 2:
                    return new ShieldItemDataContainer(6f, .5f, 2f, 2f, 3f, 4f, GameTerms.TokenType.None, 0f);
                    case 3:
                    return new ShieldItemDataContainer(7f, .5f, 3f, 3f, 3f, 5f, GameTerms.TokenType.None, 0f);
                }
                break;
                case Family.Life:
                switch(grade){
                    case 0:
                    return new ShieldItemDataContainer(7f, .5f, 1f, 1f, 3f, 3f, GameTerms.TokenType.None, 0f);
                    case 1:
                    return new ShieldItemDataContainer(7f, .5f, 1f, 1f, 3f, 3f, GameTerms.TokenType.Nurture, 1f);
                    case 2:
                    return new ShieldItemDataContainer(8f, .5f, 2f, 2f, 3f, 4f, GameTerms.TokenType.Nurture, 1f);
                    case 3:
                    return new ShieldItemDataContainer(9f, .5f, 3f, 3f, 3f, 5f, GameTerms.TokenType.Nurture, 1f);
                }
                break;
            }
            return new ShieldItemDataContainer(0f, 0f, 0f, 0f, 0f, 0f, GameTerms.TokenType.None, 0f);
        }
        public override void UpdateItemData()
        {
            ShieldItemDataContainer s = GetData();
            tokens = new List<Token>();
            tokens.Add(new Token(GameTerms.TokenType.DefencePower, s.defencePower));
            tokens.Add(new Token(GameTerms.TokenType.DefenceEfficiency, s.defenceEfficiency));
            tokens.Add(new Token(GameTerms.TokenType.CollisionGeneration, s.collisionGeneration));
            tokens.Add(new Token(GameTerms.TokenType.ChargePower, s.chargePower));
            tokens.Add(new Token(GameTerms.TokenType.ChargeEfficiency, s.chargeEfficiency));
            tokens.Add(new Token(GameTerms.TokenType.ShieldEPAvailable, s.shieldEPAvailable));
            if(s.additionalToken == GameTerms.TokenType.None)return;
            else{
                tokens.Add(new Token(s.additionalToken, s.additionalValue));
            }
        }
        private class ShieldItemDataContainer{
            internal float defencePower;
            internal float defenceEfficiency;
            internal float collisionGeneration;
            internal float chargePower;
            internal float chargeEfficiency;
            internal float shieldEPAvailable;
            internal GameTerms.TokenType additionalToken;
            internal float additionalValue;

            internal ShieldItemDataContainer(float dp, float de, float cg, float cp, float ce, float cc, GameTerms.TokenType adt, float adv){
                defencePower = dp;
                defenceEfficiency = dp;
                collisionGeneration = dp;
                chargePower = cp;
                chargeEfficiency = ce;
                shieldEPAvailable = cc;
                additionalToken = adt;
                additionalValue = adv;

            }
        }
    }
}