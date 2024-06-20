using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTool
{
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
