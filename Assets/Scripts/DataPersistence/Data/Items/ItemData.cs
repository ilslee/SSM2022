using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using ssm.game.structure;

namespace ssm.data{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewBasicItem", menuName = "SSM/Item/CreateBasicItem")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public int grade;
        public float[] price;
        public enum Family {None, Default, Life, Death, Assassin, Jester, Emperor, Blacksmith};
        public Family family;
        public enum Part {None, Core, Arms, Chest, Head, Legs, Set, Sheild, Sword};
        public Part part;
        public List<TokenGrade> tokens;
        public void Reset(){
            itemName = "";
            grade = 0;
            family = Family.None;
            part = Part.None;
            tokens = new List<TokenGrade>();
        }        
    }
}