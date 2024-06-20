using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ssm.data
{
   [System.Serializable]   
   [CreateAssetMenu(fileName = "SSMGameData", menuName = "SSM/Data/Game")]
   public class SSMGameData : ScriptableObject
   {
      //난이도와 진행상황 관련 변수들
      public bool isFirstStart; // 첫 시작 여부 -튜토리얼 들어가면 컷씬 작동여부
      public int worldAvailable; // 생성 가능한 최대 난이도
      public bool isHighlightLatestWorld; // 최종 난이도 하이라이트 여부 : 시각적 피드백. 새 월드 생성하면 해제
      public int currentWorld; // 현재 생성되어 있는 난이도
      public int currnetWorldProgress; // world 내 진행상황

      public PlayableCharacter player;

      public void Reset(){
         isFirstStart = true;
         worldAvailable = 1;
         isHighlightLatestWorld = true;
         currentWorld = -1;
         currnetWorldProgress = -1;

         // player = new PlayableCharacter();
      }
   }   
}

