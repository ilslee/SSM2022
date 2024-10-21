using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
namespace ssm.game.structure{
    public class BPManager : List<BehaviourPattern>
    {
        public int currentBPIndex;
        public BPManager(){
            currentBPIndex = -1;
        }

        public GameTerms.Motion Calculate(Character me, Character other){
            //1. Check Condition and Activate
            int previousBPIndex = currentBPIndex;
            for (int i = 0; i < this.Count; i++)
            {
                if(this[i].CheckActivation() == true || i >= this.Count-1){
                    currentBPIndex = i;
                    break;           
                }
            }
            Debug.Log("BPManager.Calculate : prevID = " + previousBPIndex + " / curID = " + currentBPIndex);
            if(currentBPIndex != previousBPIndex){
                this[currentBPIndex].Activate();
                if(previousBPIndex >= 0)this[previousBPIndex].Deactivate(); 
            }
            GameTerms.Motion returenValue = this[currentBPIndex].GetMotion();
            Debug.Log("Final Motion = " + returenValue);
            this[currentBPIndex].Proceed();
            
            
            return returenValue;
        }
    }
}
