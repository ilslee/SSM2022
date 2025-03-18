using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure.token;
using ssm.game.structure;
//게임 관련 자주 사용하는 기능 모음
public static class GameTool
{
    public enum Direction{None, Left, Right, Top, Bottom}
    public static void SetUIItemLayout(RectTransform target, Direction h, Direction v){
        Vector2 result = Vector2.zero;
        switch(h){
            case Direction.Left:
            result.x = 0f;
            break;
            case Direction.Right:
            result.x = 1f;
            break;
            default:
            result.x = 0.5f;
            break;
        }
        switch(v){
            case Direction.Bottom:
            result.y = 0f;
            break;
            case Direction.Top:
            result.y = 1f;
            break;
            default:
            result.y = 0.5f;
            break;
        }
        target.anchorMin = result;
        target.anchorMax = result;
        target.pivot = result;
    }
    public static bool IsGivingDamage(int characterIndex){
        Damage currentDamage = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Find(GameTerms.TokenType.Damage) as Damage;
        if(currentDamage == null || currentDamage.type == GameTerms.TokenType.None) return false;
        else return currentDamage.isGivingDamage;
    }
    public static bool CheckIndexValidity(int index, int length = 0){
        if(length == 0){
            if(index >= 0) return true;
            else return false;
        }else{
            if(index >= 0 && index < length) return true;
            else return false;
        }
    }
    public static int GetOpositeCharacterIndex(int characterIndex){
        if(characterIndex == 1) return 2;
        else if (characterIndex == 2) return 1;
        else{
            Debug.LogError("GameTool.GetOpositeCharacterIndex : Wrong param Charater Index : " + characterIndex);
            return 0;
        }
    }
    // Motion
    public static bool IsMotionOffensive(GameTerms.Motion m){
        switch(m){
            case GameTerms.Motion.Attack:
            case GameTerms.Motion.Strike:
            case GameTerms.Motion.Charge:
            return true;
            default:
            return false;
        }
    }
    public static bool IsMotionSword(GameTerms.Motion m){
        switch(m){
            case GameTerms.Motion.Attack:
            case GameTerms.Motion.Strike:
            return true;
            default:
            return false;
        }
    }
    public static bool IsMotionShield(GameTerms.Motion m){
        switch(m){
            case GameTerms.Motion.Defence:
            case GameTerms.Motion.Charge:
            return true;
            default:
            return false;
        }
    }
    public static bool IsMotionMove(GameTerms.Motion m){
        switch(m){
            case GameTerms.Motion.Avoid:
            case GameTerms.Motion.Taunt:
            return true;
            default:
            return false;
        }
    }
}
