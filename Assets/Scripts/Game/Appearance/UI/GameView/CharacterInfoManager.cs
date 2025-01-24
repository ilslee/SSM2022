using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.appearance{
    public class CharacterInfoManager : MonoBehaviour
    {
        public int characterID = 0;
        public GaugeManager hp;
        public GaugeManager ep;
        public HistoryManager history;
        public StatusManager status;

        // Start is called before the first frame update
        public void Start()
        {
            hp.SetGauge(0f);
            ep.SetGauge(0f);
        }

        
        
        public void ManageGameEvent(string type, int index, int value){
            switch(type){
            }
        }
    }
}