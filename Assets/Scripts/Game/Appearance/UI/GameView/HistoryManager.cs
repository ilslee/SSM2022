using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using ssm.game.structure;
using ssm.ui;
// using System.Numerics;
using UnityEngine;
namespace ssm.game.appearance{
    public class HistoryManager : MonoBehaviour
    {
        // public int charcterIndex = 0;
        public enum Direction {None, Left, Right}
        public Direction direction;
        private float animationDirection;
        private int historyCount = 5;
        private float iconGap = 50f; // 각 아이콘 사이 간격
        // Start is called before the first frame update
        private int id = 0;
        public UIAnimationManager anim;
        // public IconManager icon;
        public IconContainer iconContainer;
        public HistoryIconManager icon;
        private List<Image> icons;
        private RectTransform container;
        public void Start()
        {            
            
            switch (direction)
            {
                case Direction.Left:
                animationDirection = -1f;
                break;
                case Direction.Right:
                animationDirection = 1f;
                break;
                default:
                animationDirection = 0f;
                break;
            }

            //Icon생성
            container = gameObject.transform.GetChild(0).GetComponent<RectTransform>();
            icons = new List<Image>();
            for (int i = 0; i < historyCount+1; i++) // 추가 여분 1개 더 만듦
            {
                // HistoryIconManager ic = Instantiate(icon,container.transform );
                Image ic = new Image();
                switch (direction){
                    case Direction.Left:
                    GameTool.SetUIItemLayout(ic.GetComponent<RectTransform>(),GameTool.Direction.Left, GameTool.Direction.Top);
                    break;
                    case Direction.Right:
                    GameTool.SetUIItemLayout(ic.GetComponent<RectTransform>(),GameTool.Direction.Right, GameTool.Direction.Top);
                    break;
                }
                ic.SetSize(iconGap-2f);
                icons.Add(ic);                
            }
            //RectTransform을 통한 마스크 크기 조절(개수를 나중에 다르게 설정한다면..)
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(iconGap * (float)historyCount, iconGap);
            RearrangeIcons();
            
        }
        private void RearrangeIcons(){
            container.anchoredPosition = Vector2.right * animationDirection * (float)id * iconGap;
            

            for (int i = 0; i < icons.Count; i++) 
            {
                float pageId = Mathf.Floor((float)id / (float)icons.Count) * (float)icons.Count;
                float positionId = pageId + (float) i;
                if(positionId > id) positionId -= (float)icons.Count;
                if(positionId < 0) positionId += (float)icons.Count;
                float position = positionId * animationDirection * iconGap;
                // Debug.Log("Page is "+ pageId + " / Icon " + i +" to " + positionId);
                icons[i].GetComponent<RectTransform>().anchoredPosition = Vector2.left * position;
                
                
            }

        }
        public void AddHistory(GameTerms.Motion m){
            //시작 전 재정렬
            RearrangeIcons();
            id ++;
            Vector2 destPos = Vector2.right * ((float)id * iconGap * animationDirection);
            //아이콘을 세팅
            int iconId = id % icons.Count;
            icons[iconId].sprite = SetIconImageViaMotion(m);
            //컨테이너 밀기
            anim.AddAnimation(new UIAnimationPosition(container, destPos, 0.5f, anim.acc.fastsmooth1));
            //끝나면 재정렬
            
            Sprite SetIconImageViaMotion(GameTerms.Motion m){

                switch(m){
                    case GameTerms.Motion.Attack:
                    return iconContainer.FindIcon(GameTerms.TokenType.AttackAction).image;
                    case GameTerms.Motion.Strike:
                    return iconContainer.FindIcon(GameTerms.TokenType.StrikeAction).image;
                    case GameTerms.Motion.Defence:
                    return iconContainer.FindIcon(GameTerms.TokenType.DefenceAction).image;
                    case GameTerms.Motion.Charge:
                    return iconContainer.FindIcon(GameTerms.TokenType.ChargeAction).image;
                    case GameTerms.Motion.Rest:
                    return iconContainer.FindIcon(GameTerms.TokenType.RestAction).image;
                    case GameTerms.Motion.Avoid:
                    return iconContainer.FindIcon(GameTerms.TokenType.AvoidAction).image;
                }
                return iconContainer.FindIcon(GameTerms.TokenType.None).image;
            }
        }
        /*
        public void ManageGameEvent(string type, float value){
            switch(type){
                case GameEvent.TEST_ADD_HISTORY_SWORD:
                case GameEvent.TURN_CALCULATE:
                AddHistory();
                break;
            }
        }
        */
    }
}