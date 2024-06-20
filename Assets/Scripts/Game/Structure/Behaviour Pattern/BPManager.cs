using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
namespace ssm.game.structure{
    public class BPManager : List<BehaviourPattern>
    {
        public GameTerms.Motion currentMotion;
        public BPManager(){
            
        }

        public GameTerms.Motion Calculate(Character me, Character other){
            //1. Check Condition and Activate
            for (int i = 0; i < this.Count; i++)
            {
                if(this[i].isActivated == false && this[i].CheckActivation(me, other) == true){
                    this[i].Activate();                    
                }
            }
            // find prime bp index
            int primeBPIndex  = this.FindIndex(x => x.isActivated == true);
            if(primeBPIndex < 0) primeBPIndex = this.Count-1; // 방어코드
            //Proceed. Check Condition and Activate
            for (int i = 0; i < this.Count; i++)
            {
                if(this[i].isActivated == true){
                    this[i].Proceed();
                }
            }
            GameTerms.Motion returnMotion = this[primeBPIndex].GetMotion();
            
            for (int i = 0; i < this.Count; i++)
            {
                if(this[i].motionIndex >= this[i].motionCount-1){
                    this[i].Deactivate();
                }
            }
            return returnMotion;
        }
    }
}
