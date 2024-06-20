using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BluePrint", menuName = "SSM/WorldGenerator", order = 1)]
public class WorldBluePrintSO : ScriptableObject
{
    public enum BPType{Default, Stat, Deception, DirectionOR, DifficultyModulator}
    public int numOfCharacter;
    public int maxTurn;
    public float turnTime;

    //Stats
    public int minHealth;    
    public int maxHealth;    
    public int minEnergy;
    public int maxEnergy;    
    public int minAttack;    
    public int maxAttack;
    public int minDefence;    
    public int maxDefence;

    //Bp Setting
    public List<BPBlueprint> bpBlueprint;

    //Item Setting
    public int minItemLevel;
    public int maxItemLevel;

    //Buff Setting
    public int minBuffLevel;
    public int maxBuffLevel;

    public void Reset(){
        numOfCharacter = 0;
        maxTurn = 0;
        turnTime = 0f;
        
        minHealth = 0;    
        maxHealth = 0;    
        minEnergy = 0;
        maxEnergy = 0;    
        minAttack = 0;    
        maxAttack = 0;
        minDefence = 0;    
        maxDefence = 0;


        bpBlueprint = new List<BPBlueprint>();
        minItemLevel = 0;
        maxItemLevel = 0;
        minBuffLevel = 0;
        maxBuffLevel = 0;
    }
    


    [System.Serializable]
    public class BPBlueprint{
        public BPType type;
        public int conditionCount;
        public int minPM;
        public int maxPM;
        public int maxFinisher;
    }
}


