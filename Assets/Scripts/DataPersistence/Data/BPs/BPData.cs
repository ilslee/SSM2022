using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.data{
    [System.Serializable]
    // [CreateAssetMenu(fileName = "BPData", menuName = "SSM/BehabiourPattern/BPData")]
    //여기서는 명령어 정의만 내림
    public class BPData 
    {
        // public List<object> condition;
        public BPT.Event conditionEvent;
        public BPT.State conditionStatus;
        public BPT.Time conditionTime;
        public List<BPT.Motion> motion; // BPCondition의 모션 파트 같이 사용
        public List<BPT.Behaviour> behaviour;

        public BPData(){
            // condition = new List<object>(); 
            conditionEvent = new BPT.Event();
            conditionStatus = new BPT.State();
            conditionTime = new BPT.Time();
            motion = new List<BPT.Motion>();
            behaviour = new List<BPT.Behaviour>();
        }
        public override string ToString()
        {
            string returnVal = "BPData : ";
            // returnVal += "\n Condition (" + condition.Count + ") : ";
            // foreach(var c in condition){
            //     returnVal += c.ToString() + " - ";
            // }
            returnVal += "\n Motion (" + motion.Count + ") : ";
            foreach(var m in motion){
                returnVal += m + " - ";
            }
            returnVal += "\n Behaviour (" + behaviour.Count + ") : ";
            foreach(var b in behaviour){
                returnVal += b.ToString() + " - ";
            }
            return returnVal;
        }
        
    }
}