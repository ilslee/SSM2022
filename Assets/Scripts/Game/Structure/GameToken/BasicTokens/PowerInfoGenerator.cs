using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token
{
    //PowerInfoGenerator는 Searchtoken에 잡히지 않음
    public class PowerInfoGenerator : MultiTypeToken, IYeldPowerSource
    {
        public PowerInfoGenerator(GameTerms.TokenType t, MultiTypeToken.SubType s, GameTerms.TokenOccasion o, float v) : base(t, s, o, v)
        {

        }
        public MultiTypeToken YieldMTT(GameTerms.TokenOccasion o)
        {

            if (CheckAvailable(o) == false) return null;
            else return new MultiTypeToken(type, subType, o, value0);

        }

        public virtual bool CheckAvailable(GameTerms.TokenOccasion o)
        {
            // GameTerms.TokenOccasion o = ConvertMotionToOccasion(m);
            if (o == this.occasion) return true;
            else
            {
                switch (this.occasion)
                {
                    case GameTerms.TokenOccasion.Sword:
                        switch (o)
                        {
                            case GameTerms.TokenOccasion.Attack:
                            case GameTerms.TokenOccasion.Strike:
                                return true;
                            default:
                                return false;
                        }
                        break;
                    case GameTerms.TokenOccasion.Shield:
                        switch (o)
                        {
                            case GameTerms.TokenOccasion.Defence:
                            case GameTerms.TokenOccasion.Charge:
                                return true;
                            default:
                                return false;
                        }
                        break;
                    case GameTerms.TokenOccasion.Move:
                        switch (o)
                        {
                            case GameTerms.TokenOccasion.Rest:
                            case GameTerms.TokenOccasion.Avoid:
                                return true;
                            default:
                                return false;
                        }
                        break;
                    case GameTerms.TokenOccasion.Offensive:
                        switch (o)
                        {
                            case GameTerms.TokenOccasion.Attack:
                            case GameTerms.TokenOccasion.Strike:
                            case GameTerms.TokenOccasion.Charge:
                                return true;
                            default:
                                return false;
                        }
                        break;
                    case GameTerms.TokenOccasion.Defensive:
                        switch (o)
                        {
                            case GameTerms.TokenOccasion.Defence:
                            case GameTerms.TokenOccasion.Avoid:
                            case GameTerms.TokenOccasion.Rest:
                                return true;
                            default:
                                return false;
                        }
                        break;
                }
            }
            return false;
        }

        
    }
}