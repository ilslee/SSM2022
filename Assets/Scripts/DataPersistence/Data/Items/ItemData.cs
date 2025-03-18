using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.token;
namespace ssm.data.item{
    [CreateAssetMenu(fileName = "Item", menuName = "SSM/Item/Item")]
    public class ItemData : ScriptableObject
    {
        public enum Family {None, Basic, Assassin, Blacksmith, Clown, Dancer, Death, Emperor, Fighter, Life, Orator, Soldier};
        public enum Part {None, Body, Leg, Shield, Sword, Set, Accessory};
        
        public Family family;
        public Part part;
        public int grade;
        public float price;
        public List<Token> tokens;
        public virtual void Reset(){
            family = Family.None;
            part = Part.None;
            grade = -1;
            price = -1f;
            tokens = new List<Token>();   
        }
        public void OnValidate()
        {
            UpdateItemData();
        }
        public virtual void UpdateItemData(){

        }
        
    }
    
}