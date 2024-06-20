using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public static class GameItemTool
    {
        //---------------------------------------------[Health Slot]
        public static Stat GetItemStat(int characterIndex){
            // Character c = GameBoard.GetGameCharacterViaIndex(characterIndex);
            // return GetStatViaItem(c);
            return new Stat();
        }


        
        //---------------------------------------------[Power]
        // public static GameCharacterMotionData CalculateMotionData(int characterIndex, GameTerms.Motion m = GameTerms.Motion.None){
        //     GameCharacterMotionData d = new GameCharacterMotionData();
        //     d.modification = CalculateMotionModification(characterIndex,m);
        //     d.consumption = CalculateMotionConsumption(characterIndex,m);
        //     d.power = CalculateMotionPower(characterIndex,m);
        //     d.buff = CalculateMotionBuff(characterIndex,m);
        //     d.debuff = CalculateMotionDebuff(characterIndex,m);
        //     d.steal = CalculateMotionSteal(characterIndex,m);
        //     return d;
        // }
        private static Stat CalculateMotionModification(int characterIndex, GameTerms.Motion m = GameTerms.Motion.None){
            // Character c = GameBoard.GetGameCharacterViaIndex(characterIndex);
            // Stat s = new Stat();
            // if(m != GameTerms.Motion.None){
            //     for (int i = 0; i < c.item.Count; i++)
            //     {
            //         s += c.item[i].CalculateModification(characterIndex, m);
            //     }
            // }
            // return s;
            return new Stat();
        }
        private static Stat CalculateMotionConsumption(int characterIndex, GameTerms.Motion m = GameTerms.Motion.None){
            // Character c = GameBoard.GetGameCharacterViaIndex(characterIndex);
            // Stat s = new Stat();
            // if(m != GameTerms.Motion.None){
            //     for (int i = 0; i < c.item.Count; i++)
            //     {
            //         s += c.item[i].CalculateConsumption(characterIndex, m);
            //     }
            // }
            // return s;
            return new Stat();
        }
        private static Stat CalculateMotionPower(int characterIndex, GameTerms.Motion m = GameTerms.Motion.None){
            // Character c = GameBoard.GetGameCharacterViaIndex(characterIndex);
            // Stat s = new Stat();
            // if(m != GameTerms.Motion.None){
            //     for (int i = 0; i < c.item.Count; i++)
            //     {
            //         s += c.item[i].CalculatePower(characterIndex, m);
            //     }
            // }
            // return s;
            return new Stat();

        }
        private static Stat CalculateMotionBuff(int characterIndex, GameTerms.Motion m = GameTerms.Motion.None){
            // Character c = GameBoard.GetGameCharacterViaIndex(characterIndex);
            // Stat s = new Stat();
            // if(m != GameTerms.Motion.None){
            //     for (int i = 0; i < c.item.Count; i++)
            //     {
            //         s += c.item[i].CalculateBuff(characterIndex, m);
            //     }
            // }
            // return s;
            return new Stat();

        }
        private static Stat CalculateMotionDebuff(int characterIndex, GameTerms.Motion m = GameTerms.Motion.None){
            // Character c = GameBoard.GetGameCharacterViaIndex(characterIndex);
            // Stat s = new Stat();
            // if(m != GameTerms.Motion.None){
            //     for (int i = 0; i < c.item.Count; i++)
            //     {
            //         s += c.item[i].CalculateDebuff(characterIndex, m);
            //     }
            // }
            // return s;
            return new Stat();

        }
        private static Stat CalculateMotionSteal(int characterIndex, GameTerms.Motion m = GameTerms.Motion.None){
            // Character c = GameBoard.GetGameCharacterViaIndex(characterIndex);
            // Stat s = new Stat();
            // if(m != GameTerms.Motion.None){
            //     for (int i = 0; i < c.item.Count; i++)
            //     {
            //         s += c.item[i].CalculateSteal(characterIndex, m);
            //     }
            // }
            // return s;
            return new Stat();

        }
    
        //---------------------------------------------[Get Shift Amount]
        public static int GetStatShiftAmountHealth(int characterIndex, int amount, int modification = 0){
            // int current = GameBoard.GetLastGamePlayData(characterIndex).tokenStart.health + modification;
            // int slot = GameBoard.GetGameCharacterViaIndex(characterIndex).slot.health;
            // if(amount == 0){
            //     return amount;
            // }else if(amount > 0){
            //     int max = slot- current;
            //     return Mathf.Min(max, amount);
            // }else{
            //     int min = 0 -current;
            //     return Mathf.Max(min, amount);
            // }
            return 0;
        }
        public static int GetStatShiftAmountEnergy(int characterIndex, int amount, int modification = 0){
            // int current = GameBoard.GetLastGamePlayData(characterIndex).tokenStart.energy + modification;
            // int slot = GameBoard.GetGameCharacterViaIndex(characterIndex).slot.energy;
            // if(amount == 0){
            //     return amount;
            // }else if(amount > 0){
            //     int max = slot- current;
            //     return Mathf.Min(max, amount);
            // }else{
            //     int min = 0 -current;
            //     return Mathf.Max(min, amount);
            // }
            return 0;
        }
        public static int GetStatShiftAmountSword(int characterIndex, int amount, int modification = 0){
            // int current = GameBoard.GetLastGamePlayData(characterIndex).tokenStart.sword + modification;
            // int slot = GameBoard.GetGameCharacterViaIndex(characterIndex).slot.sword;
            // if(amount == 0){
            //     return amount;
            // }else if(amount > 0){
            //     int max = slot- current;
            //     return Mathf.Min(max, amount);
            // }else{
            //     int min = 0 -current;
            //     return Mathf.Max(min, amount);
            // }
            return 0;
        }
        public static int GetStatShiftAmountShield(int characterIndex, int amount, int modification = 0){
            // int current = GameBoard.GetLastGamePlayData(characterIndex).tokenStart.shield + modification;
            // int slot = GameBoard.GetGameCharacterViaIndex(characterIndex).slot.shield;
            // if(amount == 0){
            //     return amount;
            // }else if(amount > 0){
            //     int max = slot- current;
            //     return Mathf.Min(max, amount);
            // }else{
            //     int min = 0 -current;
            //     return Mathf.Max(min, amount);
            // }
            return 0;
        }
        
        //---------------------------------------------[Get Motion Data]
       

    }
}