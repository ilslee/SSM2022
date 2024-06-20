using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;

namespace ssm.game.structure{
    public class Item 
    {
        internal int grade;
        public GameTerms.ItemFamily family;
        public List<StatTokenFactory> stFactory;
        public Item(int grade = 0){
            this.grade = grade;     
            family = GameTerms.ItemFamily.None;
            stFactory = new List<StatTokenFactory>();
        }
        
    }
    /*
    public class ItemSet : List<Item>{
        
        public void Operate(StatTokenFactory.OperateType t, Character me, Character other){
            
            
            foreach (Item item in this)
            {
                foreach( StatTokenFactory f in item.stFactory){
                    if(f.type == t ) f.operate(me, other);
                }
            }
        }
        
       
    }
    */
    public class ItemSet : List<ItemData>{

    }
}