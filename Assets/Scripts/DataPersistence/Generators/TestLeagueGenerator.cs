using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using ssm.data.item;
using ssm.game.structure;


public class TestLeagueGenerator : MonoBehaviour
{
    [Header("Character1")]
    public ItemData.Family character1ItemFamily = ItemData.Family.Basic;
    public int character1ItemGrade = 0;
    public BPGenerator.MotionKeyword character1BPKeyword;
    [Header("Character2")]
    public ItemData.Family character2ItemFamily = ItemData.Family.Basic;
    public int character2ItemGrade = 0;
    public BPGenerator.MotionKeyword character2BPKeyword;
    
    [Header("World")]
    public WorldBluePrintSO bluePrint;
    
    private const float characterMultiplier = 5f; // 실제 필요한 캐릭터 수의 n배

    public List<BPCharacter> bpCharacters;
    public ItemData testCore;
    public List<ItemData> basicItemSet;
    public List<ItemData> lifeItemSet;
    public List<ItemData> deathItemSet;
    public Game game;
    //랜덤 범위 내에서 캐릭터 생성 characterMultiplier배수만큼 - 나중에 간추릴것임
    public void Start(){
        GenerateBPCharacters();
        ExecuteGame(bpCharacters[0], bpCharacters[1]);
    }
    private void GenerateLeague(){
        
    }
    //Generae BPCharacters
    private void GenerateBPCharacters(){
        int candidateCount = (int)(bluePrint.numOfCharacter*characterMultiplier);
        bpCharacters = new List<BPCharacter>();
        bpCharacters.Add(CreateBPCharacter(character1ItemFamily, character1ItemGrade));
        bpCharacters.Add(CreateBPCharacter(character2ItemFamily, character2ItemGrade));

        Debug.Log("* " + bpCharacters.Count + " Candidates are generated. ");
        
    }

    private BPCharacter CreateBPCharacter(ItemData.Family itemFamily, int itemGrade){
        // BPCharacter o = new BPCharacter();
        BPCharacter o = ScriptableObject.CreateInstance("BPCharacter") as BPCharacter;
        
        //Item
        o.part = new List<ItemData>();
        // o.item.Add(testCore);
        // switch(itemFamily){
        //     case ItemData.Family.Default:
        //     o.item.Add(basicItemSet[0]);
        //     o.item.Add(basicItemSet[1]);
        //     o.item.Add(basicItemSet[2]);
        //     o.item.Add(basicItemSet[3]);
        //     o.item.Add(basicItemSet[4]);
        //     o.item.Add(basicItemSet[5]);    
        //     break;    
        // }

        for (int i = 1; i < o.part.Count; i++)
        {
            o.part[i].grade = itemGrade;
        }        
        
        
        //BP
        BPGenerator bPGenerator = new BPGenerator();
        o.bp = new List<BPData>();
        // BPData defaultBP = ScriptableObject.CreateInstance("BPData") as BPData;
        BPData defaultBP = bPGenerator.GenerateBPData(BPGenerator.EventKeyword.None, BPGenerator.StatusKeyword.None, BPGenerator.TimeKeyword.None, character1BPKeyword, BPGenerator.BehaviourKeyword.None, 6);
        o.bp.Add(defaultBP);
        
        return o;
    }


    //run a league

    // Run a game - change for later use 
    private void ExecuteGame(PlayableCharacter player1, PlayableCharacter player2){
        // game.PrepareGame(100,0f,player1,player2);
        // game.StartGame();
    }
    
    
    public void ManageGameEvent(string type, int id, int value){
        // switch (type)
        // {
        //     case GameEvent.READY_PHASE_OVER:
        //     game.ManageTurnCalculateMEPhase();
        //     break;
        //     case GameEvent.BEHAVIOUR_PHASE_OVER:
        //     game.OverrideDirection();
        //     break;
        //     case GameEvent.DIRECTION_PHASE_OVER:
        //     game.Result();
        //     break;
        //     case GameEvent.RESULT_PHASE_OVER:
        //     game.Feedback();
        //     break;
        //     case GameEvent.FEEDBACK_PHASE_OVER:
        //     game.Ready();
        //     break;
            
        // }
    }
    
    // record
}
