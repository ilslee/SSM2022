using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ssm.game.structure{
    public class BasicSet : Item
    {
        public BasicSet(int grade = 0): base(grade){
            family = GameTerms.ItemFamily.Basic;
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartGame, SetGrade));            
        }
        
        
    }
}