using System.Collections;
using System.Collections.Generic;
using ssm.data;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public SSMGameData ssmGameData;
    public LeagueData leagueData;

    private List<string> characterName;
    
    public void InitLeague(int difficulty){
        foreach (BPCharacter o in leagueData.opponent)
        {
            Destroy(o);
        }
        leagueData.opponent.Clear();
        int maxTurn = 0;
        float turnTime = 0f;

        int numOfCharacter = 0;
        

        
        //Init Character
        //Init Item
        switch(difficulty){
            case 1:
            numOfCharacter = 10;
            maxTurn = 15;
            turnTime = 5f;
            break;
            case 2:
            numOfCharacter = 10;
            maxTurn = 20;
            turnTime = 3f;
            break;
            case 3:
            numOfCharacter = 10;
            maxTurn = 25;
            turnTime = 2f;
            break;
            case 4:
            numOfCharacter = 10;
            maxTurn = 30;
            turnTime = 1f;
            break;
        }
        BPCharacterGenerator characterGenerator = gameObject.GetComponent<BPCharacterGenerator>();
        if(characterGenerator == null){
            
        }
    }

    private void InitCharacterName(){
        characterName = new List<string>();
        
    }
}
