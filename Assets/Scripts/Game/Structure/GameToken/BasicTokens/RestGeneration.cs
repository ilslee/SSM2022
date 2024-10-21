using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    public class RestGeneration : GameToken
    {
        public RestGeneration(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.RestGeneration;
            occasion = GameTerms.TokenOccasion.Feedback;            
        }
        public override void Yeild()
        {
            PlayData p = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
            if(p.motion == GameTerms.Motion.Rest){
                Debug.Log("RestGeneration.Yield Activated. ("+value0.ToString()+")");
                EPCurrent EPModifier = new EPCurrent(value0);
                GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Combine(EPModifier);
            }
        }
    }
}