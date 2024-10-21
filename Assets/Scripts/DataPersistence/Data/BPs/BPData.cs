using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.data{
    [Serializable]
    [CreateAssetMenu(fileName = "BPData", menuName = "SSM/BehabiourPattern")]
    //여기서는 명령어 정의만 내림
    public class BPData : ScriptableObject 
    {
        
        public List<BPCondition> condition;
        public List<BPTime> time;
        public List<BPBehaviour> behaviour;
        public List<BPToken.Motion> motion; // BPCondition의 모션 파트 같이 사용
        
        public void Reset(){
            // condition = new List<object>(); 
            condition = new List<BPCondition>();
            time = new List<BPTime>();
            behaviour = new List<BPBehaviour>();
            motion = new List<BPToken.Motion>();
            
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

    [Serializable]
    public class BPCondition{
        public BPToken.Character character;
        public BPToken.ConditionType type;
        public BPToken.Comparison comparison;
        public float value;
        public BPCondition(){
            character = BPToken.Character.None;
            type = BPToken.ConditionType.None;
            comparison = BPToken.Comparison.None;
            value = 0f;
        }
        public BPCondition Duplicate(){
            BPCondition returnValue = new BPCondition();
            returnValue.character = this.character;
            returnValue.type = this.type;
            returnValue.comparison = this.comparison;
            returnValue.value = this.value;
            return returnValue;
        }
    }
    [Serializable]
    public class BPTime{
        public BPToken.TimeType type;
        public float value;
        public BPTime(){
            type = BPToken.TimeType.None;
            value = 0f;
        }
        public BPTime Duplicate(){
            BPTime returnValue = new BPTime();
            returnValue.type = this.type;
            returnValue.value = this.value;
            return returnValue;
        }
    }
    [Serializable]
    public class BPBehaviour{
        //occasion
        public BPToken.BehaviourOccasion occasion;
        //behaviourType  
        public BPToken.BehaviourType type;
        public int value;
        public BPBehaviour(){
            occasion = BPToken.BehaviourOccasion.None;
            type = BPToken.BehaviourType.None;
            value = 0;
        }
        public BPBehaviour Duplicate(){
            BPBehaviour returnValue = new BPBehaviour();
            returnValue.type = this.type;
            returnValue.occasion = this.occasion;
            return returnValue;
        }
    }
}