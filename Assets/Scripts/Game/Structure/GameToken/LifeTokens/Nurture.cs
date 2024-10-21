using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
using Unity.VisualScripting;
namespace ssm.game.structure.token{
    public class Nurture : GameToken
    {
        public Nurture() : base(){
            type = GameTerms.TokenType.Nurture;
            occasion = GameTerms.TokenOccasion.Static;
        }

        public override void Yeild()
        {
            // 방어 성공하면 : 상대 HP +=1 
            PlayData lastPlayData = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
            Damage damageTaken = lastPlayData.Find(GameTerms.TokenType.Damage) as Damage;
            bool isNoDamageTaken = damageTaken.occasion == GameTerms.TokenOccasion.Take && damageTaken.value0 > 0 ? false : true;
            if(lastPlayData.motion == GameTerms.Motion.Defence && lastPlayData.collision == true && isNoDamageTaken == true){
                HPCurrent hpRecovery = new HPCurrent(1f);
                GameBoard.Instance().FindOpponent(characterIndex).GetLastPlayData().Combine(hpRecovery);
            }
        }
    }

}
