using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;
namespace ssm.game.structure.token{
    public class TotalPower : Power
    {
        //Power의 Occation은 각 동작, 혹은 Offensive, Diffensive 적용 가능
        public TotalPower(GameTerms.TokenOccasion o, bool isOffensive, float v0 = 0f) : base(GameTerms.TokenType.TotalPower, o, isOffensive, v0){
            isDynamic = true;
        }

        public override void Yeild()
        {
            //Damage
            PlayData pd = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
            TotalPower otherPower = GameBoard.Instance().FindOpponent(characterIndex).GetLastPlayData().Find(GameTerms.TokenType.TotalPower) as TotalPower;
            // Debug.Log("TotalPower.Yield is called : " + (value0 - otherPower.value0).ToString());
            bool isMeOffensive = (GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.TotalPower) as TotalPower).isOffensive; 
            bool isOtherOffensive = (GameBoard.Instance().FindOpponent(characterIndex).SearchToken(GameTerms.TokenType.TotalPower) as TotalPower).isOffensive; 
            if(GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().collision == true){
                float deltaPower =  value0 - otherPower.value0;
                if(deltaPower < 0 && isOtherOffensive == true){
                    Damage damageTaken = new Damage(false, Mathf.Abs(deltaPower));
                    pd.Combine(damageTaken);
                }else if(deltaPower > 0 && isMeOffensive == true){
                    Damage damageGive = new Damage(true, Mathf.Abs(deltaPower));
                    pd.Combine(damageGive);
                }else{
                    pd.Combine(new Damage(false, 0f));
                }
            }
            
            //Consumption은 EnergyPower에서 계산
            
        }
    }
}