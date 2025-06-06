using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using ssm.game.structure.token;
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
        private void Initialize()
        {
            character = GameBoard.Instance().FindCharacter(characterID);
            Debug.Log("CharacterInfoManager.Start : " + character);
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
            history.AddHistory(GameBoard.Instance().FindCharacter(characterID).GetLastPlayData().motion);
        }
        private void UpdateStatus()
        {
            PlayData currentPlayData = GameBoard.Instance().FindCharacter(characterID).GetLastPlayData();
            TokenList staticData = GameBoard.Instance().FindCharacter(characterID).staticTokens;
            TokenList tempData = new TokenList();
            foreach (GameToken pd in currentPlayData)
            {
                if(pd.isDisplayed == true) tempData.Add(pd);
            }
            foreach (GameToken sd in staticData)
            {
                if(sd.isDisplayed == true) tempData.Add(sd);
            }
            status.UpdateAllStatus(tempData);
        }
        public void ManageGameEvent(string type, float value){
            switch(type){
                case GameEvent.GAME_START_END:
                Initialize();
                UpdateHP();
                UpdateEP();
                UpdateStatus();
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