using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token
{
    public class PowerInfoGenerator : MultiTypeToken, IYeldPowerSource
    {
        public PowerInfoGenerator(GameTerms.TokenType t, MultiTypeToken.SubType s, GameTerms.TokenOccasion o, float v) : base(t, s, o, v)
        {

        }
        public MultiTypeToken YieldMTT(GameTerms.Motion m)
        {

            if (CheckAvailable(m) == false) return null;
            else return new MultiTypeToken(type, subType, ConvertMotionToOccasion(m), value0);

        }

        public virtual bool CheckAvailable(GameTerms.Motion m)
        {
            if (ConvertMotionToOccasion(m) == this.occasion) return true;
            else return false;
        }

        private GameTerms.TokenOccasion ConvertMotionToOccasion(GameTerms.Motion m)
        {
            GameTerms.TokenOccasion o = GameTerms.TokenOccasion.None;
            switch (m)
            {
                case GameTerms.Motion.Attack:
                    o = GameTerms.TokenOccasion.Attack;
                    break;
                case GameTerms.Motion.Strike:
                    o = GameTerms.TokenOccasion.Strike;
                    break;
                case GameTerms.Motion.Defence:
                    o = GameTerms.TokenOccasion.Defence;
                    break;
                case GameTerms.Motion.Charge:
                    o = GameTerms.TokenOccasion.Charge;
                    break;
                case GameTerms.Motion.Avoid:
                    o = GameTerms.TokenOccasion.Avoid;
                    break;
                case GameTerms.Motion.Rest:
                    o = GameTerms.TokenOccasion.Rest;
                    break;
            }
            return o;
        }
    }
}