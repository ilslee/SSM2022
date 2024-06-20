using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.data{
    public class LeagueGenerator : MonoBehaviour
    {
        public void Generate(LeagueData targetLeague, int difficulty){
            


            int numOfCharacter = 0;
            switch(difficulty){
                case 0:
                break;
                case 1: //easy
                numOfCharacter = 10;
                break;
                case 2: // normal
                numOfCharacter = 10;
                break;
                case 3: // hard
                numOfCharacter = 10;
                break;
                case 4: // endgame
                numOfCharacter = 10;
                break;
            }
            
            //Generate Character
            //Reset League Character
            targetLeague.opponent.Clear();

            BPCharacterGenerator characterGenerator = gameObject.GetComponent<BPCharacterGenerator>();
            if(characterGenerator == null){
                Debug.LogError("LeagueGenerator.Generate : No Character Generator Found.");
                return;
            }
            //characterGenerator.Generate()
            for(int i = 0; i < numOfCharacter; i++)
            {
                
            }
        }
    }
}