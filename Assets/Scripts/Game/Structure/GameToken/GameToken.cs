using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ssm.data.token;
using UnityEngine;

namespace ssm.game.structure.token{

    [Serializable]
    public class GameToken : IGameTokenCloneable<GameToken>
    {
        public int characterIndex;
        public GameTerms.TokenType type;
        public GameTerms.TokenOccasion occasion;
        public float value0;
        public int priority;
        //isDynamic : PlayData History상 비교 판단할 필요가 있는 정보면 dynamic
        public bool isDynamic; //static Token List(false) 혹은 playdata(true) 배치 여부
        public bool isDisplayed; //UI창에 표시 여부
        public bool isTrigged; //이번 턴에 트리 되었는지 여부. 깜빡일 일이 있으면 모두 true
        public GameToken()
        {
            characterIndex = 0;
            type = GameTerms.TokenType.None;
            occasion = GameTerms.TokenOccasion.None;
            value0 = 0f;
            priority = 50;
            isDynamic = false;
            isDisplayed = false;
            isTrigged = false;
        }
        //Character Index는 Combine에서 처리
        public GameToken(float v0, bool dynamic = false)
        {
            characterIndex = 0;
            type = GameTerms.TokenType.None;
            occasion = GameTerms.TokenOccasion.None;
            value0 = v0;
            priority = 50;
            isDynamic = dynamic;
            isDisplayed = false;
            isTrigged = false;
        }
        //Power 같은 거 처리할 때
        public GameToken(GameTerms.TokenOccasion o, float v0, bool dynamic = false)
        {
            characterIndex = 0;
            type = GameTerms.TokenType.None;
            occasion = o;
            value0 = v0;
            priority = 50;
            isDynamic = dynamic;
            isDisplayed = false;
            isTrigged = false;
        }
        public GameToken(GameTerms.TokenType t, GameTerms.TokenOccasion o, float v = 0f, bool dynamic = false)
        {
            characterIndex = 0;
            type = t;
            occasion = o;
            value0 = v;
            priority = 50;
            isDynamic = dynamic;
            isDisplayed = false;  
            isTrigged = false;
        }  
        //아이템 데이터 등 특정 인덱스를 특정하지 않는 경우
        
        public virtual GameToken Clone(){
            GameToken returnVal = new GameToken(characterIndex);
            returnVal.type = this.type;
            returnVal.occasion = this.occasion;
            returnVal.value0 = this.value0;        
            returnVal.priority = this.priority;       
            returnVal.isDynamic = this.isDynamic;
            returnVal.isDisplayed = this.isDisplayed;  
            returnVal.isTrigged = false; 
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
            return (int)value0;
        }
        internal Character Me(){
            return GameBoard.Instance().FindCharacter(characterIndex);
        }
        internal Character Other(){
            return GameBoard.Instance().FindOpponent(characterIndex);
        }
    }

