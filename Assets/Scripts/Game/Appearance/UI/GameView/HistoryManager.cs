using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using ssm.ui;
// using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
namespace ssm.game.appearance{
    public class HistoryManager : MonoBehaviour, IUIAnimationInterface
    {
        // public int charcterIndex = 0;
        public enum Direction { None, Left, Right }
        public Direction direction;

        private float animationDirection;
        private int historyCount = 5;
        private float iconGap = 50f; // 각 아이콘 사이 간격
        // Start is called before the first frame update
        private int positionId = 0;
        public UIAnimationManager anim;
        // public IconManager icon;
        public IconContainer iconContainer;
        private Image icon;
        private List<Image> icons;
        private RectTransform container;
        public void Start()
        {
            anim.AddInterface(this);
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
            icon = container.transform.GetChild(0).GetComponent<Image>();
            // icon.sprite = iconContainer.FindIcon(GameTerms.TokenType.None).image;
            icons = new List<Image>();
            for (int i = 0; i < historyCount; i++) 
            {
                Debug.Log(i + " / " + icon);
                Image ic = Instantiate(icon, container);
                icons.Add(ic);                            
            }
            icons.Insert(0, icon);//원본을 이용하여 1개 더 추가. List 표시를 위해 한개 더 필요함

            //RectTransform을 통한 마스크 크기 조절(개수를 나중에 다르게 설정한다면..)
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(iconGap * (float)historyCount, iconGap);
            RearrangeIcons();

        }
        private void RearrangeIcons()
        {
            container.anchoredPosition = Vector2.right * animationDirection * (float)positionId * iconGap;
            if (icons.Count == 0) {
                Debug.LogError("HistoryManager.RearrangeIcons : There is no icons to calculate.");
                return;
            }
            int tempDestId = positionId;
            for (int i = 0; i < icons.Count; i++)
            {
                float pageId = Mathf.Floor((float)(tempDestId - i) / (float)icons.Count);
                if (pageId < 0f) pageId = 0f;
                float pagePosition = (float)icons.Count * pageId;
                float localPosition = (float)i;
                float iconPosition = (pagePosition + localPosition) * iconGap * animationDirection * -1f; // 아이콘은 컨테이너 애니메이션 진행 역순으로 배치해야
                // Debug.Log("Page is "+ pageId + " / Icon " + i +" to " + positionId);
                icons[i].GetComponent<RectTransform>().anchoredPosition = Vector2.right * iconPosition;

            }

        }
        public void AddHistory(GameTerms.Motion m)
        {
            // 최외각 아이콘을 세팅
            int latestIconId = positionId % icons.Count;
            icons[latestIconId].sprite = SetIconImageViaMotion(m);
            //컨테이너 밀기
            Vector2 destPos = Vector2.right * ((float)(positionId+1) * iconGap * animationDirection);
            anim.AddAnimation(new UIAnimationPosition(container, destPos, 0.5f, anim.acc.fastsmooth1));            
            // Debug.Log("Add History : " + m.ToString() +  " / Latest ID : " + latestIconId + " / MoveContainer : " + destPos.ToString());
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
          

        //IUIAnimationInterface Interface 구현
        public void OnAnimationStart(int index)
        {
            // Debug.Log("Start Animation : " + index);
        }
        public void OnAnimationFinish(int index)
        {
            positionId++;
            RearrangeIcons(); // 애니메이션 종료 후 재정렬
            // Debug.Log("Finish Animation : " + index);
        }
        public void OnAnimationUpdate(int index, float progress)
        { 
            // Debug.Log("Update Animation : " + index + " / " + (float)positionId + progress);
        }
    }
}