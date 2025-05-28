using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.appearance{
    public class HistoryIconManager : IconManager
    {
        
        public void SetIconViaMotion(GameTerms.Motion m)
        {
            switch (m){
                case GameTerms.Motion.Attack:
                SetIcon(GameTerms.TokenType.AttackAction);
                break;
                case GameTerms.Motion.Strike:
                SetIcon(GameTerms.TokenType.StrikeAction);
                break;
                case GameTerms.Motion.Defence:
                SetIcon(GameTerms.TokenType.DefenceAction);
                break;
                case GameTerms.Motion.Charge:
                SetIcon(GameTerms.TokenType.ChargeAction);
                break;
                case GameTerms.Motion.Rest:
                SetIcon(GameTerms.TokenType.RestAction);
                break;
                case GameTerms.Motion.Avoid:
                SetIcon(GameTerms.TokenType.AvoidAction);
                break;
                default:
                SetIcon(GameTerms.TokenType.None);
                break;
            }
        }

    }
}