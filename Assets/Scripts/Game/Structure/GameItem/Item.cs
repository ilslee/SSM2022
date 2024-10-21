using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using ssm.game.structure.token;

namespace ssm.game.structure{
    public class Item 
    {
        internal int grade;
        public GameTerms.ItemFamily family;
        public TokenList token;
        public Item(int grade = 0){
            this.grade = grade;     
            family = GameTerms.ItemFamily.None;
            token = new TokenList();
        }
        
    }
    
}