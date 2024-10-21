using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure{
    public static class GameLogDisplayer
    {
        public static void LogCharacterStat(Character c){
            // Character g = GameBoard.GetGameCharacterViaIndex(characterIndex);
            string log = "------[Character " + c.index + "'s Slot]------";
            // log += "\n Health = " + c.slot.health;
            // log += " / Energy = " + c.slot.energy;
            // log += " / Attack = " + c.slot.sword;
            // log += " / Defence = " + c.slot.shield;
            Debug.Log(log);
            
        }
        public static void LogCharacterME(Character c){
            string log = "------[Character " + c.index + "'ME]------";
                         
            Debug.Log(log);
        }
        public static void LogGamePreparation(string gameMode = ""){
            string log = "[Game Mode : " + gameMode + " : Preparation DONE!]";
            Debug.Log(log);
        }
    }
}