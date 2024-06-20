using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class MotionExpectation : List<ModifierList>{
        
        public void Calculate(Character me, Character other){
            // if(me.playData.Count <1){
            //     Debug.Log("MotionExpectation.Calculate : No playdata. Initialize character first.");
            //     return;
            // }

            // int motionLength = System.Enum.GetValues(typeof(GameTerms.Motion)).Length;
            // //최초 me.expectation의 길이 배정
            // if(me.expectation.Count != motionLength){
            //     for (int i = 0; i < motionLength ; i++){
            //         me.expectation.Add(new ModifierList());
            //     }
            // }
            // for (int i = 0; i < motionLength ; i++){
            //     ModifierList myME = me.expectation[i];
            //     myME.Reset(); //ME 전 초기화
                
            //     GameTerms.Motion m = (GameTerms.Motion)i;                   
            //     myME.motion = m;
            //     myME.consumption.Combine(me.item.GetMEConsumption(me, other, m));
            //     myME.consumption.Ceiling(me.GetStatus());
            //     myME.power = me.item.GetMEPower(me, other, m);
            //     myME.modifier.Combine(me.item.GetMEModifier(me, other, m));
                
            //     myME.responsibleConsumption.Combine(me.item.GetAdaptiveMEConsumption(me, other, m));
            //     myME.responsiblePower = me.item.GetAdaptiveMEPower(me, other, m);
            //     myME.responsibleModifier.Combine(me.item.GetAdaptiveMEModifier(me, other, m));                
            // }
            
        }
        public int GetConsumption(GameTerms.Motion m, GameTerms.MTType t){
            // foreach(var item in GetMEItem(m).consumption){
            //     if(item.type == t) return item.value;
            // }
            return 0;
        }
        
        // public PlayData GetMEItem(GameTerms.Motion m){
        //     return this[(int)m];
        // }
    }

    


    
}