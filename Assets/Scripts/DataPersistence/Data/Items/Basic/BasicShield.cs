using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using ssm.data.token;
namespace ssm.data.item.basic{
    public class BasicShield : ItemData
    {
        internal float[] defencePower;
        internal float[] defenceEfficiency;
        internal float[] collisionGeneration;
        internal float[] chargePower;
        internal float[] chargeEfficiency;
        internal float[] chargeConsumption;

        public BasicShield(int grade = 0) : base(){
            InitStat();
            InitTokens();
        }
        public virtual void InitStat(){
            defencePower = new float[4];
            defencePower[0] = 0f;
            defencePower[1] = 0f;
            defencePower[2] = 0f;
            defencePower[3] = 0f;
            defenceEfficiency = new float[4];
            defenceEfficiency[0] = 0f;
            defenceEfficiency[1] = 0f;
            defenceEfficiency[2] = 0f;
            defenceEfficiency[3] = 0f;
            collisionGeneration = new float[4];
            collisionGeneration[0] = 0f;
            collisionGeneration[1] = 0f;
            collisionGeneration[2] = 0f;
            collisionGeneration[3] = 0f;
            chargePower = new float[4];
            chargePower[0] = 0f;
            chargePower[1] = 0f;
            chargePower[2] = 0f;
            chargePower[3] = 0f;
            chargeEfficiency = new float[4];
            chargeEfficiency[0] = 0f;
            chargeEfficiency[1] = 0f;
            chargeEfficiency[2] = 0f;
            chargeEfficiency[3] = 0f;
            chargeConsumption = new float[4];
            chargeConsumption[0] = 0f;
            chargeConsumption[1] = 0f;
            chargeConsumption[2] = 0f;
            chargeConsumption[3] = 0f;
        }
        public virtual void InitTokens(){
            float defencePower = this.defencePower[grade];
            Token defencePowerToken = new Token(GameTerms.TokenType.DefencePower, GameTerms.TokenOccasion.Defence, defencePower);
            tokens.Add(defencePowerToken);
            float defenceEfficiency = this.defenceEfficiency[grade];
            Token defenceEfficiencyToken = new Token(GameTerms.TokenType.DefenceEfficiency, GameTerms.TokenOccasion.Defence, defenceEfficiency);
            tokens.Add(defenceEfficiencyToken);
            float collisionGeneration = this.collisionGeneration[grade];
            Token collisionGenerationToken = new Token(GameTerms.TokenType.CollisionGeneration, GameTerms.TokenOccasion.Defence, collisionGeneration);
            tokens.Add(collisionGenerationToken);
            float chargePower = this.chargePower[grade];
            Token chargePowerToken = new Token(GameTerms.TokenType.ChargePower, GameTerms.TokenOccasion.Charge, chargePower);
            tokens.Add(chargePowerToken);
            float chargeEfficiency = this.chargeEfficiency[grade];
            Token chargeEfficiencyToken = new Token(GameTerms.TokenType.ChargeEfficiency, GameTerms.TokenOccasion.Charge, chargeEfficiency);
            tokens.Add(chargeEfficiencyToken);
            float chargeConsumption = this.chargeConsumption[grade];
            Token chargeConsumptionToken = new Token(GameTerms.TokenType.ChargeConsumption, GameTerms.TokenOccasion.Charge, chargeConsumption);
            tokens.Add(chargeConsumptionToken);
        }
    }
}
