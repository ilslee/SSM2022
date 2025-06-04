using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ssm.game.structure;
using ssm.game.structure.token;
using System.Linq;
using System;
using ssm.ui;
using TMPro;
namespace ssm.game.appearance
{
    public class StatusManager : MonoBehaviour
    {
        public int characterIndex = 0;
        public int columnCount = 5;
        public enum Direction { None, Left, Right }
        public Direction direction;
        public IconContainer iconContainer;
        private float iconGap = 50f;
        public StatusIcon icon;
        private List<StatusIcon> statusContainer;        
        public UIAnimationManager anim;
        // private List<StatusTestData> statusTestData;
        private void Start()
        {
            statusContainer = new List<StatusIcon>();
            
            Initialize();
        }
        private void Initialize()
        {
            
        }
        private void AddStatus(GameTerms.TokenType t, int v = -1)
        {

            StatusIcon newStatus = Instantiate(icon, this.transform);
            newStatus.InitIcon(t, iconContainer.FindIcon(t).image, v);
            statusContainer.Add(newStatus);

            RearangeAllStatus();
            //TODO : 아이콘의 액티베이션 여부에 따른 생성 시 애니메이션 분기 지정 250604
            newStatus.UpdateNumber();
        }

        private void RemoveStatus(GameTerms.TokenType t)
        {
            int removingID = statusContainer.FindIndex(x => x.type == t);
            if (removingID == -1) return;
            Destroy(statusContainer[removingID]);
            statusContainer.RemoveAt(removingID);
            RearangeAllStatus();
        }
        private void UpdateStatus(GameTerms.TokenType t, int v = -1)
        {
            StatusIcon updatingIcon = statusContainer.Find(x => x.type == t);
            if (updatingIcon == null) return;
            // updatingIcon.SetValue(v);

        }
        //시간 표시 등 업데이트 - 짧게 확대-축소되는 애니메이션 재생
        public void UpdateAllStatus(TokenList data)
        {

            //List<TempStatusToken>를 만들어 타입과 번호 저장하여 실체 스태터스와 비교
            List<StatusIcon> tempStatusIcon = new List<StatusIcon>();
            foreach (GameToken st in data)
            {
                // staticTokenList += "\n" + st.type.ToString() + " / disp : " + st.isDisplayed.ToString();
                if (st.isDisplayed == false) continue; // displayed == false면 고려 대상에서 제외
                tempStatusIcon.Add(new StatusIcon(st.type, st.GetTokenValue()));
            }

            // List<TempStatusToken> status = GetStatuses();
            // List<TempStatusToken> character = GetGameTokens();
            StatusIconCompare comparer = new StatusIconCompare();
            List<StatusIcon> addToStatus = tempStatusIcon.Except(statusContainer, comparer).ToList(); // 비교 후 status에 없는 것 추가 대상
            List<StatusIcon> removeFromStatus = statusContainer.Except(tempStatusIcon, comparer).ToList(); // 비교 후 temp에 없는 것 삭제 대상
            List<StatusIcon> updateStatus = tempStatusIcon.Intersect(statusContainer, comparer).ToList(); // 비교 후 양쪽에 같이 있는 것 업데이트 대상
            string beforeStr = "< Character " + characterIndex.ToString() + " Status Update Before >";
            beforeStr += "\n---Status";
            foreach (StatusIcon s in statusContainer)
            {
                beforeStr += s.type.ToString() + " | ";
            }
            beforeStr += "\n---Character";
            foreach (StatusIcon c in tempStatusIcon)
            {
                beforeStr += c.type.ToString() + " | ";
            }
            Debug.Log(beforeStr);
            string updateStr = "< Character " + characterIndex.ToString() + " Status Update Result >";
            updateStr += "\n---ADD : ";
            foreach (StatusIcon a in addToStatus)
            {
                updateStr += a.type.ToString() +"(" + a.number.ToString() + ") | ";
                AddStatus(a.type, a.number);
            }
            updateStr += "\n---Remove : ";
            foreach (StatusIcon r in removeFromStatus)
            {
                updateStr += r.type.ToString() +"(" + r.number.ToString() + ") | ";
                RemoveStatus(r.type);
            }

            updateStr += "\n---Update : ";
            foreach (StatusIcon u in updateStatus)
            {
                updateStr += u.type.ToString() +"(" + u.number.ToString() + ") | ";
                UpdateStatus(u.type, u.number);
            }
            Debug.Log(updateStr);
            /*
            List<TempStatusToken> GetStatuses()
            {
                List<TempStatusToken> returnVal = new List<TempStatusToken>();
                foreach (IconManager i in container)
                {
                    returnVal.Add(new TempStatusToken(i.tokenType, 0));
                }
                return returnVal;
            }
            */
        }

        //List순번에 따라 아이콘 배치
        private void RearangeAllStatus()
        {
            float d = 0f; // arrange direction
            Vector2 anchor = Vector2.zero;
            switch (direction)
            {
                case Direction.Left:
                    d = -1f;
                    anchor = new Vector2(1f, 1f);
                    break;
                case Direction.Right:
                    d = 1f;
                    anchor = new Vector2(0f, 1f);

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
        /*
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
        */
    }
   /*
    public class TempStatusToken
    {
        public GameTerms.TokenType tokenType;
        public int tokenValue;
        public TempStatusToken()
        {
            tokenType = GameTerms.TokenType.None;
            // statusCount = (int)MathTool.GetRandomIntRange(1,5);
            tokenValue = -1;
        }
        public TempStatusToken(GameTerms.TokenType t, int v)
        {
            tokenType = t;
            tokenValue = v;
        }
        public static TempStatusToken Convert(GameToken t)
        {
            TempStatusToken returnVal = new TempStatusToken();
            returnVal.tokenType = t.type;
            returnVal.tokenValue = t.GetTokenValue();
            return returnVal;
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
    */
}