using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    public class AvoidGeneration : GameToken
    {
        public AvoidGeneration(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.AvoidGeneration;
            occasion = GameTerms.TokenOccasion.Feedback;            
        }
        public override void Yeild()
        {
            PlayData p = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
            bool isMoveMotion = (p.motion == GameTerms.Motion.Avoid || p.motion == GameTerms.Motion.Rest) ? true : false;
            if(isMoveMotion == true && p.collision == false){
                Debug.Log("Avoid(Move)Generation.Yield Activated. ("+value0.ToString()+")");
                EPCurrent EPModifier = new EPCurrent(value0);
                GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Combine(EPModifier);
            }
        }
    }
}