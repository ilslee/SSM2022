using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.structure.token{
    public class RestAction : GameToken
    {
        public RestAction() : base(){
            type = GameTerms.TokenType.RestAction;
            occasion = GameTerms.TokenOccasion.Static;
        }

        public override void Yeild()
        {
            game.structure.Character me = GameBoard.Instance().FindCharacter(characterIndex);
            GameTerms.TokenOccasion o = GameTerms.TokenOccasion.Rest;
            bool isOffensive = false;
            float basePower = SearchPower().value0; 
            
            if(GameBoard.Instance().phase == GameTerms.Phase.Turn_Ready){
                TokenList expextation = GameBoard.Instance().FindCharacter(characterIndex).temporaryTokens;
                expextation.Combine(new Power(GameTerms.TokenType.BasePower, o, isOffensive, basePower));
                expextation.Combine(new Power(GameTerms.TokenType.TotalPower, o, isOffensive, basePower));
            }
            else{
                TokenList playData = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
                playData.Combine(new Power(GameTerms.TokenType.BasePower, o, isOffensive, basePower));
                playData.Combine(new TotalPower(o, isOffensive, basePower));
            }

        }

        private Power SearchPower(){
            Power returnValue = new Power(GameTerms.TokenType.AttackPower, GameTerms.TokenOccasion.Attack, true, 0f);
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.RestPower));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.MovePower));
            returnValue.Combine(GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.DefensivePower));
            return returnValue;
        }
        
    }
}
