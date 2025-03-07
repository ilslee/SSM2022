using System.Collections;
using System.Collections.Generic;
using ssm.data.league;
using UnityEngine;
using ssm.game.structure;
using ssm.game.structure.token;
using System.Diagnostics.SymbolStore;
namespace ssm.game.appearance{
    public class StatusManager : MonoBehaviour
    {
        public int charcterIndex = 0;
        public int columnCount = 5;
        public enum Direction {None, Left, Right}
        public Direction direction;
        public IconManager icon;
        private float iconGap = 50f;
        private List<IconManager> statusContainer;
        public UIAnimationManager anim;
        // private List<StatusTestData> statusTestData;
        private void Start(){
            // statusTestData = new List<StatusTestData>();
        }
        public void AddStatus(GameTerms.TokenType t){
            IconManager newStatus = Instantiate(icon, this.transform) as IconManager;;
            newStatus.SetSize(iconGap-2f);
            newStatus.SetIcon(t);
            statusContainer.Add(newStatus);
            RearangeAllStatus();
        }

        public void RemoveStatus(GameTerms.TokenType t){
            IconManager removingIcon = statusContainer.Find(x => x.tokenType == t);
            if(removingIcon == null) return;
            statusContainer.Remove(removingIcon);
            Destroy(removingIcon);
            RearangeAllStatus();
        }
        
        //시간 표시 등 업데이트 - 짧게 확대-축소되는 애니메이션 재생
        private void UpdateAllStatus(){
            TokenList staticList = GameBoard.Instance().FindCharacter(charcterIndex).staticTokens;
            PlayData playDataList = GameBoard.Instance().FindCharacter(charcterIndex).GetLastPlayData();

            //List<TempStatusToken>를 만들어 타입과 번호 저장하여 실체 스태터스와 비교
            List<TempStatusToken> tempStatusToken = new List<TempStatusToken>();
            foreach(GameToken st in staticList){
                TempStatusToken tempToken = new TempStatusToken();
                tempToken.tokenType = st.type;
                tempToken.tokenValue = st.GetTokenValue();
                tempStatusToken.Add(tempToken);
            }
            foreach(GameToken pt in playDataList){
                TempStatusToken tempToken = new TempStatusToken();
                tempToken.tokenType = pt.type;
                tempToken.tokenValue = pt.GetTokenValue();
                tempStatusToken.Add(tempToken);
            }
            /*
            1. 데이터 있고, 아이콘 없으면 없으면 추가
            2. 아이콘 있고, 데이터 없으면 삭제
            3. 데이터, 있고, 아이콘 있으면 갱신
            */
            //1,3 해결
            for (int i = 0; i < tempStatusToken.Count; i++)
            {
                IconManager ic = statusContainer.Find(x => x.tokenType == tempStatusToken[i].tokenType);
                if(ic == null){ // 데이터 있고, 아이콘 없으면
                    AddStatus(tempStatusToken[i].tokenType);
                }else{ //데이터 있고, 아이콘 있으면
                    ic.SetValue(tempStatusToken[i].tokenValue);
                }
            }
            for (int i = statusContainer.Count -1; i >= 0; i--)
            {
                TempStatusToken tt = tempStatusToken.Find(x => x.tokenType == statusContainer[i].tokenType );
                if(tt == null){ // 2. 아이콘 있고, 데이터 없으면 삭제
                    RemoveStatus(statusContainer[i].tokenType);
                }
            }

            

        }

        //List순번에 따라 아이콘 배치
        private void RearangeAllStatus(){
            float d = 0f; // arrange direction
            switch (direction)
            {
                case Direction.Left:
                d = -1f;
                break;
                case Direction.Right:
                d = 1f;
                break;
                default:
                d = 0f;
                break;
            }

            for (int i = 0; i < statusContainer.Count; i++)
            {
                float rowId = Mathf.Floor((float)i / (float)columnCount);
                float colId = Mathf.Floor(((float)i % (float)columnCount));
                statusContainer[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(colId * d, rowId) * iconGap;
            }
        }

        public void ManageGameEvent(string type, float value){
            switch(type){
                case GameEvent.GAME_START_END:
                case GameEvent.TURN_READY_END:
                case GameEvent.TURN_CALCULATE_END:
                UpdateAllStatus();
                break;
            }
        }

    }
    public class TempStatusToken{
        public GameTerms.TokenType tokenType;
        public int tokenValue;
        public TempStatusToken(){
            tokenType = GameTerms.TokenType.None;
            // statusCount = (int)MathTool.GetRandomIntRange(1,5);
            tokenValue = -1;
        }   
    }
}