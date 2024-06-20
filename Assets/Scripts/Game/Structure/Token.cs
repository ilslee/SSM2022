using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ssm.game.structure;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class TokenBase{
    public GameTerms.TokenType type;
    public Token.Category category;
    public Token.Behaviour behaviour;    
    public Token.Occasion occasion;
    public Token.Target target;
    public TokenBase(){
        category = Token.Category.None;
        behaviour = Token.Behaviour.None;
        occasion = Token.Occasion.None;
        target = Token.Target.None;
    }
}
[Serializable]
public class Token : TokenBase
{
    public enum Category{   None, Health, 
                            Energy, EnergyConversion, ConvertEnergyConsumptionTakeBakcToEnergyGain,
                            SwordPower, ShieldPower,
                            Power, BasePower, PowerFromEnerge, PowerFromGauge, AdditionalPower, Damage, 
                            InvalidDamageTakeByAttack, InvalidColisionByStrike, InvalidDefenceShieldPowerRecovery,                            
                            Poison, TrueDamage, ShieldPowerAgainstSword, SwordPowerAgainstDefence,
                            OvercomingDeath};
    public enum Behaviour{  None, Max, Current, GainNextTurn, LossNextTurn, Gain, GainWithNoCollision, Loss, 
                            Offensive, Defensive, Give, Take, Reduce, Steal, TakeBackExceed, Rate, Base, Additional, Energy, Gauge};
    public enum Target{     None, Me, Other};
    public enum Occasion{   None, OnStartGame, OnStartTurn, OnSource,OnPower, OnExceedEnergyTakeBack, OnDamageGain, OnDamageReduction, OnConsequence, OnFeedback,
                            OnPoisonGive, OnMotionAttack, OnMotionStrike, OnMotionDefence, OnMotionCharge, OnMotionAvoid, OnMotionTaunt, OnMotionNone, 
                            OnMotionSword, OnMotionShield, OnMotionMove
                            };

    
    public float value0;
    
    public Token() : base(){
        value0 = 0f;        
    }
    public Token(Category c, Behaviour b = Behaviour.None, Occasion o = Occasion.None, Target t = Target.Me, float v = 0f){
        category = c;
        behaviour = b;
        occasion = o;
        target = t;
        value0 = v;        
    }  
    public Token Clone(){
        Token returnVal = new Token();
        returnVal.category = this.category;
        returnVal.behaviour = this.behaviour;
        returnVal.occasion = this.occasion;
        returnVal.target = this.target;
        returnVal.value0 = this.value0;        
        return returnVal;
    }
    public override string ToString(){
        return "  Token: " + category.ToString() + ", " +behaviour.ToString() + ", " +occasion.ToString() + ", " +value0.ToString();
    }
}

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



[Serializable]
public class TokenList : List<Token>{
    // public TokenList() : base(){}

    public void Combine(Token tk){
        Token resulttoken = this.Find(x => x.category == tk.category && x.occasion == tk.occasion && x.behaviour == tk.behaviour && x.target == tk.target);
        if(resulttoken != null ) resulttoken.value0 += tk.value0;
        else this.Add(tk);       
    }
    public void Subtract(Token tk){
        Token resulttoken = this.Find(x => x.category == tk.category && x.occasion == tk.occasion && x.behaviour == tk.behaviour && x.target == tk.target);
        if(resulttoken != null ) {
            resulttoken.value0 -= tk.value0;
            if(resulttoken.value0 < 0 ) this.Remove(resulttoken);
        }        
    }
    public Token Find(Token.Category c, Token.Behaviour b, Token.Occasion o){
        Token resulttoken = this.Find(x => x.category == c &&  x.behaviour == b && x.occasion == o);
        if(resulttoken != null ) return resulttoken;
        else return new Token();        
    }
    public Token Find(Token.Category c, Token.Behaviour b){
        Token resulttoken = this.Find(x => x.category == c &&  x.behaviour == b );
        if(resulttoken != null ) return resulttoken;
        else return new Token();        
    }
    public Token Find(Token.Category c, Token.Occasion o){
        Token resulttoken = this.Find(x => x.category == c &&  x.occasion == o );
        if(resulttoken != null ) return resulttoken;
        else return new Token();        
    }
    public Token Find(Token.Category c){
        Token resulttoken = this.Find(x => x.category == c);
        if(resulttoken != null ) return resulttoken;
        else return new Token();        
    }
    public TokenList FindAll(Token.Behaviour b, Token.Occasion o){
        List<Token> resulttoken = this.FindAll(x => x.occasion == o && x.behaviour == b);
        TokenList returnVal = new TokenList();
        foreach(Token t in resulttoken){
            returnVal.Add(t);
        }
        return returnVal;
    }

