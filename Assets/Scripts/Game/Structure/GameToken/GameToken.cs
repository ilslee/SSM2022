using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ssm.data.token;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace ssm.game.structure.token{

    [Serializable]
    public class GameToken
    {
        public int characterIndex;
        public GameTerms.TokenType type;
        public GameTerms.TokenOccasion occasion;
        public float value0;
        public int priority;
        public bool isDisplayed; //UI창에 표시 여부
        public GameToken() {
            characterIndex = 0;
            type = GameTerms.TokenType.None;
            occasion = GameTerms.TokenOccasion.None;
            value0 = 0f;    
            priority = 50;
            isDisplayed = false;
        }
        //Character Index는 Combine에서 처리
        public GameToken(float v0) {
            characterIndex = 0;
            type = GameTerms.TokenType.None;
            occasion = GameTerms.TokenOccasion.None;
            value0 = v0;    
            priority = 50;
        }
        //Power 같은 거 처리할 때
        public GameToken(GameTerms.TokenOccasion o, float v0) {
            characterIndex = 0;
            type = GameTerms.TokenType.None;
            occasion = o;
            value0 = v0;    
            priority = 50;
        }
        public GameToken(GameTerms.TokenType t, GameTerms.TokenOccasion o, float v = 0f){
            characterIndex = 0;
            type = t;
            occasion = o;
            value0 = v;    
            priority = 50;     
        }  
        //아이템 데이터 등 특정 인덱스를 특정하지 않는 경우
        
        public GameToken Clone(){
            GameToken returnVal = new GameToken(characterIndex);
            returnVal.type = this.type;
            returnVal.occasion = this.occasion;
            returnVal.value0 = this.value0;        
            returnVal.priority = this.priority;        
            return returnVal;
        }
        public virtual void Combine(GameToken t){
            value0 += t.value0;
        }
        public virtual void Yeild(){
            // TokenList returnVal = new TokenList();
            // return returnVal;
        }
        //삭제 조건을 만족하면 true 반환
        public virtual bool IsRemobable(){
            return false;
        }
        public override string ToString(){
            return "  GameToken: " + type.ToString() + ", " +occasion.ToString() + ", " +value0.ToString() + " / " +priority.ToString() + "("+characterIndex.ToString()+")";
        }
        //토큰이 숫자를 포함하는 경우 반환. UI 표기 시 사용
        public virtual int GetTokenValue(){
            return -1;
        }
        internal Character Me(){
            return GameBoard.Instance().FindCharacter(characterIndex);
        }
        internal Character Other(){
            return GameBoard.Instance().FindOpponent(characterIndex);
        }
    }

    public static class GameTokenConverter{
        //Static, Dynamic 기본으로 생성되는 토큰 중 개별 생성이 필요한 토큰이 있으면 그때마다 교환할 것
        public static GameToken Convert(Token t){
            switch(t.type){
                case GameTerms.TokenType.HPCurrent:
                return new HPCurrent(t.value);
                
                case GameTerms.TokenType.EPCurrent:
                return new EPCurrent(t.value);
                case GameTerms.TokenType.RestGeneration:
                return new RestGeneration(t.value); 
                case GameTerms.TokenType.AvoidGeneration:
                return new AvoidGeneration(t.value); 
                case GameTerms.TokenType.CollisionGeneration:
                return new CollisionGeneration(t.value);
                //Default - Static 
                case GameTerms.TokenType.HPMax:
                case GameTerms.TokenType.EPMax:

                case GameTerms.TokenType.AttackPower:
                case GameTerms.TokenType.AttackEfficiency:
                case GameTerms.TokenType.StrikePower:
                case GameTerms.TokenType.StrikeEfficiency:
                case GameTerms.TokenType.StrikeConsumption:

                case GameTerms.TokenType.DefencePower:
                case GameTerms.TokenType.DefenceEfficiency:
                case GameTerms.TokenType.ChargePower:
                case GameTerms.TokenType.ChargeEfficiency:
                case GameTerms.TokenType.ChargeConsumption:

                case GameTerms.TokenType.RestPower:
                case GameTerms.TokenType.AvoidPower:
                case GameTerms.TokenType.AvoidEfficiency:
                case GameTerms.TokenType.AvoidAdaptiveConsumption:
                return new GameToken(t.type, GameTerms.TokenOccasion.Static, t.value);
                
                //break;
                // case GameTerms.TokenType.EPMax:
                // case GameTerms.TokenType.EPMax:
                // case GameTerms.TokenType.EPMax:

                 
            }
            return new GameToken();
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
        public GameToken ToToken(int g){
            GameToken returnVal = new GameToken();
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
    public class TokenList : List<GameToken>{
        // public TokenList() : base(){}
        public int characterIndex;
        public TokenList(int index = 0){
            characterIndex = index;
        }
        
        public void Combine(TokenList tk){
            foreach(GameToken t in tk){
                GameToken resulttoken = this.Find(x => x.type == t.type && x.occasion == t.occasion);
                if(resulttoken != null ) resulttoken.Combine(t);
                else {
                    t.characterIndex = this.characterIndex;
                    this.Add(t);
                }
            }
            SortByPriority();
        }
        public void Combine(GameToken t){
            // Debug.Log("?????? " + t.GetType().Name);
            GameToken resulttoken = this.Find(x => x.type == t.type && x.occasion == t.occasion);
            if(resulttoken != null ) resulttoken.Combine(t);
            else{
                t.characterIndex = this.characterIndex;
                this.Add(t);
            }
            SortByPriority();
        }
        private void SortByPriority(){
            this.Sort((t1,t2) => t1.priority.CompareTo(t2));
        }
        // public void Subtract(GameToken tk){
        //     GameToken resulttoken = this.Find(x => x.type == tk.type);
        //     if(resulttoken != null ) {
        //         resulttoken.value0 -= tk.value0;
        //         if(resulttoken.value0 < 0 ) this.Remove(resulttoken);
        //     }        
        // }
        public GameToken Find(GameTerms.TokenType t, GameTerms.TokenOccasion o = GameTerms.TokenOccasion.None){
            // Debug.Log("??? : " + t);
            GameToken resulttoken = o == GameTerms.TokenOccasion.None ? 
                                this.Find(x => x.type == t):
                                this.Find(x => x.type == t && x.occasion == o);
            
            if(resulttoken != null ) {
                // Debug.Log("Found Token " + t + " and Type is : " + resulttoken.GetType().Name);
                return resulttoken;
            }
            else {
                // Debug.LogError("Cannot Find Token type " + t.ToString());
                return new GameToken(0);        
            }
        }
        
        public TokenList FindAll(GameTerms.TokenOccasion o){
            List<GameToken> resulttoken = this.FindAll(x => x.occasion == o);
            TokenList returnVal = new TokenList(characterIndex);
            foreach(GameToken tk in resulttoken){
                returnVal.Combine(tk);
            }
            return returnVal;
        }


        public bool Has(GameTerms.TokenType t){
            GameToken resulttoken = this.Find(t);
            if(resulttoken.type == GameTerms.TokenType.None) return false;
            else return true;
        }
        
        public void RemoveGarbages(){
            for(int i = this.Count -1 ; i >= 0 ; i --){
                if(this[i].IsRemobable() == true) RemoveAt(i);
            }
        }

        public override string ToString(){
            string returnVal = "[GameToken List] " + this.Count.ToString();
            foreach(GameToken tk in this){
                returnVal += "\n" + tk.ToString();
            }
            return returnVal;
        }
    }
}