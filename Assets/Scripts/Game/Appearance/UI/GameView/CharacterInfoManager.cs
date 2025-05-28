using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;

namespace ssm.game.appearance{
    public class CharacterInfoManager : MonoBehaviour
    {
        public int characterID = 0;
        public GaugeManager hp;
        public GaugeManager ep;
        public HistoryManager history;
        public StatusManager status;
        private Character character;

        // Start is called before the first frame update
        public void Start()
        {
            character = GameBoard.Instance().FindCharacter(characterID);
            // hp.SetGauge(0f);
            // ep.SetGauge(0f);
        }

        private void UpdateHP()
        {
            float hpVal = character.GetLastPlayData().Find(GameTerms.TokenType.HPCurrent).value0;
            hp.SetValue(hpVal);
        }
        private void UpdateEP(){
            float epVal = character.GetLastPlayData().Find(GameTerms.TokenType.EPCurrent).value0;
            ep.SetValue(epVal);
        }
        private void UpdateHistory(){

        }
        private void UpdateStatus()
        {
            
        }
        public void ManageGameEvent(string type, float value){
            switch(type){
                case GameEvent.GAME_START_END:
                UpdateHP();
                UpdateEP();
                break;
                case GameEvent.TURN_READY_END:
                UpdateHP();
                UpdateEP();
                UpdateStatus();
                break;
                case GameEvent.TURN_CALCULATE_END:
                UpdateHP();
                UpdateEP();
                UpdateHistory();
                UpdateStatus();
                break;
            }

        }
    }
}