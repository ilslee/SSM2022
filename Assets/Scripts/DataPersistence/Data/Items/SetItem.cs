using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.token;
namespace ssm.data.item{
    [CreateAssetMenu(fileName = "SetItem", menuName = "SSM/Item/Set")]
    public class SetItem : ItemData
    {
        public override void Reset(){
            base.Reset();
            part = Part.Set;
            family = Family.None;
        }
        private List<Token> GetData(){
            List<Token> s = new List<Token>();
            switch(family){
                case Family.Life:
                switch(grade){
                    case 3:
                    s.Add(new Token(GameTerms.TokenType.Transfusion, 1f));
                    s.Add(new Token(GameTerms.TokenType.Circulation, 2f));
                    s.Add(new Token(GameTerms.TokenType.Recovery, 5f));
                    break;
                    case 2:
                    s.Add(new Token(GameTerms.TokenType.Transfusion, 1f));
                    s.Add(new Token(GameTerms.TokenType.Circulation, 2f));
                    break;
                    case 1:
                    s.Add(new Token(GameTerms.TokenType.Transfusion, 1f));
                    break;
                }
                break;
            }
            return s;
        }
        public override void UpdateItemData()
        {
            tokens.Clear();
            tokens = GetData();            
        }
        
    }
}