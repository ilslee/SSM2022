using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.appearance{
    public class HistoryManager : MonoBehaviour
    {
        private int historyCount = 6;
        private float iconGap = 50f; // 각 아이콘 사이 간격
        // Start is called before the first frame update
        public void Start()
        {
            
        }
        public void AddHistory(GameTerms.Motion m){
            //초기에는 애니메이션 없이 하나씩 붙이기
            
            //0번의 아이콘을 세팅
            //컨테이너 밀기
            //끝나면 재정렬
        }
        public void OnAnimationFinished(){

        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}