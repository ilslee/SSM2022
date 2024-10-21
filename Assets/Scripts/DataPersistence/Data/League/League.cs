using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data.gameDialogue;
namespace ssm.data.league{
    [Serializable]
    [CreateAssetMenu(fileName = "LeagueData", menuName = "SSM/Data/LeagueData")]
    public class League : ScriptableObject
    {
        // public int gameIndex;
        public int maxTurn;
        public float turnTime;
        public int gameIndex;
        public List<Game> gameData;
        public void Reset()
        {
            gameIndex = 0;
            maxTurn = 20;
            turnTime = 10f;
            gameData = new List<Game>();
        }

        
    }

    
    
    
}