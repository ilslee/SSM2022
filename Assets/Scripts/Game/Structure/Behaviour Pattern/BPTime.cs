using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using System;
namespace ssm.game.structure{
    //BPData.Condition 에서 정의된 명령들을 처리하는 부분
    public class BPTime
    {
        private int characterIndex;
        private List<data.BPTime> time;
        public BPTime(int id, List<data.BPTime> data){
            characterIndex = id;
            time = new List<data.BPTime>();
            foreach(data.BPTime t in data){
                time.Add(t.Duplicate());
            }
        }
        public bool IsAvailable(){
            return true;
        }
    }

    
}