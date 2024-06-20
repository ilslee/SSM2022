using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
namespace ssm.game.structure{
    public static class BPDataTool
    {
        private static bool EvaluateCondition(int characterIndex, int bpIndex){
            // Character c = GameBoard.GetGameCharacterViaIndex(characterIndex);
            
            
            
            return true;
        }

        private static bool EvaluateCharacterCondition(int characterIndex){
            

            return true;
        }

        private static bool EvaluateGameCondition(int characterIndex){
            

            return true;
        }

        public static int GetPriorBPIndex(int characterIndex){
            int bpIndex = -1;
            // Character me = GameBoard.GetGameCharacterViaIndex(characterIndex);
            
            // for (int i = 0; i < me.bp.Count; i++)
            // {
            //     BPData bp = me.bp[i] as BPData;
            //     if(EvaluateCondition(characterIndex, i) == true){
            //         bpIndex = i;
            //         break;
            //     }
            // }
            return bpIndex;
        }

        
        
    }
}