    public static class GameTokenConverter
    {
        //Static, Dynamic 기본으로 생성되는 토큰 중 개별 생성이 필요한 토큰이 있으면 그때마다 교환할 것
        public static GameToken Convert(Token t)
        {
            switch (t.type)
            {
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
                //Life
                case GameTerms.TokenType.Circulation:
                    return new Circulation(t.value);
                case GameTerms.TokenType.Circulating:
                    return new Circulating(t.value);
                case GameTerms.TokenType.Nurture:
                    return new Nurture(t.value);
                case GameTerms.TokenType.Poisoned:
                    return new Poisoned(t.value);
                case GameTerms.TokenType.Poisonous:
                    return new Poisonous(t.value);
                case GameTerms.TokenType.Recovery:
                    return new Recovery(t.value);
                case GameTerms.TokenType.Regeneration:
                    return new Regeneration(t.value);
                case GameTerms.TokenType.Transfusion:
                    return new Transfusion(t.value);
                case GameTerms.TokenType.Vigor:
                    return new Vigor(t.value);

                //Power, Efficiency, Consumptions : PowerInfoGenerator(Except AvoidAdaptiveConsumption)
                case GameTerms.TokenType.AttackPower:
                    return new PowerInfoGenerator(GameTerms.TokenType.Power, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Attack, t.value);
                case GameTerms.TokenType.AttackEfficiency:
                    return new PowerInfoGenerator(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Attack, t.value);
                case GameTerms.TokenType.StrikePower:
                    return new PowerInfoGenerator(GameTerms.TokenType.Power, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Strike, t.value);
                case GameTerms.TokenType.StrikeEfficiency:
                    return new PowerInfoGenerator(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Strike, t.value);
                
                case GameTerms.TokenType.DefencePower:
                    return new PowerInfoGenerator(GameTerms.TokenType.Power, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Defence, t.value);
                case GameTerms.TokenType.DefenceEfficiency:
                    return new PowerInfoGenerator(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Defence, t.value);
                case GameTerms.TokenType.ChargePower:
                    return new PowerInfoGenerator(GameTerms.TokenType.Power, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Charge, t.value);
                case GameTerms.TokenType.ChargeEfficiency:
                    return new PowerInfoGenerator(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Charge, t.value);
                
                case GameTerms.TokenType.RestPower:
                    return new PowerInfoGenerator(GameTerms.TokenType.Power, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Rest, t.value);
                case GameTerms.TokenType.AvoidPower:
                    return new PowerInfoGenerator(GameTerms.TokenType.Power, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Avoid, t.value);
                case GameTerms.TokenType.AvoidEfficiency:
                    return new PowerInfoGenerator(GameTerms.TokenType.Efficiency, MultiTypeToken.SubType.Base, GameTerms.TokenOccasion.Avoid, t.value);
                
                    

                //Default  
                case GameTerms.TokenType.HPMax:
                case GameTerms.TokenType.EPMax:
                case GameTerms.TokenType.SwordEPAvailable:
                case GameTerms.TokenType.ShieldEPAvailable:
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

    public interface IGameTokenCloneable<T>
    {
        T Clone();
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
            this.Sort(ComparePriority);            
        }
        public void Combine(GameToken t){
            // Debug.Log("?????? " + t.GetType().Name);
            GameToken? resulttoken = this.Find(x => x.type == t.type && x.occasion == t.occasion);
            if(resulttoken != null ) resulttoken.Combine(t);
            else{
                t.characterIndex = this.characterIndex;
                this.Add(t);
            }
            this.Sort(ComparePriority);
        }
        public void CombineMTT(MultiTypeToken t){
            // Debug.Log("?????? " + t.GetType().Name);
            MultiTypeToken? resulttoken = this.Find(x => x is MultiTypeToken && x.type == t.type && x.occasion == t.occasion && (x as MultiTypeToken).subType ==t.subType) as MultiTypeToken;
            if(resulttoken != null ) resulttoken.Combine(t);
            else{
                t.characterIndex = this.characterIndex;
                this.Add(t);
            }
            this.Sort(ComparePriority);
        }
        private int ComparePriority(GameToken t1, GameToken t2)
        {
            return t1.priority.CompareTo(t2.priority);
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
                                this.Find(x => x is not PowerInfoGenerator && x.type == t):
                                this.Find(x => x is not PowerInfoGenerator && x.type == t && x.occasion == o);
            
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
            List<GameToken> resulttoken = this.FindAll(x => x is not PowerInfoGenerator && x.occasion == o);
            TokenList returnVal = new TokenList(characterIndex);
            foreach(GameToken tk in resulttoken){
                returnVal.Combine(tk);
            }
            return returnVal;
        }
        public MultiTypeToken FindMTT(GameTerms.TokenType t, MultiTypeToken.SubType s, GameTerms.TokenOccasion o)
        {
            MultiTypeToken? resulttoken = this.Find(x => x is MultiTypeToken && x is not PowerInfoGenerator && 
                                                    x.type == t && x.occasion == o && (x as MultiTypeToken).subType == s) as MultiTypeToken;
            if (resulttoken != null) return resulttoken;
            else return new MultiTypeToken();
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