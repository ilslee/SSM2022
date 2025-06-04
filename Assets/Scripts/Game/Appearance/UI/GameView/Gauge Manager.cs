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
        public enum GaugeType {None, HP, EP}
        public GaugeType gaugeType = GaugeType.None;
        public int characterIndex = 0;
        private int gaugeLength = 10;
        public Color gaugeBGColor; 
        public List<Color> gaugeColor;
        public List<Image> gauge;
        public TMP_Text number;
        public UIAnimationManager anim;
        // private float gaugeValue = 0f;
        private int maxValue = 99; // exceeding value will display as this number
        private void Initialize()
        {
            //Set Gauge Colors
            gaugeColor = new List<Color>(10);
            Color col00 = new Color(1f,     0f,     0f,1f);
            Color col01 = new Color(1f,     .5f,    0f,1f);
            Color col02 = new Color(1f,     1f,     0f,1f);
            Color col03 = new Color(0f,     1f,    0f,1f);
            Color col04 = new Color(0f,     .6f,    .3f,1f);
            Color col05 = new Color(0f,     .5f,   1f,1f);
            Color col06 = new Color(.2f,    .2f,     1f,1f);
            Color col07 = new Color(.6f,    0f,     1f,1f);
            Color col08 = new Color(1f,     0f,     1f,1f);
            Color col09 = new Color(1f,     0f,     .5f,1f);
            gaugeColor.Add(col00);
            gaugeColor.Add(col01);
            gaugeColor.Add(col02);
            gaugeColor.Add(col03);
            gaugeColor.Add(col04);
            gaugeColor.Add(col05);
            gaugeColor.Add(col06);
            gaugeColor.Add(col07);
            gaugeColor.Add(col08);
            gaugeColor.Add(col09);

            gaugeBGColor = new Color(0f, 0f, 0f, 1f);

            //Put gauge Icons to List
            gauge = new List<Image>(gaugeLength);
            for(int i = 0; i<gaugeLength; i++){
                gauge.Add(this.transform.GetChild(i).GetComponent<Image>());
            }

            //Set Text 
            number.text = "00";
            
        }
        public void Start()
        {
            Initialize();
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
        
        public void SetValue(float v){
             float startValue = float.Parse(number.text);
            // float endValue = GetValveFromData();
            float endValue = v;
            if(startValue == endValue)return;
            else anim.AddAnimation(new UIAnimationGauge(gameObject.GetComponent<RectTransform>(), startValue, endValue, .5f, anim.acc.fastsmooth1));

            //Set Text
            if (v < 10)
            {
                number.text = "0" + v.ToString();
            }
            else if (v > maxValue)
            {
                number.text = maxValue.ToString();
            }
            else
            {
                number.text = v.ToString();
            }
        }
        
    }
         
}
