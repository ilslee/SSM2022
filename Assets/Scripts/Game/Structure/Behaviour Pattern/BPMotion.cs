using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using Unity.VisualScripting;
namespace ssm.game.structure{
    public class BPMotion
    {
        private int characterIndex;
        private List<BPToken.Motion> motions;
        public BPMotion(int id, List<BPToken.Motion> data){
            characterIndex = id;
            motions = new List<BPToken.Motion>();
            foreach(BPToken.Motion m in data){
                motions.Add(m);
            }
        }
        public GameTerms.Motion Yield(int index){
            Debug.Log("BehaviourPattern.GetMotion : converting - " + motions[index].ToString());
            
            switch(motions[index]){
                case BPToken.Motion.Attack:
                return GameTerms.Motion.Attack;
                case BPToken.Motion.Strike:
                return GameTerms.Motion.Strike;
                case BPToken.Motion.Defence:
                return GameTerms.Motion.Defence;
                case BPToken.Motion.Charge:
                return GameTerms.Motion.Charge;
                case BPToken.Motion.Avoid:
                return GameTerms.Motion.Avoid;
                case BPToken.Motion.Rest:
                return GameTerms.Motion.Rest;
                case BPToken.Motion.Random:
                return ManageRandom();
            }
            return GameTerms.Motion.None;
        }
        public bool IsLast(int index){
            if(index >= motions.Count-1) return true;
            else return false;
        }
        private GameTerms.Motion ManageRandom(){
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
                return GameTerms.Motion.Rest;
                case 5:
                return GameTerms.Motion.Avoid;
            }
            return GameTerms.Motion.None;
        }
    }
}
