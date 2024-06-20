using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.data{
    
    [System.Serializable]   
    [CreateAssetMenu(fileName = "LeagueData", menuName = "SSM/Data/League")]
    public class LeagueData : ScriptableObject
    {
        public List<BPCharacter> opponent;

        public List<ItemData> shopItem;

        public int progress;
        
    }
}