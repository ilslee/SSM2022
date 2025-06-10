using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class AvoidAction : GameToken
    {
        public AvoidAction() : base(){
            type = GameTerms.TokenType.AvoidAction;
            occasion = GameTerms.TokenOccasion.Static;
        }
        public override void Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameTerms.TokenOccasion.Avoid;
            bool isOffensive = false;
            bool isActive = true;
            float avoidBasePower = SearchPower().value0; 
            float currentEnergy = me.GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            float avoidEfficiency = SearchEfficiency().value0;
            float avoidEnergyPower =  Mathf.Floor(currentEnergy * avoidEfficiency); 

            TokenList target = new TokenList();
            if(GameBoard.Instance().phase == GameTerms.Phase.Turn_Ready){
                TokenList expextation = Me().temporaryTokens;
                expextation.Combine(new Power(GameTerms.TokenType.BasePower, o, isOffensive, avoidBasePower));
                expextation.Combine(new Power(GameTerms.TokenType.EnergyPower, o, isOffensive, avoidEnergyPower));
                expextation.Combine(new Efficiency(o, isActive, avoidEfficiency));
                expextation.Combine(new Power(GameTerms.TokenType.TotalPower, o, isOffensive, avoidBasePower + avoidEnergyPower));
            }else{
                TokenList playData = Me().GetLastPlayData();
                playData.Combine(new Power(GameTerms.TokenType.BasePower, o, isOffensive, avoidBasePower));
                float energyPower = AdjustEnegyPower();
                playData.Combine(new EnergyPower(o, isOffensive, energyPower));
                playData.Combine(new Efficiency(o, isActive, avoidEfficiency));
                playData.Combine(new TotalPower(o, isOffensive, avoidBasePower + energyPower));

            }
            
            float AdjustEnegyPower(){
                PlayData other = Other().GetLastPlayData();
                //양쪽이 Avoid이면서 해당 액션을 실행하면 NullRef 발생 > 방어코드 추가
                if(other.motion == GameTerms.Motion.Avoid) return 0f;

                TotalPower otherPower = other.Find(GameTerms.TokenType.TotalPower) as TotalPower;
                Debug.Log(other.motion.ToString() + " / " + otherPower.ToString());
                if (otherPower.isOffensive == true)
                {
                    if (otherPower.value0 - avoidBasePower <= 0) return 0f;
                    else if (otherPower.value0 >= (avoidBasePower + avoidEnergyPower)) return avoidEnergyPower;
                    else return otherPower.value0 - avoidBasePower;
                }
                else
                {
                    return 0f;
                }
            }
        }

        private Power SearchPower(){
            Power returnValue = new Power(GameTerms.TokenType.AttackPower, GameTerms.TokenOccasion.Attack, true, 0f);
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.AvoidPower));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.MovePower));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.DefensiveEfficiency));
            return returnValue;
        }
        private Efficiency SearchEfficiency(){
            Efficiency returnValue = new Efficiency(GameTerms.TokenOccasion.Attack, false, 0f);
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.AvoidEfficiency));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.MoveEfficiency));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.DefensiveEfficiency));
            return returnValue;
        }
    }
}

