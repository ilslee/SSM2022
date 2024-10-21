using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class Poisonous : GameToken
    {
        int duration = 0;
        int maxDuration = 0;
        public Poisonous(GameTerms.TokenType t, GameTerms.TokenOccasion o, float v0 = 0f) : base(t, o, v0){
            type = GameTerms.TokenType.Poisonous;
            occasion = GameTerms.TokenOccasion.Static;
            maxDuration = (int)v0;
            priority = 60;
        }

        public override void Yeild()
        {
            //이번 턴에 공격 성공하였으면 상대에게 Poisoned(d) 전달
            Damage currentDamage = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Find(GameTerms.TokenType.Damage) as Damage;
            if(currentDamage.occasion == GameTerms.TokenOccasion.Give){
                GameBoard.Instance().FindOpponent(characterIndex).GetLastPlayData().Combine(new Poisoned((float)maxDuration));
            }
        }
    }
}