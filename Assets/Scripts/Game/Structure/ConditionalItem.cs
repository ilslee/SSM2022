// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// namespace ssm.game.structure{
//     public class BPData
//     {
//         public bool isActivated;
//         public List<ssm.data.BPData.Condition> condition;
        

//         public BPData(ssm.data.BPData data){

//             // isActivated = data.isActivated;
//             condition = data.condition;
            
//         }

//         public bool CheckCondition(){
//             //TODO: Fill the body 
//             return true;
//         }
//     }
//     public class Condition{
//             //Group 1
//             public GameTerms.ConditionWhen when;
//             public int when1;
//             // public GameTerms.Period endPeriod;
//             public int when2;
//             //Group 2
//             public GameTerms.ConditionWho who;    
//             //Group 3
//             public GameTerms.ConditionWhat what;
//             public GameTerms.ConditionHow how;
//             public int howValue;
//             public Condition(){
//                 when = GameTerms.ConditionWhen.None;
//                 when1 = 0;
//                 when2 = 0;
                
//                 who = GameTerms.ConditionWho.None;    

//                 what = GameTerms.ConditionWhat.None;
//                 how = GameTerms.ConditionHow.None;
//                 howValue = 0;
//             }
//             //Condition을 평가하여 활성화 여부를 판단
//             //Who What When How로 판단
//             public bool Evaluate(int myCharacterIndex){
//                 bool value = false;
//                 //Who를 기준으로 가지치기
//                 switch(who){
//                     case GameTerms.ConditionWho.Me:
//                     value = EvaluateCharacter(myCharacterIndex);
//                     break;
//                     case GameTerms.ConditionWho.Opponent:
//                     value = EvaluateCharacter(GameTool.GetOpositeCharacterIndex(myCharacterIndex));
//                     break;
//                     case GameTerms.ConditionWho.Both:
//                     bool val1 = EvaluateCharacter(myCharacterIndex);
//                     bool val2 = EvaluateCharacter(GameTool.GetOpositeCharacterIndex(myCharacterIndex));
//                     if(val1 == true && val2 == true) value = true;
//                     break;
//                     case GameTerms.ConditionWho.Game:
//                     value = EvaluateGame();
//                     break;
//                     default : 
//                     value = true;
//                     break;
//                 }
//                 return value;
//             }

//             private bool EvaluateCharacter(int characterIndex){

//                 //Convert When to PlayDataIndex
//                 int[] whenValue = ConvertWhen();
//                 if(EvaluateWhen(whenValue) == true){
//                     List<int> whatValue = CalculateWhatValue(characterIndex, whenValue);
//                     //CompareWhatvalueHowValue
//                 }
//                 return false;
//             }
            
//             private int[] ConvertWhen(){
//                 int value1 = 0;
//                 int value2 = 0;
                
//                 // //convert When via ConditionWhenType
//                 // switch(when){
//                 //     case GameTerms.ConditionWhen.At:
//                 //     value1 = when1;
//                 //     break;
//                 //     case GameTerms.ConditionWhen.Current:
//                 //     value1 = GameBoard.Turn;
//                 //     break;
//                 //     case GameTerms.ConditionWhen.Duration:
//                 //     value1 = Mathf.Min(when1, when2);
//                 //     value2 = Mathf.Max(when1, when2);
//                 //     break;
//                 //     case GameTerms.ConditionWhen.Every:
//                 //     if(when1 % GameBoard.Turn == 0) value1 = GameBoard.Turn;
//                 //     else value1 = 0;
//                 //     break;
//                 //     case GameTerms.ConditionWhen.Previous:
//                 //     value1 = GameBoard.Turn - when1;
//                 //     break;
//                 //     case GameTerms.ConditionWhen.PreviousDuration:
//                 //     int prev1 = GameBoard.Turn - when1;
//                 //     int prev2 = GameBoard.Turn - when2;
//                 //     value1 = Mathf.Min(prev1, prev2);
//                 //     value2 = Mathf.Max(prev1, prev2);
//                 //     break;
//                 // }
//                 //convert to PlayData if this is for characters
//                 int[] returnVal = new int[2];
//                 returnVal[0] = value1;
//                 returnVal[1] = value2;
//                 return returnVal;
//             }

//             private bool EvaluateWhen(int[] whenValue){
//                 bool value = false;
//                 switch(when){
//                     case GameTerms.ConditionWhen.At:
//                     case GameTerms.ConditionWhen.Current:
//                     case GameTerms.ConditionWhen.Every:
//                     case GameTerms.ConditionWhen.Previous:
//                     if(whenValue[0] > 0) value = true;
//                     break;
                    
//                     case GameTerms.ConditionWhen.Duration:
//                     case GameTerms.ConditionWhen.PreviousDuration:
//                     if(whenValue[0] > 0 && whenValue[1] > 0) value = true;
//                     break;
                    
//                 }
//                 return value;
//             }
//             private List<int> CalculateWhatValue(int characterIndex, int[] whenValue){
//                 List<int> returnVal = new List<int>();
//                 int GetWhatValue(int when){
//                     int value = 0;
//                     switch(what){
//                         case GameTerms.ConditionWhat.Turn:
//                         value = when;
//                         break;
//                         case GameTerms.ConditionWhat.Health:
//                         // value = GameBoard.GetGamePlayData(characterIndex, when).tokenStart.health;
//                         break;
//                         //TODO : 각종 경우의 수 추가
//                     }
//                     return value;
//                 }
//                 switch(when){
//                     case GameTerms.ConditionWhen.At:
//                     case GameTerms.ConditionWhen.Current:
//                     case GameTerms.ConditionWhen.Previous:
//                     returnVal.Add(GetWhatValue(whenValue[0]));
//                     break;
                    
//                     case GameTerms.ConditionWhen.Duration:
//                     case GameTerms.ConditionWhen.PreviousDuration:
//                     for (int i = whenValue[0]; i < whenValue[1]; i++)
//                     {
//                         returnVal.Add(GetWhatValue(i));
//                     }
//                     break;
                    
//                     case GameTerms.ConditionWhen.Every:
//                     // for (int i = 1; i < GameBoard.Turn; i++)
//                     // {
//                     //     if(i % when1 == 0){
//                     //         returnVal.Add(GetWhatValue(i));
//                     //     }                        
//                     // }
//                     break;

//                 }
//                 return returnVal;
//             }
//             //How에 따라 When과 What의 값 평가
//             private bool EvaluateValues(List<int> whatValue){
//                 bool returnVal = false;
//                 switch(how){
//                     case GameTerms.ConditionHow.Equal:
//                     if(whatValue[0] == howValue)returnVal = true;
//                     break;
//                 }
//                 return returnVal;
//             }
            
//             private bool EvaluateGame(){
//                 return false;
//             }
//         }
// }
