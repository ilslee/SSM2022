using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace ssm.game.appearance{
    public class IconManager : MonoBehaviour
    {
        public IconContainer icons;
        private Image image;
        public Icon.IconType iconType;
        // public int duration;
        public GameTerms.Layout layout = GameTerms.Layout.None;

        private TMP_Text textField;
        
        private void Start() {
            image = gameObject.GetComponent<Image>();
            SetTransparent(false);
        }
        public void SetIcon(Icon.IconType t){
            Icon ic = icons.container.Find(x => x.type==t);
            if(ic == null)ic = icons.container.Find(x => x.type==Icon.IconType.None); // 어셋이 제작되지 않은 아이콘 호출 시..
            else iconType = t;
            image.sprite = ic.image;
        }
        
        public void SetIcon(int num){
            Icon ic = icons.container.Find(x => x.id==num);
            if(ic == null)ic = icons.container.Find(x => x.type==Icon.IconType.None); // 어셋이 제작되지 않은 아이콘 호출 시..
            else iconType = ic.type;
            image.sprite = ic.image;
        }

        public void SetTransparent(bool b){
            if(b == true) image.color = new Color(1f, 1f, 1f, .5f);
            else image.color = new Color(1f, 1f, 1f, .1f); 
        }
        public void SetSize(float s){
            gameObject.GetComponent<RectTransform>().sizeDelta = Vector2.one * s;
        }
    }
}