using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    public class Efficiency : GameToken
    {
        //Efficiency isActive구분 bool이 있음
        public bool isActive; // true이면 에너지를 소비함
        public Efficiency(GameTerms.TokenOccasion o, bool isActive, float v0 = 0f) : base(o, v0){
            type = GameTerms.TokenType.Efficieny;
            this.isActive = isActive;
        }
        public new Efficiency Clone()
        {
            return new Efficiency(occasion, isActive, value0);
        }
    }
}