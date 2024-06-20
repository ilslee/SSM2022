using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ssm.game.structure{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "SSM/Event/Game")]
    public class GameEvent : ScriptableObject
    {
        
        public const string START_PHASE_OVER = "StartPhaseOver";
        public const string READY_PHASE_OVER = "ReadyPhaseOver";
        public const string POSE_PHASE_OVER = "PosePhaseOver";
        public const string MOTION_PHASE_OVER = "MotionPhaseOver";
        public const string CALCULATIION_PHASE_OVER = "CalculateMEPhaseOver";
        public const string BEHAVIOUR_PHASE_OVER = "BehaviourPhaseOver";
        // public const string DIRECTION_PHASE_OVER = "DirectionPhaseOver";
        public const string RESULT_PHASE_OVER = "ResultPhaseOver";
        public const string FINISH_PHASE_OVER = "FinishPhaseOver";
        public const string START_FINISH_PHASE = "FinishPhaseOver";
        public const string TURN_START = "TurnStart";
        public const string GAME_START = "GameStart";
        public const string GAME_END = "GameEnd";
        
        
        private List<GameEventListener> listeners = new List<GameEventListener>();
        public void RegisterListener(GameEventListener listener){
            listeners.Add(listener);
        }
        public void UnregisterListener(GameEventListener listener){
            listeners.Remove(listener);
        }
        /*
        public void Raise(string s, string v){
            
            for (int i = listeners.Count - 1 ; i >= 0; --i)
            {
                listeners[i].RaiseEvent(s, v);
            }
            
        }
        */
        public void Raise(string s){
            
            for (int i = listeners.Count - 1 ; i >= 0; --i)
            {
                listeners[i].RaiseEvent(s, 0, 0);
            }
            
        }
        /*
        public void Raise(string s, Scoreboard.Phase p){
            string v = "";
            foreach(KeyValuePair<string, Scoreboard.Phase> pDic in phaseDic){
                if(pDic.Value == p) {
                    v = pDic.Key;
                    break;
                }
            }
            for (int i = listeners.Count - 1 ; i >= 0; --i)
            {
                listeners[i].RaiseEvent(s, v);
            }
        }
        
        public static Scoreboard.Phase StringToPhase(string s){
            return phaseDic[s];
        }
        */
    }
}