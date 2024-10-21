using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class DefenceAction : GameToken
    {
        public DefenceAction() : base(){
            type = GameTerms.TokenType.DefenceAction;
            occasion = GameTerms.TokenOccasion.Static;
        }

        public override void Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameTerms.TokenOccasion.Defence;
            bool isOffensive = false;
            bool isActive = false;
            float basePower = SearchPower().value0; 
            float currentEnergy = me.GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            float efficiency = SearchEfficiency().value0;
            float energyPower = Mathf.Floor(currentEnergy * efficiency); 
            float totalPower = basePower + energyPower;
            
            if(GameBoard.Instance().phase == GameTerms.Phase.Expectation){
                TokenList expextation = GameBoard.Instance().FindCharacter(characterIndex).temporaryTokens;
                expextation.Combine(new Power(GameTerms.TokenType.BasePower, o, isOffensive, basePower));
                expextation.Combine(new Power(GameTerms.TokenType.EnergyPower, o, isOffensive, energyPower));
                expextation.Combine(new Efficiency(o, isActive, efficiency));
                expextation.Combine(new Power(GameTerms.TokenType.TotalPower, o, isOffensive, totalPower));
            }
            else{
                TokenList playData = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
                playData.Combine(new Power(GameTerms.TokenType.BasePower, o, isOffensive, basePower));
                playData.Combine(new EnergyPower(o, isOffensive, energyPower));
                playData.Combine(new Efficiency(o, isActive, efficiency));
                playData.Combine(new TotalPower(o, isOffensive, totalPower));
            }

        }
       
        private Power SearchPower(){
            Power returnValue = new Power(GameTerms.TokenType.AttackPower, GameTerms.TokenOccasion.Attack, true, 0f);
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.DefencePower));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.ShieldPower));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.DefensivePower));
            return returnValue;
        }
        private Efficiency SearchEfficiency(){
            Efficiency returnValue = new Efficiency(GameTerms.TokenOccasion.Attack, false, 0f);
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.DefenceEfficiency));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.ShieldEfficiency));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.DefensiveEfficiency));
            return returnValue;
        }
    }
}

