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
        // public Icon.IconType iconType;
        public GameTerms.TokenType tokenType; // 어떤 데이터에 기반해서 만들어졌는지 기록되어야 함
        // public int duration;
        public GameTerms.Layout layout = GameTerms.Layout.None;

        private TMP_Text textField;
        private RectTransform newIcon;
        private float defaultSize;
        private float defaultTextfieldFontSize;
        private float defaultTextfieldWidth;
        private float defaultTextfieldHeight;
        private float defaultNewSize;
        
        
        private void OnEnable() {
            //Init Layout
            defaultSize = gameObject.GetComponent<RectTransform>().sizeDelta.x; // 128
            textField = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
            Debug.Log("textField ? " + textField);
            defaultTextfieldWidth = textField.GetComponent<RectTransform>().sizeDelta.x;
            defaultTextfieldHeight = textField.GetComponent<RectTransform>().sizeDelta.y;
            defaultTextfieldFontSize = textField.fontSize;
            newIcon = gameObject.transform.GetChild(1).GetComponent<RectTransform>();
            defaultNewSize = newIcon.sizeDelta.x;

            image = gameObject.GetComponent<Image>();
            
            SetTransparent(false);
            SetNewIcon(false);
        }
        public void SetIcon(GameTerms.TokenType t =  GameTerms.TokenType.None){
            Icon ic = icons.container.Find(x => x.type==t);
            if(ic == null)ic = icons.container.Find(x => x.type==GameTerms.TokenType.None); // 어셋이 제작되지 않은 아이콘 호출 시..            
            image.sprite = ic.image;            
        }
        /*
        public void SetIcon(int num){
            Icon ic = icons.container.Find(x => x.id==num);
            if(ic == null)ic = icons.container.Find(x => x.type==Icon.IconType.None); // 어셋이 제작되지 않은 아이콘 호출 시..
            else iconType = ic.type;
            image.sprite = ic.image;
        }
        */
        public void SetTransparent(bool b){
            if(b == true) image.color = new Color(1f, 1f, 1f, .5f);
            else image.color = new Color(1f, 1f, 1f, 1f); 
        }
        public void SetSize(float s){
            gameObject.GetComponent<RectTransform>().sizeDelta = Vector2.one * s;

            float sizeRatio = s / defaultSize;
            textField.fontSize = Mathf.Floor(defaultTextfieldFontSize * sizeRatio);            
            textField.GetComponent<RectTransform>().sizeDelta = new Vector2(defaultTextfieldWidth, defaultTextfieldHeight) * sizeRatio;

            newIcon.sizeDelta =  Vector2.one * defaultNewSize * sizeRatio;
        }
        public void SetNewIcon(bool newIconStatus){
            if(newIconStatus == true) newIcon.GetComponent<Image>().enabled = true;
            else newIcon.GetComponent<Image>().enabled = false;
        }
        public void SetValue(int value){
            textField.text = value.ToString();
        }
    }
}