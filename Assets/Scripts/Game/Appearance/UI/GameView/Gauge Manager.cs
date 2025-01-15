using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace ssm.game.appearance{
    public class GaugeManager : MonoBehaviour
    {
        private int gaugeLength = 10;
        public Color gaugeBGColor; 
        public List<Color> gaugeColor;
        public List<Image> gauge;
        public TMP_Text number;
        public UIAnimationManager anim;

        public void Start(){
            SetGauge(13f);
        }
        public void SetGauge(float v){
            if(gauge.Count < gaugeLength || gaugeColor.Count < gaugeLength){
                Debug.LogError("GaugeManager.SetGauge : Not enough gauge length or color variation");
                return;
            }
            int gaugeValue = (int)Mathf.Round(v);
            int gaugeGroupID = (int)Mathf.Floor(v * 0.1f); //십 단위로 분리
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
        
    }
         
}
