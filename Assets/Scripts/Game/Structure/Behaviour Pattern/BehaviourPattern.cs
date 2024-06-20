using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using System;
namespace ssm.game.structure{
    public class BehaviourPattern
    {
        public int motionIndex;
        public bool isActivated;
        public int activationCount;
        private BPData data;
        // List<List<object>> parsedCondition; // 임의의 예비 길이로 선언
        public int motionCount;
        public BehaviourPattern(BPData bpData){
            //데이터 이관
            data = bpData;
            activationCount = 0;
            motionCount = bpData.motion.Count;
            motionIndex = -1;
            isActivated = false;
            
        }
        public bool CheckActivation(Character me, Character other){
            return true;
            //TODO : Condition 체크 내용 작성 필요
           
            /*
            bool CheckConditionEssential(List<object> data){
                switch(data[0]){
                    case GameTerms.BPCondition.STATIC_ALWAYS:
                    return true;
                    case GameTerms.BPCondition.STATIC_STEP_UP:
                    return true; //TODO : 여기 조건 재정의해줘야 함
                }
                return false;
            }
            bool CheckConditionTime(List<object> data){
                // switch(data[0]){
                //     case GameTerms.BPCondition.STATIC_ALWAYS:
                //     return true;
                //     case GameTerms.BPCondition.STATIC_STEP_UP:
                //     return true;
                // }
                return false;
            }
            bool CheckConditionCharcter(List<object> data){
                // switch(data[0]){
                //     case GameTerms.BPCondition.STATIC_ALWAYS:
                //     return true;
                //     case GameTerms.BPCondition.STATIC_STEP_UP:
                //     return true;
                // }
                return false;
            }
            */
        }
        

        public void Activate(){
            isActivated = true;
            activationCount ++;
        }
        public void Proceed(){
            motionIndex++;
        }
        public void Deactivate(){
            // Debug.Log("BehaviourPattern.Deactivate called");
            motionIndex = -1;
            isActivated = false;
        }
        
        public GameTerms.Motion GetMotion(){
            Debug.Log("BehaviourPattern.GetMotion : converting - " + data.motion[motionIndex]);
            switch(data.motion[motionIndex]){
                case BPT.Motion.Attack:
                return GameTerms.Motion.Attack;
                case BPT.Motion.Strike:
                return GameTerms.Motion.Strike;
                case BPT.Motion.Defence:
                return GameTerms.Motion.Defence;
                case BPT.Motion.Charge:
                return GameTerms.Motion.Charge;
                case BPT.Motion.Avoid:
                return GameTerms.Motion.Avoid;
                case BPT.Motion.Taunt:
                return GameTerms.Motion.Taunt;
                case BPT.Motion.Random:
                return GetRandomMotion();
            }            
            return GameTerms.Motion.None;

            GameTerms.Motion GetRandomMotion(){
                int id = MathTool.GetRandomIndex(6);
                switch(id){
                    case 0:
                    return GameTerms.Motion.Attack;
                    case 1:
                    return GameTerms.Motion.Strike;
                    case 2:
                    return GameTerms.Motion.Defence;
                    case 3:
                    return GameTerms.Motion.Charge;
                    case 4:
                    return GameTerms.Motion.Avoid;
                    case 5:
                    return GameTerms.Motion.Taunt;
                }
                return GameTerms.Motion.None;
            }
        }
        
    }
}