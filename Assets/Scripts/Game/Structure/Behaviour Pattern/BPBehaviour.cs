using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
namespace ssm.game.structure{
    public class BPBehaviour
    {
        private int characterIndex;
        private List<data.BPBehaviour> behaviours;
        public BPBehaviour(int id, List<data.BPBehaviour> data){
            characterIndex = id;
            behaviours = new List<data.BPBehaviour>();
            foreach(data.BPBehaviour b in data){
                behaviours.Add(b.Duplicate());
            }
        }
        public void OnActivation(){  
            Debug.Log("BPBehaviour.OnActivation called. Character " + characterIndex + " / " + behaviours.Count);
            foreach(data.BPBehaviour b in behaviours){
                if(b.occasion == BPToken.BehaviourOccasion.Activation){
                    switch(b.type){
                        
                    }
                }else{
                    if(GetBP().motionIndex < 0) GetBP().motionIndex = 0; // 기본 동작임 인덱스가 -1이면 0으로
                }
            } 
        }
        public void OnDeactivation(){
            foreach(data.BPBehaviour b in behaviours){
                if(b.occasion == BPToken.BehaviourOccasion.Deactivation){
                    switch(b.type){
                        case BPToken.BehaviourType.Rewind:
                        GetBP().motionIndex = 0;
                        break;
                    }
                }
            }
        }

        private BehaviourPattern GetBP(){
            BPManager bpm = GameBoard.Instance().FindCharacter(characterIndex).bpManager;
            return bpm[bpm.currentBPIndex];
        }
    }
}