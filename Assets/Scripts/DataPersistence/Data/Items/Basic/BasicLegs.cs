using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.token;
namespace ssm.data.item.basic{
    public class BasicLegs : ItemData
    {
        internal float[] restPower;
        internal float[] avoidPower;
        internal float[] avoidEfficiency;
        internal float[] avoidAdaptiveConsumption;
        internal float[] restGenaration;
        internal float[] avoidGeneration;
        
        public BasicLegs(int grade = 0) : base(){
            InitStat();
            InitTokens();
        }
        public virtual void InitStat(){
            restPower = new float[4];
            restPower[0] = 0f;
            restPower[1] = 0f;
            restPower[2] = 0f;
            restPower[3] = 0f;
            avoidPower = new float[4];
            avoidPower[0] = 0f;
            avoidPower[1] = 0f;
            avoidPower[2] = 0f;
            avoidPower[3] = 0f;
            avoidEfficiency = new float[4];
            avoidEfficiency[0] = 0f;
            avoidEfficiency[1] = 0f;
            avoidEfficiency[2] = 0f;
            avoidEfficiency[3] = 0f;
            avoidAdaptiveConsumption = new float[4];
            avoidAdaptiveConsumption[0] = 0f;
            avoidAdaptiveConsumption[1] = 0f;
            avoidAdaptiveConsumption[2] = 0f;
            avoidAdaptiveConsumption[3] = 0f;
            restGenaration = new float[4];
            restGenaration[0] = 0f;
            restGenaration[1] = 0f;
            restGenaration[2] = 0f;
            restGenaration[3] = 0f;
            avoidGeneration = new float[4];
            avoidGeneration[0] = 0f;
            avoidGeneration[1] = 0f;
            avoidGeneration[2] = 0f;
            avoidGeneration[3] = 0f;
        }
        public virtual void InitTokens(){
            float restPower = this.restPower[grade];
            Token restPowerToken = new Token(GameTerms.TokenType.RestPower, GameTerms.TokenOccasion.Rest, restPower);
            tokens.Add(restPowerToken);
            float avoidPower = this.avoidPower[grade];
            Token avoidPowerToken = new Token(GameTerms.TokenType.AvoidPower, GameTerms.TokenOccasion.Avoid, avoidPower);
            tokens.Add(avoidPowerToken);
            float avoidEfficiency = this.avoidEfficiency[grade];
            Token avoidEfficiencyToken = new Token(GameTerms.TokenType.AvoidEfficiency, GameTerms.TokenOccasion.Avoid, avoidEfficiency);
            tokens.Add(avoidEfficiencyToken);
            float avoidAdaptiveConsumption = this.avoidAdaptiveConsumption[grade];
            Token avoidAdaptiveConsumptionToken = new Token(GameTerms.TokenType.AvoidAdaptiveConsumption, GameTerms.TokenOccasion.Avoid, avoidAdaptiveConsumption);
            tokens.Add(avoidAdaptiveConsumptionToken);
            float restGenaration = this.restGenaration[grade];
            Token restGenarationToken = new Token(GameTerms.TokenType.RestGeneration, GameTerms.TokenOccasion.Rest, restGenaration);
            tokens.Add(restGenarationToken);
            float avoidGeneration = this.avoidGeneration[grade];
            Token avoidGenerationToken = new Token(GameTerms.TokenType.AvoidGeneration, GameTerms.TokenOccasion.Avoid, avoidGeneration);
            tokens.Add(avoidGenerationToken);
        }
    }
}

