using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    public class Power : GameToken
    {
        //Power는 offensive, deffensive 구분 bool이 있음 -> Total Power로 이관
        public bool isOffensive;
        public Power( GameTerms.TokenOccasion o, bool offensive, float v0 = 0f) : base(GameTerms.TokenType.Power, o, v0)
        {
            this.isOffensive = offensive;
            isDynamic = true;
        }
    }
/*
                public new Power Clone()
                {
                    return new Power(type, occasion, isOffensive, value0);
                }
            }
        */
    }