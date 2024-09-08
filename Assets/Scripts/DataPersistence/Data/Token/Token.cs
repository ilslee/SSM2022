using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ssm.game.structure;
using Unity.VisualScripting;
using UnityEngine;

namespace ssm.data.token{

    [Serializable]
    public class Token
    {
        public int characterIndex;
        public GameTerms.TokenType type;
        public GameTerms.TokenOccasion occasion;
        public float value0;
        public int priority;
        public Token() {
            characterIndex = 0;
            type = GameTerms.TokenType.None;
            occasion = GameTerms.TokenOccasion.None;
            value0 = 0f;    
            priority = 50;
        }
        public Token(int chaID) {
            characterIndex = chaID;
            type = GameTerms.TokenType.None;
            occasion = GameTerms.TokenOccasion.None;
            value0 = 0f;    
            priority = 50;
        }
        public Token(int chaID, GameTerms.TokenType t, GameTerms.TokenOccasion o, float v = 0f){
            characterIndex = chaID;
            type = t;
            occasion = o;
            value0 = v;    
            priority = 50;     
        }  
        //아이템 데이터 등 특정 인덱스를 특정하지 않는 경우
        public Token(GameTerms.TokenType t, GameTerms.TokenOccasion o, float v = 0f){
            characterIndex = 0; 
            type = t;
            occasion = o;
            value0 = v;    
            priority = 50;     
        }
        public Token Clone(){
            Token returnVal = new Token(characterIndex);
            returnVal.type = this.type;
            returnVal.occasion = this.occasion;
            returnVal.value0 = this.value0;        
            returnVal.priority = this.priority;        
            return returnVal;
        }
        public virtual void Combine(Token t){
            value0 += t.value0;
        }
        public virtual TokenList Yeild(){
            TokenList returnVal = new TokenList();
            return returnVal;
        }
        public override string ToString(){
            return "  Token: " + type.ToString() + ", " +occasion.ToString() + ", " +value0.ToString() + " / " +priority.ToString();
        }
    }
    /*
    [Serializable]
    public class TokenGrade:TokenBase {
        public int grade;
        public float[] value0;

        public TokenGrade() : base(){
            value0 = new float[3]{0f, 0f, 0f};                
        }
        public Token ToToken(int g){
            Token returnVal = new Token();
            returnVal.category = this.category;
            returnVal.behaviour = this.behaviour;
            returnVal.occasion = this.occasion;
            returnVal.target = this.target;
            if(this.value0.Length < 1) returnVal.value0 = 0f;
            else returnVal.value0 = this.value0[g];        
            return returnVal;
    }

    
}
*/


    [Serializable]
    public class TokenList : List<Token>{
        // public TokenList() : base(){}

        public void Combine(TokenList tk){
            foreach(Token t in tk){
                Token resulttoken = this.Find(x => x.type == t.type && x.occasion == t.occasion);
                if(resulttoken != null ) resulttoken.Combine(t);
                else this.Add(t);
            }     
        }
        public void Combine(Token t){
            Token resulttoken = this.Find(x => x.type == t.type && x.occasion == t.occasion);
            if(resulttoken != null ) resulttoken.Combine(t);
            else this.Add(t);
        }
        // public void Subtract(Token tk){
        //     Token resulttoken = this.Find(x => x.type == tk.type);
        //     if(resulttoken != null ) {
        //         resulttoken.value0 -= tk.value0;
        //         if(resulttoken.value0 < 0 ) this.Remove(resulttoken);
        //     }        
        // }
        public Token Find(GameTerms.TokenType t, GameTerms.TokenOccasion o = GameTerms.TokenOccasion.None){
            
            Token resulttoken = o == GameTerms.TokenOccasion.None ? 
                                this.Find(x => x.type == t):
                                this.Find(x => x.type == t && x.occasion == o);
            
            if(resulttoken != null ) return resulttoken;
            else return new Token(0);        
        }
        
        public TokenList FindAll(GameTerms.TokenOccasion o){
            List<Token> resulttoken = this.FindAll(x => x.occasion == o);
            TokenList returnVal = new TokenList();
            foreach(Token tk in resulttoken){
                returnVal.Add(tk);
            }
            return returnVal;
        }


        public bool Has(GameTerms.TokenType t){
            Token resulttoken = this.Find(t);
            if(resulttoken.type == GameTerms.TokenType.None) return false;
            else return true;
        }
        
        public void OnTurnStart(Character me, Character other){
            
    }

    public override string ToString(){
        string returnVal = "[Token List] " + this.Count.ToString();
        foreach(Token tk in this){
            returnVal += "\n" + tk.ToString();
        }
        return returnVal;
    }
}
}