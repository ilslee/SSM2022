using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class Expectation : List<TokenList>{
        public void Reset(Character me, Character other){
            this.Clear();
        }
    }
}