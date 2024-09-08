using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.data.token{
    public class AvoidAction : Token
    {
        public AvoidAction() : base(){
            type = GameTerms.TokenType.AvoidAction;
            occasion = GameTerms.TokenOccasion.Avoid;
        }
        public override TokenList Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameBoard.Instance().phase == GameTerms.Phase.Expectation ? GameTerms.TokenOccasion.Charge : GameTerms.TokenOccasion.Offensive;
            TokenList returnVal = new TokenList();
            //basePower
            float avoidBasePower = me.SearchToken(GameTerms.TokenType.AvoidPower).value0; 
            Power basePowerToken = new Power(characterIndex, GameTerms.TokenType.BasePower, o, avoidBasePower);
            returnVal.Add(basePowerToken);
            //energy & total power
            float currentEnergy = me.GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            float avoidEfficiency = me.SearchToken(GameTerms.TokenType.ChargeEfficiency).value0;
            float avoidEnergyPowerMax =  Mathf.Floor(currentEnergy * avoidEfficiency); 
            if(GameBoard.Instance().phase == GameTerms.Phase.Expectation){
                Power energePowerTokenExpectation = new Power(characterIndex, GameTerms.TokenType.EnergyPower, o, 0f , avoidEnergyPowerMax);
                float totalPowerMin = avoidBasePower;
                float totalPowerMax = avoidBasePower + avoidEnergyPowerMax;
                Power totalPowerTokenExpextation = new Power(characterIndex, GameTerms.TokenType.TotalPower, o, totalPowerMin, totalPowerMax);
                returnVal.Add(energePowerTokenExpectation);
                returnVal.Add(totalPowerTokenExpextation);
            }else{
                //상대방 파워가 오펜시브인 경우 :  파워에서 베이스 제거
                Power otherPower = GameBoard.Instance().FindOpponent(characterIndex).GetLastPlayData().Find(GameTerms.TokenType.TotalPower) as Power;
                float avoidEnergyPower = 0f;
                if(otherPower.occasion == GameTerms.TokenOccasion.Offensive){
                    float otherTotalPower = otherPower.value0;
                    if(otherTotalPower - avoidBasePower <= 0) avoidEnergyPower = 0f;
                    else if(otherTotalPower >= (avoidBasePower + avoidEnergyPowerMax))avoidEnergyPower = avoidEnergyPowerMax;
                    else avoidEnergyPower = otherTotalPower - avoidBasePower;
                    
                }
                Power energePowerTokenFinal = new Power(characterIndex, GameTerms.TokenType.EnergyPower, o, avoidEnergyPower);
                Power totalPowerTokenFinl = new Power(characterIndex, GameTerms.TokenType.TotalPower, o, avoidBasePower + avoidEnergyPower);
                returnVal.Add(energePowerTokenFinal);
                returnVal.Add(totalPowerTokenFinl);
            }
            
            return returnVal; 
        }
    }
}

