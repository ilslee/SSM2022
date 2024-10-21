using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    public class CollisionGeneration : GameToken
    {
        public CollisionGeneration(float v0 = 0f) : base(v0){
            type = GameTerms.TokenType.CollisionGeneration;
            occasion = GameTerms.TokenOccasion.Feedback;            
        }
        public override void Yeild()
        {
            PlayData p = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
            if(p.motion == GameTerms.Motion.Defence && p.collision == true){
                Debug.Log("CollisionGeneration.Yield Activated. ("+value0.ToString()+")");
                EPCurrent EPModifier = new EPCurrent(value0);
                GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Combine(EPModifier);
            }
        }
    }
}