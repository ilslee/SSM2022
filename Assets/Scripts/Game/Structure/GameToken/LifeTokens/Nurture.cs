using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
using Unity.VisualScripting;
namespace ssm.game.structure.token{
    /* 
    [육성]
    작동 : Feedback - 방어 성공 시 - 상대방 H+1
    추가 : 없음
    */
    public class Nurture : GameToken, IGameTokenCloneable<Nurture>
    {

        public Nurture(float v0 = 0f) : base(v0)
        {
            type = GameTerms.TokenType.Nurture;
            occasion = GameTerms.TokenOccasion.Feedback;
            value0 = v0; // heal other amount
            isDynamic = true;
            isDisplayed = true;
        }

        public override void Yeild()
        {
            // 방어 성공하면 : 상대 HP +=1 
            PlayData lastPlayData = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
            Damage damageTaken = lastPlayData.Find(GameTerms.TokenType.Damage) as Damage;
            if (lastPlayData.motion == GameTerms.Motion.Defence && lastPlayData.collision == true && damageTaken.isGivingDamage == false)
            {
                HPCurrent hpRecovery = new HPCurrent(value0);
                GameBoard.Instance().FindOpponent(characterIndex).GetLastPlayData().Combine(hpRecovery);
                isTrigged = true;
            }
        }
        
        public new Nurture Clone()
        {
            return base.Clone() as Nurture;
        }
    }

}
