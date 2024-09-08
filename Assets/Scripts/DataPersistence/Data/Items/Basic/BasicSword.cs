using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using ssm.data.token;
namespace ssm.data.item.basic{
    public class BasicSword : ItemData
    {
        internal float[] attackPower;
        internal float[] attackEfficiency;
        internal float[] strikePower;
        internal float[] strikeEfficiency;
        internal float[] strikeConsumption;

        public BasicSword(int grade = 0) : base(){
            InitStat();
            InitTokens();
        }
        public virtual void InitStat(){
            attackPower = new float[4];
            attackPower[0] = 0f;
            attackPower[1] = 0f;
            attackPower[2] = 0f;
            attackPower[3] = 0f;
            attackEfficiency = new float[4];
            attackEfficiency[0] = 0f;
            attackEfficiency[1] = 0f;
            attackEfficiency[2] = 0f;
            attackEfficiency[3] = 0f;
            strikePower = new float[4];
            strikePower[0] = 0f;
            strikePower[1] = 0f;
            strikePower[2] = 0f;
            strikePower[3] = 0f;
            strikeEfficiency = new float[4];
            strikeEfficiency[0] = 0f;
            strikeEfficiency[1] = 0f;
            strikeEfficiency[2] = 0f;
            strikeEfficiency[3] = 0f;
            strikeConsumption = new float[4];
            strikeConsumption[0] = 0f;
            strikeConsumption[1] = 0f;
            strikeConsumption[2] = 0f;
            strikeConsumption[3] = 0f;
        }
        public virtual void InitTokens(){
            float attackPower = this.attackPower[grade];
            Token attackPowerToken = new Token(GameTerms.TokenType.AttackPower, GameTerms.TokenOccasion.Static, attackPower);
            tokens.Add(attackPowerToken);
            float attackEfficiency = this.attackEfficiency[grade];
            Token attackEfficiencyToken = new Token(GameTerms.TokenType.AttackEfficiency, GameTerms.TokenOccasion.Static, attackEfficiency);
            tokens.Add(attackEfficiencyToken);
            float strikePower = this.strikePower[grade];
            Token strikePowerToken = new Token(GameTerms.TokenType.StrikePower, GameTerms.TokenOccasion.Static, strikePower);
            tokens.Add(strikePowerToken);
            float strikeEfficiency = this.strikeEfficiency[grade];
            Token strikeEfficiencyToken = new Token(GameTerms.TokenType.StrikeEfficiency, GameTerms.TokenOccasion.Static, strikeEfficiency);
            tokens.Add(strikeEfficiencyToken);
            float strikeConsumption = this.strikeConsumption[grade];
            Token strikeConsumptionToken = new Token(GameTerms.TokenType.StrikeConsumption, GameTerms.TokenOccasion.Static, strikeConsumption);
            tokens.Add(strikeConsumptionToken);
        }
        
        
    }
}
