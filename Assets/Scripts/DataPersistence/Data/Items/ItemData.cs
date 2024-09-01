using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using ssm.game.structure;
using ssm.data.token;
namespace ssm.data{
    [System.Serializable]
    public class ItemData
    {
        public int id;
        public string itemName;
        public int grade;
        public float price;
        public enum Family {None, Default, Assassin, Blacksmith, Clown, Dancer, Death, Emperor, Fighter, Life, Orator, Soldier};
        public Family family;
        public enum Part {None, Body, Legs, Sheild, Sword, Accessory};
        public Part part;
        public TokenList tokens;
        public ItemData(int g = 0){
            grade = g;
        }
        /*
        public void Reset(){
            itemName = "";
            grade = 0;
            price = 0f;
            family = Family.None;
            part = Part.None;
            tokens = new List<Token>();
        } 
        */       
    }
}