using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.token;
namespace ssm.data.item{
    [CreateAssetMenu(fileName = "BodyItem", menuName = "SSM/Item/Body")]
    public class BodyItem : ItemData
    {
        
        public override void Reset(){
            base.Reset();
            part = Part.Body;
            family = Family.None;            
        }
        private BodyItemDataContainer GetData(){
            switch(family){
                case Family.Basic:
                switch(grade){
                    case 0:
                    return new BodyItemDataContainer(5f,5f,3f,0f,GameTerms.TokenType.None, 0f);    
                    case 1:
                    return new BodyItemDataContainer(5f,5f,3f,0f,GameTerms.TokenType.None, 0f);    
                    case 2:
                    return new BodyItemDataContainer(15f,15f,4f,0f,GameTerms.TokenType.None, 0f);    
                    case 3:
                    return new BodyItemDataContainer(25f,25f,5f,0f,GameTerms.TokenType.None, 0f);    
                }
                break;
                case Family.Life:
                switch(grade){
                    case 0:
                    return new BodyItemDataContainer(13f,13f,4f,0f,GameTerms.TokenType.None, 0f);    
                    case 1:
                    return new BodyItemDataContainer(13f,13f,4f,0f,GameTerms.TokenType.Regeneration, 7f);    
                    case 2:
                    return new BodyItemDataContainer(25f,25f,5f,0f,GameTerms.TokenType.Regeneration, 7f);    
                    case 3:
                    return new BodyItemDataContainer(37f,37f,6f,0f,GameTerms.TokenType.Regeneration, 7f);    
                }
                break;
            }
            return new BodyItemDataContainer(0f,0f,0f,0f,GameTerms.TokenType.None, 0f);            
        }
        public override void UpdateItemData()
        {
            BodyItemDataContainer b = GetData();
            tokens = new List<Token>();
            tokens.Add(new Token(GameTerms.TokenType.HPMax, b.hpMax));
            tokens.Add(new Token(GameTerms.TokenType.HPCurrent, b.hpCurrent));
            tokens.Add(new Token(GameTerms.TokenType.EPMax, b.epMax));
            tokens.Add(new Token(GameTerms.TokenType.EPCurrent, b.epCurrent));
            
            if(b.additionalToken == GameTerms.TokenType.None)return;
            else{
                tokens.Add(new Token(b.additionalToken, b.additionalValue));
            }
        }
        private class BodyItemDataContainer{
            internal float hpMax;
            internal float hpCurrent;
            internal float epMax;
            internal float epCurrent;
            internal GameTerms.TokenType additionalToken;
            internal float additionalValue;
            internal BodyItemDataContainer(float hm, float hc, float em, float ec, GameTerms.TokenType adt, float adv){
                hpMax = hm;
                hpCurrent = hc;
                epMax = em;
                epCurrent = ec;
                
                additionalToken = adt;
                additionalValue = adv;
            }
        }
    }
}