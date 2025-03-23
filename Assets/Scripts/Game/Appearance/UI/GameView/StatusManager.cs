using System.Collections;
using System.Collections.Generic;
using ssm.data.league;
using UnityEngine;
using ssm.game.structure;
using ssm.game.structure.token;
using System.Linq;
using System;
namespace ssm.game.appearance{
    public class StatusManager : MonoBehaviour
    {
        public int characterIndex = 0;
        public int columnCount = 5;
        public enum Direction {None, Left, Right}
        public Direction direction;
        public IconManager icon;
        private float iconGap = 50f;
        private List<IconManager> statusContainer;
        public UIAnimationManager anim;
        // private List<StatusTestData> statusTestData;
        private void Start(){
            statusContainer = new List<IconManager>();
            // statusTestData = new List<StatusTestData>();
        }
        private void AddStatus(GameTerms.TokenType t, int v = -1){
            Debug.Log("StatusManager.AddStatus : " + t.ToString());
            IconManager newStatus = Instantiate(icon, this.transform) as IconManager;;
            newStatus.SetSize(iconGap-2f);
            newStatus.SetIcon(t);
            statusContainer.Add(newStatus);
            RearangeAllStatus();
        }

        private void RemoveStatus(GameTerms.TokenType t){
            int removingID = statusContainer.FindIndex(x => x.tokenType == t);
            if(removingID == -1) return;
            Destroy(statusContainer[removingID]);
            statusContainer.RemoveAt(removingID);            
            RearangeAllStatus();
        }
        private void UpdateStatus(GameTerms.TokenType t, int v = -1){
            IconManager updatingIcon = statusContainer.Find(x => x.tokenType == t);
            if(updatingIcon == null) return;
            updatingIcon.SetValue(v);

        }
        //시간 표시 등 업데이트 - 짧게 확대-축소되는 애니메이션 재생
        private void UpdateAllStatus(){

            TokenList staticList = GameBoard.Instance().FindCharacter(characterIndex).staticTokens;
            PlayData playDataList = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData();
            // string staticTokenList = "Character " + characterIndex.ToString() + " Static Token List";
            
            
            //List<TempStatusToken>를 만들어 타입과 번호 저장하여 실체 스태터스와 비교
            List<TempStatusToken> tempStatusToken = new List<TempStatusToken>();
            foreach(GameToken st in staticList){
                // staticTokenList += "\n" + st.type.ToString() + " / disp : " + st.isDisplayed.ToString();
                if(st.isDisplayed == false) continue; // displayed == false면 고려 대상에서 제외
                TempStatusToken tempToken = new TempStatusToken();
                tempToken.tokenType = st.type;
                // Debug.Log("st.type : " + st.type.ToString());
                tempToken.tokenValue = st.GetTokenValue();
                tempStatusToken.Add(tempToken);
            }
            // Debug.Log(staticTokenList);
            foreach(GameToken pt in playDataList){
                if(pt.isDisplayed == false) continue; // displayed == false면 고려 대상에서 제외
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
            /*
            for (int i = 0; i < tempStatusToken.Count; i++) 
            {
                Debug.Log("Temp StatusList [" + i + "] : " + tempStatusToken[i].tokenType.ToString());
                IconManager ic = statusContainer.Find(x => x.tokenType == tempStatusToken[i].tokenType);
                if(ic == null){ // 데이터 있으면서, 아이콘 없고 isDisplayed == true
                    Debug.Log("Add Status to player " + characterIndex + " : " + tempStatusToken[i].tokenType.ToString());
                    Debug.Log("Status Count : " + statusContainer.Count.ToString());
                    AddStatus(tempStatusToken[i].tokenType);
                }else{ //데이터 있고, 아이콘 있으면
                    ic.SetValue(tempStatusToken[i].tokenValue);
                }
            }
            for (int i = statusContainer.Count -1; i >= 0; i--)
            {
                TempStatusToken tt = tempStatusToken.Find(x => x.tokenType == statusContainer[i].tokenType );
                if(tt == null){ // 2. 아이콘 있고, 데이터 없으면 삭제                    
                    Debug.Log("Remove Status of player " + characterIndex + " : " + statusContainer[i].tokenType.ToString());
                    RemoveStatus(statusContainer[i].tokenType);
                    Debug.Log("Status Count : " + statusContainer.Count.ToString());
                }
            }
            */
            List<TempStatusToken> status = GetStatuses();
            List<TempStatusToken> character = GetGameTokens();
            TempStatusTokenCompare comparer = new TempStatusTokenCompare();
            List<TempStatusToken> addToStatus = character.Except(status, comparer).ToList();
            List<TempStatusToken> removeFromStatus = status.Except(character, comparer).ToList();
            List<TempStatusToken> updateStatus = character.Intersect(status, comparer).ToList();
            string beforeStr = "< Character " + characterIndex.ToString() + " Status Update Before >";
            beforeStr += "\n---Status";
            foreach(TempStatusToken s in status){
                beforeStr += s.tokenType.ToString() + " | ";
            }
            beforeStr += "\n---Character";
            foreach(TempStatusToken c in character){
                beforeStr += c.tokenType.ToString() + " | ";
            }
            Debug.Log(beforeStr);
            string updateStr = "< Character " + characterIndex.ToString() + " Status Update Result >";
            updateStr += "\n---ADD : ";
            foreach(TempStatusToken a in addToStatus){
                updateStr += a.tokenType.ToString() + " | ";
                AddStatus(a.tokenType, a.tokenValue);
            }            
            updateStr += "\n---Remove : ";
            foreach(TempStatusToken r in removeFromStatus){
                updateStr += r.tokenType.ToString() + " | ";
                RemoveStatus(r.tokenType);
            }
            
            updateStr += "\n---Update : ";
            foreach(TempStatusToken u in updateStatus){
                updateStr += u.tokenType.ToString() + " | ";
                UpdateStatus(u.tokenType, u.tokenValue);
            }
            Debug.Log(updateStr);

            List<TempStatusToken> GetStatuses(){
                List<TempStatusToken> returnVal = new List<TempStatusToken>();
                foreach(IconManager i in statusContainer){
                    returnVal.Add(new TempStatusToken(i.tokenType, 0));
                }
                return returnVal;
            }

            List<TempStatusToken> GetGameTokens(){
                List<TempStatusToken> returnVal = new List<TempStatusToken>();
                foreach(GameToken st in GameBoard.Instance().FindCharacter(characterIndex).staticTokens){
                    if(st.isDisplayed == true) {
                        returnVal.Add(new TempStatusToken(st.type, st.GetTokenValue()));
                    }
                }
                
                foreach(GameToken tt in GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData()){
                    if(tt.isDisplayed == true) {
                        returnVal.Add(new TempStatusToken(tt.type, tt.GetTokenValue()));
                    }
                }
                return returnVal;
            }
        }

        //List순번에 따라 아이콘 배치
        private void RearangeAllStatus(){
            float d = 0f; // arrange direction
            Vector2 anchor = Vector2.zero;
            switch (direction)
            {
                case Direction.Left:
                d = -1f;
                anchor = new Vector2(1f,1f);
                break;
                case Direction.Right:                
                d = 1f;
                anchor = new Vector2(0f,1f);

                break;
                default:
                d = 0f;
                break;
            }

            for (int i = 0; i < statusContainer.Count; i++)
            {
                float rowId = Mathf.Floor((float)i / (float)columnCount);
                float colId = Mathf.Floor(((float)i % (float)columnCount));
                statusContainer[i].GetComponent<RectTransform>().anchorMin = anchor;
                statusContainer[i].GetComponent<RectTransform>().anchorMax = anchor;
                statusContainer[i].GetComponent<RectTransform>().pivot = anchor;
                statusContainer[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(colId * d, rowId * -1f) * iconGap;
            }
        }

        public void ManageGameEvent(string type, float value){
            
            switch(type){
                case GameEvent.GAME_START_END:
                case GameEvent.TURN_READY_END:
                case GameEvent.TURN_CALCULATE_END:
                // Debug.Log("Status Manager : ManageGame Event !");
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
        public TempStatusToken(GameTerms.TokenType t, int v){
            tokenType = t;
            tokenValue = v;
        }      
        
    }
    public class TempStatusTokenCompare : IEqualityComparer<TempStatusToken>
    {
        public bool Equals(TempStatusToken x, TempStatusToken y)
        {
            return x.tokenType == y.tokenType;
        }

        public int GetHashCode(TempStatusToken obj)
        {
            return obj.tokenType.GetHashCode();
        }
    }
}