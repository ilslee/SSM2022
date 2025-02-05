using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;
using UnityEngine.UIElements;
namespace ssm.game.appearance{
    public class PowerInfoManager : MonoBehaviour
    {
        public UIAnimationManager anim;
        public bool displayBPToggle = false;
        public RectTransform bpGroup;
        public RectTransform powerGroup;
        public RectTransform background;

        private float bpGroupHeight = 72f;
        private float powerGroupHeight = 200f;
        private float marginY = 16f;
            
        private float powerAnimationEndY;
        private float bgAnimationStartY;
        private float bgAnimationEndY;
        
        
        //Test
        private bool openCloseToggle = false;
        public void Start(){
            powerAnimationEndY = powerGroup.sizeDelta.y;
            SetLayout();
        }

        private void SetLayout(){
            float backgroundHeight = 0f;
            float bpGroupPosY = 0f;
            float powerGroupPosY = 0f;
            /*
            if(displayBPToggle == true){
                bpGroup.gameObject.SetActive(true);
                backgroundHeight = marginY + bpGroupHeight + marginY + marginY + powerGroupHeight + marginY;
                bpGroupPosY = marginY * -1f;
                powerGroupPosY = (marginY + bpGroupHeight + marginY) * -1f;
                bgAnimationStartY = marginY + bpGroupHeight + marginY;
                bgAnimationEndY = backgroundHeight;
                // background.sizeDelta = new Vector2(background.sizeDelta.x, );
            }else{
                bpGroup.gameObject.SetActive(false);
                backgroundHeight = marginY + powerGroupHeight + marginY;
                powerGroupPosY = marginY * -1f;
                bgAnimationStartY = 0f;
                bgAnimationEndY = backgroundHeight;
            }
            if(displayBPToggle == true) bpGroup.anchoredPosition = new Vector2(bpGroup.anchoredPosition.x, bpGroupPosY);
            */
            powerGroup.anchoredPosition = new Vector2(powerGroup.anchoredPosition.x, powerGroupPosY);
            background.sizeDelta = new Vector2(background.sizeDelta.x, backgroundHeight);
        }
        private void Open(){
            // anim.AddAnimation(new UIAnimationSizeDelta(GetIconViaWheelID(activatedWheelID), UIAnimationToken.AnimationType.Scale, scaleActivated, 0.3f, anim.acc.GetCurve(AnimationCurveContainer.Type.FastRebound1) ));
            Vector2 backgroundEnd = new Vector2(background.sizeDelta.x, bgAnimationEndY);
            Vector2 powerEnd = new Vector2(powerGroup.sizeDelta.x, powerAnimationEndY);
            anim.AddAnimation(new UIAnimationSizeDelta(background, backgroundEnd, 0.3f, anim.acc.fastsmooth1));
            anim.AddAnimation(new UIAnimationSizeDelta(powerGroup, powerEnd, 0.28f, anim.acc.fastsmooth1));
        }
        private void Close(){
            Vector2 backgroundEnd = new Vector2(background.sizeDelta.x, bgAnimationStartY);
            Vector2 powerEnd = new Vector2(powerGroup.sizeDelta.x, 0f);
            anim.AddAnimation(new UIAnimationSizeDelta(background, backgroundEnd, 0.3f, anim.acc.fastsmooth1));
            anim.AddAnimation(new UIAnimationSizeDelta(powerGroup, powerEnd, 0.28f, anim.acc.fastsmooth1));
        }
        
        public void ManageGameEvent(string type, float value){
            
            switch(type){
                case GameEvent.TEST_POWERINFO_TOGGLE_BP:
                displayBPToggle = (displayBPToggle == true) ?  false : true;
                SetLayout();
                break;
                case GameEvent.TEST_POWERINFO_TOGGLE_OPEN:
                openCloseToggle = (openCloseToggle == true) ?  false : true;
                if(openCloseToggle == true) Open();
                else Close();
                break;
                
            }
        }
    }
}