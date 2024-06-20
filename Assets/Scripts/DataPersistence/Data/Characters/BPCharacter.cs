using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using ssm.game.structure;
namespace ssm.data{
    
    /* Opponent
    + BP
    */
    //[System.Serializable]
    [CreateAssetMenu(fileName = "BPCharacter", menuName = "SSM/Character/BPCharacter")]
    public class BPCharacter : PlayableCharacter
    {
        public List<BPData> bp;
        
    }
    
}