using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using System;
namespace ssm.game.structure{
    //BPData.Condition 에서 정의된 명령들을 처리하는 부분
    public class BPCondition
    {
        private int characterIndex;
        private List<data.BPCondition> conditions;
        public BPCondition(int id, List<data.BPCondition> data){
            characterIndex = id;
            conditions = new List<data.BPCondition>();
            foreach(data.BPCondition c in data){
                conditions.Add(c.Duplicate());
            }
        }
        public bool IsAvailable(){
            return true;
        }
    }

    
}