    public TokenList FindAll(Token.Occasion o){
        List<Token> resulttoken = this.FindAll(x => x.occasion == o);
        TokenList returnVal = new TokenList();
        foreach(Token t in resulttoken){
            returnVal.Add(t);
        }
        return returnVal;
    }
    public TokenList FindAll(Token.Behaviour b){
        List<Token> resulttoken = this.FindAll(x => x.behaviour == b);
        TokenList returnVal = new TokenList();
        foreach(Token t in resulttoken){
            returnVal.Add(t);
        }
        return returnVal;
    }

    public bool Has(Token.Category c, Token.Behaviour b = Token.Behaviour.None, Token.Occasion o = Token.Occasion.None, Token.Target t = Token.Target.Me){
        Token resulttoken = this.Find(c, b, o);
        if(resulttoken.category == Token.Category.None) return false;
        else return true;
    }
    
    public TokenList InheritStat(){
        TokenList returnVal = new TokenList();
        foreach(Token t in this){
            if(t.behaviour == Token.Behaviour.Current) returnVal.Add(t.Clone());            
        }
        return returnVal;
    }

    public void CalculateOnTurnStart(Character me){
        // TokenList gainNextTokens = me.GetLastPlayData(1).token.FindAll(Token.Behaviour.GainNextTurn);
        // foreach(Token tk in gainNextTokens){
        //     //GainNextTurn 을 Gain으로 변경한 새 토큰 생성
        //     Token convertedTK = tk.Clone();
        //     convertedTK.behaviour = Token.Behaviour.Gain;
        //     this.Combine(convertedTK);
        // }
        // TokenList lossNextTokens = me.GetLastPlayData(1).token.FindAll(Token.Behaviour.LossNextTurn);
        // foreach(Token tk in gainNextTokens){
        //     //LossNextTurn 을 Loss로 변경한 새 토큰 생성
        //     Token convertedTK = tk.Clone();
        //     convertedTK.behaviour = Token.Behaviour.Loss;
        //     this.Subtract(tk);
        // }
    }

    public void Cap(Character me){
        List<Token> current = this.FindAll(Token.Behaviour.Current);
        /*
        foreach(Token tk in current){
            float max = me.token.Find(tk.category, Token.Behaviour.Max).value0;
            // Debug.Log("Token.Cap : Found max of " + tk.category.ToString() + " : " + max.ToString());
            if(max > 0f && tk.value0 > max){
                tk.value0 = max;                
            }else if(tk.value0 < 0f){
                tk.value0 = 0f;                
            }
        }
        */
    }
    public void Organize(){
        this.RemoveAll(x => x.behaviour != Token.Behaviour.Current && x.value0 <= 0f);
    }

    //현재 TokenList 내에서 Current, Gain, Loss를 찾아내어 Current에 적용 후 Gain, Loss 없앰
    public void ApplyToken(Token.Category c){
        Token currnetTK = this.Find(c, Token.Behaviour.Current);
        if(currnetTK.category != c){
            Debug.LogError("TokenList.ApplyToken(Token.Category c) : cannont Find current target : " + c.ToString());
            return;
        }
        Token gainTK = this.Find(c, Token.Behaviour.Gain);
        Token lossTK = this.Find(c, Token.Behaviour.Loss);
        currnetTK.value0 = currnetTK.value0 + gainTK.value0 - lossTK.value0;
        // Debug.Log("TokenList.ApplyToken " + c.ToString() + " / cur: " + currnetTK.value0 + " / g: " + gainTK.value0.ToString() + " / l: " + lossTK.value0.ToString());
        // this.Remove(gainTK);
        // this.Remove(lossTK);
    }

    
    public void ConvertPrevTokensToCurrent(TokenList prev){
        List<Token> resulttoken = prev.FindAll(x => x.behaviour == Token.Behaviour.GainNextTurn || x.behaviour == Token.Behaviour.LossNextTurn);
        // Debug.Log("Token.ConvertPrevTokensToCurrent : findall result - " + resulttoken.Count.ToString());
        foreach(Token t in resulttoken){
            Token target = this.Find(t.category, Token.Behaviour.Current);            
            if(t.behaviour == Token.Behaviour.GainNextTurn) target.value0 += t.value0;
            else if(t.behaviour == Token.Behaviour.LossNextTurn) target.value0 -= t.value0;            
        }
    }

    public override string ToString(){
        string returnVal = "[Token List] " + this.Count.ToString();
        foreach(Token tk in this){
            returnVal += "\n" + tk.ToString();
        }
        return returnVal;
    }
}
