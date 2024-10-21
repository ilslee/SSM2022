using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using System;
using Unity.VisualScripting;
namespace ssm.game.structure{
    public class BehaviourPattern
    {
        public int characterIndex;
        public int motionIndex;
        public bool isActivated;
        public int activationCount;
        // private BPData data;

        private BPCondition condition;
        private BPTime time;
        private BPBehaviour behaviour;
        private BPMotion motion;
        
        // List<List<object>> parsedCondition; // 임의의 예비 길이로 선언
        public int motionCount;
        public BehaviourPattern(int chaId, BPData bpData){
            //데이터 이관
            characterIndex = chaId;
            activationCount = 0;
            motionCount = bpData.motion.Count;
            motionIndex = -1;
            isActivated = false;

            condition = new BPCondition(characterIndex, bpData.condition);
            time = new BPTime(characterIndex, bpData.time);
            motion = new BPMotion(characterIndex, bpData.motion);
            behaviour = new BPBehaviour(characterIndex, bpData.behaviour);
        }
        public bool CheckActivation(){
            return condition.IsAvailable();
        }
        

        public void Activate(){
            Debug.Log("Activate BP");
            isActivated = true;
            activationCount ++;
            behaviour.OnActivation();
        }
        public void Proceed(){
            if(motion.IsLast(motionIndex) == true) Deactivate();
            else motionIndex++;
        }
        public void Deactivate(){
            Debug.Log("Deactivate BP");
            motionIndex = -1;
            isActivated = false;
            // Debug.Log("BehaviourPattern.Deactivate called");
            behaviour.OnDeactivation();
        }
        
        public GameTerms.Motion GetMotion(){
            Debug.Log("GetMotion" + motionIndex);
            return motion.Yield(motionIndex);
        }
        
    }
}