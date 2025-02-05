using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class ChargeAction : GameToken
    {
        public ChargeAction() : base(){
            type = GameTerms.TokenType.ChargeAction;
            occasion = GameTerms.TokenOccasion.Static;
        }
        public override void Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameTerms.TokenOccasion.Charge;
            bool isOffensive = true;
            bool isActive = true;
            float basePower = SearchPower().value0; 
            float energyConsumption = CalculateEnergyConsumption();
            float efficiency = SearchEfficiency().value0;
            float energyPower = Mathf.Floor(energyConsumption * efficiency); 
            float totalPower = basePower + energyPower;

            if(GameBoard.Instance().phase == GameTerms.Phase.Turn_Ready){
                TokenList expextation = GameBoard.Instance().FindCharacter(characterIndex).temporaryTokens;
                expextation.Combine(new Power(GameTerms.TokenType.BasePower, o, isOffensive, basePower));
                expextation.Combine(new Power(GameTerms.TokenType.EnergyPower, o, isOffensive, energyPower));
                expextation.Combine(new GameToken(GameTerms.TokenType.EPConsumption, GameTerms.TokenOccasion.Consumption, energyConsumption));
                expextation.Combine(new Efficiency(o, isActive, efficiency));
                expextation.Combine(new Power(GameTerms.TokenType.TotalPower, o, isOffensive, totalPower));
            }
            else{
                TokenList playData = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
                playData.Combine(new Power(GameTerms.TokenType.BasePower, o, isOffensive, basePower));
                playData.Combine(new EnergyPower(o, isOffensive, energyPower));
                playData.Combine(new EPConsumption(energyConsumption));
                playData.Combine(new Efficiency(o, isActive, efficiency));
                playData.Combine(new TotalPower(o, isOffensive, totalPower));
            }

        }
        private float CalculateEnergyConsumption(){
            Character me = GameBoard.Instance().FindCharacter(characterIndex);
            float currentEnergy = me.GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            float energyConsumptionMax = me.SearchToken(GameTerms.TokenType.ChargeConsumption).value0;
            float returnValue = currentEnergy;
            if(currentEnergy > energyConsumptionMax)returnValue = energyConsumptionMax;
            return returnValue; 
        }
        private Power SearchPower(){
            Power returnValue = new Power(GameTerms.TokenType.AttackPower, GameTerms.TokenOccasion.Attack, true, 0f);
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.ChargePower));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.ShieldPower));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.OffensiveEfficiency));
            return returnValue;
        }
        private Efficiency SearchEfficiency(){
            Efficiency returnValue = new Efficiency(GameTerms.TokenOccasion.Attack, false, 0f);
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.ChargeEfficiency));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.ShieldEfficiency));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.OffensiveEfficiency));
            return returnValue;
        }
    }
}

