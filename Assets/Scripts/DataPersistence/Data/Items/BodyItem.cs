using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.token;
namespace ssm.data.item{
    [CreateAssetMenu(fileName = "BodyItem", menuName = "SSM/Item/Body")]
    public class BodyData : ItemData
    {
        public override void Reset(){
            base.Reset();
            part = Part.Body;
            tokens = new List<Token>();
            
            Token hpMax = new Token();
            hpMax.type = GameTerms.TokenType.HPMax;
            hpMax.value = 0f;
            Token hpCurrent = new Token();
            hpCurrent.type = GameTerms.TokenType.HPCurrent;
            hpCurrent.value = 0f;
            
            Token epMax = new Token();
            epMax.type = GameTerms.TokenType.EPMax;
            epMax.value = 0f;
            Token epCurrent = new Token();
            epCurrent.type = GameTerms.TokenType.EPCurrent;
            epCurrent.value = 0f;
            

            tokens.Add(hpMax);   
            tokens.Add(hpCurrent);   
            tokens.Add(epMax);   
            tokens.Add(epCurrent);   
            
        }
    }
}