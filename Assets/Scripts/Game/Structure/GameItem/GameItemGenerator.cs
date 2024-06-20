using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;

namespace ssm.game.structure{
    public static class GameItemGenerator
    {
        // public static Item GenerateGameItem(ItemIndexer i){

        //     switch(i.family){
        //         case ItemIndexer.Family.None:
        //         default:
        //         switch(i.part){
        //             case ItemIndexer.Part.Head:
        //             return new DummyHead(i.grade);
                    
        //             case ItemIndexer.Part.Body:
        //             return new DummyChest(i.grade);
                    
        //             case ItemIndexer.Part.Arms:
        //             return new DummyArms(i.grade);
                    
        //             case ItemIndexer.Part.Sword:
        //             return new DummySword(i.grade);
                    
        //             case ItemIndexer.Part.Shield:
        //             return new DummyShield(i.grade);
                    
        //             case ItemIndexer.Part.Legs:
        //             return new DummyLegs(i.grade);
        //         }
        //         break;
        //     }
        //     return new GameItem();
        // }
        /*
        public static GameItemSword GenerateGameSword(ItemIndexer i){
            switch(i.family){
                case ItemIndexer.Family.Start:
                break;
                case ItemIndexer.Family.None:
                default:
                return new DummySword(i.grade);
                
            }
            return new GameItemSword(i.grade);
        }
        
        public static GameItemShield GenerateGameShield(ItemIndexer i){
            switch(i.family){
                case ItemIndexer.Family.Start:
                break;
                case ItemIndexer.Family.None:
                default:
                return new DummyShield(i.grade);
                
                
            }
            return new GameItemShield(i.grade);
        }
        public static GameItemLegs GenerateGameLeg(ItemIndexer i){
            switch(i.family){
                case ItemIndexer.Family.Start:
                break;
                case ItemIndexer.Family.None:
                default:
                return new DummyLegs(i.grade);
                
            }
            return new GameItemLegs(i.grade);
        }
        */
    }


    
}