using System.Collections;
using System.Collections.Generic;
using ssm.game.appearance;
using UnityEngine;
namespace ssm.ui{
    public class UIAnimationToken
    {
        //public enum AnimationType{None, Posiion, Rotation, Scale}
        // public AnimationType animationTokenType = AnimationType.None;
        
        public RectTransform target;
        private AnimationCurve curve;
        private float timer = 0f;
        private float duration = 0f;
        // private Vector3 start;
        // private Vector3 destination;
        

        public UIAnimationToken(RectTransform t, float d, AnimationCurve c){
                this.target = t;
                timer = 0;
                duration = d;
                curve = c;
                //자식 클래스의 생성자에서 start/end 지점 설정할 것
        }
        public void CalculateAnimation(){
            float curveRatio = 0f;
            if(timer > duration) timer = duration;
            if(duration == 0f)curveRatio = 1f;            
            else curveRatio = timer / duration ;
            float curvedProgress = curve.Evaluate(curveRatio);
            ApplyAnimation(curvedProgress);
            
            timer += Time.deltaTime;
        }
        internal virtual void ApplyAnimation(float curveVal){}
        internal virtual void OnAnimationFinished(){}
        public bool isAnimationFinished(){
            if(timer > duration)return true;
            else return false;
        }
       
    }

    public class UIAnimationSizeDelta : UIAnimationToken{
        private Vector2 start;
        private Vector2 end;
        public UIAnimationSizeDelta(RectTransform t, Vector2 e, float d, AnimationCurve c) : base(t,d,c){
            SetStartEndPoints(e);
        }

        private void SetStartEndPoints(Vector2 e){
            start = new Vector2(target.sizeDelta.x, target.sizeDelta.y);
            end = new Vector2(e.x, e.y);
        }
        internal override void ApplyAnimation(float curveVal){
            Vector2 transformValue = Vector2.LerpUnclamped(start, end, curveVal);
            target.sizeDelta = transformValue;
        }
    }   


    public class UIAnimationPosition : UIAnimationToken{
        private Vector2 start;
        private Vector2 end;
        public UIAnimationPosition(RectTransform t, Vector2 e, float d, AnimationCurve c) : base(t,d,c){
            SetStartEndPoints(e);
        }

        private void SetStartEndPoints(Vector2 e){
            start = new Vector2(target.anchoredPosition.x, target.anchoredPosition.y);
            end = new Vector2(e.x, e.y);
        }
        internal override void ApplyAnimation(float curveVal){
            Vector2 transformValue = Vector2.LerpUnclamped(start, end, curveVal);
            target.anchoredPosition = transformValue;
        }
    }   



    public class UIAnimationScale : UIAnimationToken{
        private Vector3 start;
        private Vector3 end;
        public UIAnimationScale(RectTransform t, float e, float d, AnimationCurve c) : base(t,d,c){
            SetStartEndPoints(e);
        }

        private void SetStartEndPoints(float e){
            start = Vector3.one * target.localScale.x;
            end = Vector3.one * e;
        }
        internal override void ApplyAnimation(float curveVal){
            Vector3 transformValue = Vector3.LerpUnclamped(start, end, curveVal);
            target.localScale = transformValue;
        }
    }   

    public class UIAnimationGauge : UIAnimationToken{
        private float start;
        private float end;
        public UIAnimationGauge(RectTransform t, float s, float e, float d, AnimationCurve c) : base(t,d,c){
            start = s;
            end = e;
        }    
        internal override void ApplyAnimation(float curveVal){
            GaugeManager gauge = target.gameObject.GetComponent<GaugeManager>();
            float value = Mathf.LerpUnclamped(start, end, curveVal);
            gauge.UpdateGauge(value);
        }
    }  
}
