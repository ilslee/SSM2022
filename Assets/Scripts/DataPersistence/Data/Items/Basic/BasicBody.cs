using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using ssm.data.token;
namespace ssm.data.item.basic{
    public class BasicBody : ItemData
    {
        internal float[] hpMax;
        internal float[] hpCurrent;
        internal float[] epMax;
        internal float[] epCurrent;

        public BasicBody(int grade = 0) : base(){
            InitStat();
            InitTokens();
        }
        public virtual void InitStat(){
            hpMax = new float[4];
            hpMax[0] = 0f;
            hpMax[1] = 0f;
            hpMax[2] = 0f;
            hpMax[3] = 0f;
            hpCurrent = new float[4];
            hpCurrent[0] = 0f;
            hpCurrent[1] = 0f;
            hpCurrent[2] = 0f;
            hpCurrent[3] = 0f;
            epMax = new float[4];
            epMax[0] = 0f;
            epMax[1] = 0f;
            epMax[2] = 0f;
            epMax[3] = 0f;
            epCurrent = new float[4];
            epCurrent[0] = 0f;
            epCurrent[1] = 0f;
            epCurrent[2] = 0f;
            epCurrent[3] = 0f;
        }
        public virtual void InitTokens(){
            float hpMax = this.hpMax[grade];
            Token hpMaxToken = new Token(GameTerms.TokenType.HPMax, GameTerms.TokenOccasion.None, hpMax);
            tokens.Add(hpMaxToken);
            float hpCurrent = this.hpCurrent[grade];
            Token hpCurrentToken = new Token(GameTerms.TokenType.HPCurrent, GameTerms.TokenOccasion.None, hpCurrent);
            tokens.Add(hpCurrentToken);
            float epMax = this.epMax[grade];
            Token epMaxToken = new Token(GameTerms.TokenType.EPMax, GameTerms.TokenOccasion.None, epMax);
            tokens.Add(epMaxToken);
            float epCurrent = this.epCurrent[grade];
            Token epCurrentToken = new Token(GameTerms.TokenType.EPCurrent, GameTerms.TokenOccasion.None, epCurrent);
            tokens.Add(epCurrentToken);
        }
    }
}