using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure{
    public delegate bool MTCondition(Character me, Character other);
    public delegate void MTApplication(Character me, Character other);
    public static class ModifierTokenCondition
    {
        
        public static bool OnStart(Character me, Character other){
            if(GameBoard.Instance().phase == GameTerms.Phase.StartGame) return true;
            else return false;
        }
        public static bool OnDamageGive(Character me, Character other){
            return false;
        }
        public static bool OnDamageTake(Character me, Character other){
            return false;
        }
    }
    public static class ModifierTokenApplication
    {
        public static void GetValue(){

        }
        public static void GetPower(){

        }
        //AddToSlotOnStart
    }
}