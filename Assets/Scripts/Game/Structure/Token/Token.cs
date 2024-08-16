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
public class Token
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

    public GameTerms.TokenType type;
    public GameTerms.TokenOccasion occasion;
    public float value0;
    public int priority;
    
    public Token() {
        type = GameTerms.TokenType.None;
        occasion = GameTerms.TokenOccasion.None;
        value0 = 0f;    
        priority = 50;
    }
    public Token(GameTerms.TokenType t, GameTerms.TokenOccasion o, float v = 0f, int p = 50){
        type = t;
        occasion = o;
        value0 = v;    
        priority = p;     
    }  
    public Token Clone(){
        Token returnVal = new Token();
        returnVal.type = this.type;
        returnVal.occasion = this.occasion;
        returnVal.value0 = this.value0;        
        returnVal.priority = this.priority;        
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

    public void Combine(Token tk){
        Token resulttoken = this.Find(x => x.type == tk.type);
        if(resulttoken != null ) resulttoken.value0 += tk.value0;
        else this.Add(tk);       
    }
    public void Subtract(Token tk){
        Token resulttoken = this.Find(x => x.type == tk.type);
        if(resulttoken != null ) {
            resulttoken.value0 -= tk.value0;
            if(resulttoken.value0 < 0 ) this.Remove(resulttoken);
        }        
    }
    public Token Find(GameTerms.TokenType t){
        Token resulttoken = this.Find(x => x.type == t);
        if(resulttoken != null ) return resulttoken;
        else return new Token();        
    }
    
    public TokenList FindAll(GameTerms.TokenType t){
        List<Token> resulttoken = this.FindAll(x => x.type == t);
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
