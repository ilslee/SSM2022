using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using ssm.data.token;
namespace ssm.data.item.basic{
    public class BasicCore : ItemData
    {
        internal float health;
        internal float energy;
       

        public BasicCore(int grade = 0) : base(){
            InitStat();
            InitTokens();
        }
        public virtual void InitStat(float h = 0f, float e = 0f){
            health = h;
            energy = e;
        }
        public virtual void InitTokens(){
            tokens.Add(new AttackAction());
            tokens.Add(new Token(GameTerms.TokenType.StrikeAction, GameTerms.TokenOccasion.Strike));
            tokens.Add(new Token(GameTerms.TokenType.DefenceAction, GameTerms.TokenOccasion.Defence));
            tokens.Add(new Token(GameTerms.TokenType.ChargeAction, GameTerms.TokenOccasion.Charge));
            tokens.Add(new Token(GameTerms.TokenType.RestAction, GameTerms.TokenOccasion.Rest));
            tokens.Add(new Token(GameTerms.TokenType.AvoidAction, GameTerms.TokenOccasion.Avoid));
            

            Token hpMaxToken = new Token(GameTerms.TokenType.HPMax, GameTerms.TokenOccasion.None, health);
            tokens.Add(hpMaxToken);
            Token hpCurrentToken = new Token(GameTerms.TokenType.HPCurrent, GameTerms.TokenOccasion.None, health);
            tokens.Add(hpCurrentToken);
            Token epMaxToken = new Token(GameTerms.TokenType.EPMax, GameTerms.TokenOccasion.None, energy);
            tokens.Add(epMaxToken);
            Token epCurrentToken = new Token(GameTerms.TokenType.EPCurrent, GameTerms.TokenOccasion.None, energy);
            tokens.Add(epCurrentToken);
        }
    }
}
