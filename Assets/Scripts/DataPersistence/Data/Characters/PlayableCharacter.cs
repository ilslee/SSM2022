using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ssm.data.item;
using ssm.data.token;

namespace ssm.data{
    [System.Serializable]
    /*
    + Item
    + Memory( = StatB, Motion, Direction, StatA)
    + Buff / Debuff
    */
    public class PlayableCharacter : Character
    {
        
        // public List<ItemIndexer> item;
        public List<ItemData> item;
        public List<Token> core;
        public int score;
        public override void Reset(){
            //Items
            item = new List<ItemData>();
            core = new List<Token>();
            Token hpMax = new Token();
            hpMax.type = GameTerms.TokenType.HPMax;
            hpMax.value = 0f;
            Token hpCurrent = new Token();
            hpCurrent.type = GameTerms.TokenType.HPCurrent;
            hpCurrent.value = 0f;
            
            Token epMax = new Token();
            epMax.type = GameTerms.TokenType.EPMax;
            epMax.value = 0f;
            Token epCurrent = new Token();
            epCurrent.type = GameTerms.TokenType.EPCurrent;
            epCurrent.value = 0f;
            

            core.Add(hpMax);   
            core.Add(hpCurrent);   
            core.Add(epMax);   
            core.Add(epCurrent);   
        }

        public PlayableCharacter Clone(){
            PlayableCharacter clone = ScriptableObject.CreateInstance("PlayableCharacter") as PlayableCharacter;
            
            clone.item = this.item.ToList();
            return clone;
        }
        
    }
}