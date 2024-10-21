using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class AttackAction : GameToken
    {
        public AttackAction() : base(){
            type = GameTerms.TokenType.AttackAction;
            occasion = GameTerms.TokenOccasion.Static;
        }

        public override void Yeild()
        {
            // Debug.Log("Attack Action : Yield");
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameTerms.TokenOccasion.Attack;
            bool isOffensive = true;
            bool isActive = false;
            float attackBasePower = SearchPower().value0; 
            float currentEnergy = me.GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            float attackEfficiency = SearchEfficiency().value0;
            float energyPower = Mathf.Floor(currentEnergy * attackEfficiency); 
            float totalPower = attackBasePower + energyPower;
            if(GameBoard.Instance().phase == GameTerms.Phase.Expectation){
                TokenList expextation = GameBoard.Instance().FindCharacter(characterIndex).temporaryTokens;
                expextation.Combine(new Power(GameTerms.TokenType.BasePower, o, isOffensive, attackBasePower));
                expextation.Combine(new Power(GameTerms.TokenType.EnergyPower, o, isOffensive, energyPower));
                expextation.Combine(new Efficiency(o, isActive, attackEfficiency));
                expextation.Combine(new Power(GameTerms.TokenType.TotalPower, o, isOffensive, totalPower));
            }
            else{
                TokenList playData = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
                playData.Combine(new Power(GameTerms.TokenType.BasePower, o, isOffensive, attackBasePower));
                playData.Combine(new EnergyPower(o, isOffensive, energyPower));
                playData.Combine(new Efficiency(o, isActive, attackEfficiency));
                playData.Combine(new TotalPower(o, isOffensive, totalPower));

            }
            
        }

        private Power SearchPower(){
            Power returnValue = new Power(GameTerms.TokenType.AttackPower, GameTerms.TokenOccasion.Attack, true, 0f);
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.AttackPower));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.SwrodPower));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.OffensivePower));
            return returnValue;
        }
        private Efficiency SearchEfficiency(){
            Efficiency returnValue = new Efficiency(GameTerms.TokenOccasion.Attack, false, 0f);
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.AttackEfficiency));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.SwordEfficiency));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.OffensiveEfficiency));
            return returnValue;
        }
        public new AttackAction Clone(){
            AttackAction returnVal = new AttackAction();
            returnVal.characterIndex = this.characterIndex;
            returnVal.type = this.type;
            returnVal.occasion = this.occasion;
            returnVal.value0 = this.value0;        
            returnVal.priority = this.priority;        
            return returnVal;
        }
    }
}