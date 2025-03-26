using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ssm.game.structure;
using ssm.ui;
using Unity.Mathematics;
using System;
namespace ssm.game.appearance{
    public class GaugeManager : MonoBehaviour
    {
        public int characterIndex = 0;
        private int gaugeLength = 10;
        public Color gaugeBGColor; 
        public List<Color> gaugeColor;
        public List<Image> gauge;
        public TMP_Text number;
        public UIAnimationManager anim;
        // private float gaugeValue = 0f;
        private int maxValue = 99; // exceeding value will display as this number
        public void Start(){
            UpdateGauge(0f);
            // SetGauge(13f);
        }
        public void UpdateGauge(float v){
            if(gauge.Count < gaugeLength || gaugeColor.Count < gaugeLength){
                Debug.LogError("GaugeManager.SetGauge : Not enough gauge length or color variation");
                return;
            }
            float value = MathF.Min(v, maxValue);// 최대 표기 숫자 제한..레이아웃 맞추기 위해
            int gaugeValue = (int)Mathf.Round(value);
            int gaugeGroupID = (int)Mathf.Floor(value * 0.1f); //십 단위로 분리
            // Debug.Log("GaugeManager.UpdateGauge : gaugeGroupID is " + gaugeGroupID.ToString() );
            int gaugeFillcount = gaugeValue % 10 == 0 ? 10 : gaugeValue % 10; // 일 단위만 추출(1~10)
            if(gaugeValue <= 0) gaugeFillcount = 0;
            //set gauge color
            Color fillColor = gaugeColor[gaugeGroupID];
            fillColor.a = 1f;
            //set gauge bg color
            Color bgColor = gaugeGroupID -1 >= 0 ? gaugeColor[gaugeGroupID-1] : gaugeBGColor;
            bgColor.a = .5f;

            for(int i = 0; i < gaugeLength; i++) 
            {
                if(i < gaugeFillcount){
                    gauge[i].color = fillColor;
                }else{
                    gauge[i].color = bgColor;
                }
            }

            number.text = gaugeValue.ToString();
        }
        
        public void SetValue(){
            if(characterIndex == 0) {
                Debug.LogError("GaugeManager.SetValue : No valid Character Index");
                return;
            }
            float startValue = float.Parse(number.text);
            float endValue = GetValveFromData();
            if(startValue == endValue)return;
            else anim.AddAnimation(new UIAnimationGauge(gameObject.GetComponent<RectTransform>(), startValue, endValue, 10f, anim.acc.fastsmooth1));
        }
        internal virtual float GetValveFromData(){
            return 0f;
        }
        public void ManageGameEvent(string type, float value){
            
            switch(type){
                case GameEvent.GAME_START_END:
                case GameEvent.TURN_READY_END:
                case GameEvent.TURN_CALCULATE_END:
                // Debug.Log("Status Manager : ManageGame Event !");
                SetValue();
                break;
            }
        }
    }
         
}
