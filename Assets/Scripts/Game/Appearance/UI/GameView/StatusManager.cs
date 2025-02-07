using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.appearance{
    public class StatusManager : MonoBehaviour
    {
        public int columnCount = 5;
        public enum Direction {None, Left, Right}
        public Direction direction;
        public IconManager icon;
        private float iconGap = 50f;
        private List<IconManager> statusContainer;
        public UIAnimationManager anim;
       
        public void AddStatus(){
            statusContainer.Add(Instantiate(icon, this.transform));
            RearangeAllStatus();
        }

        public void RemoveStatus(Icon.IconType t){
            IconManager removingIcon = statusContainer.Find(x => x.iconType == t);
            RearangeAllStatus();
        }
        
        //시간 표시 등 업데이트 - 짧게 확대-축소되는 애니메이션 재생
        public void UpdateAllStatus(){
            
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

    }
}