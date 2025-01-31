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

        //User Input
        public const string MOTION_SELECTED = "MotionSelected";
        public const string MOTION_INSPECT = "MotionInspect";
        
        //UI
        //Test
        public const string TEST_WHEEL_ENABLE = "TestWheelEnable";
        public const string TEST_WHEEL_DISABLE = "TestWheelDisable";
        public const string TEST_POWERINFO_TOGGLE_BP = "TestPowerInfoToggleBP";
        public const string TEST_POWERINFO_TOGGLE_OPEN = "TestPowerInfoToggleOPEN";
        public const string TEST_UPDATE_TUNR = "TestUpdateTurn";
        public const string TEST_ADD_HISTORY_SWORD = "TestAddhistorySword";
        
        private List<GameEventListener> listeners = new List<GameEventListener>();
        public void RegisterListener(GameEventListener listener){
            listeners.Add(listener);
        }
        public void UnregisterListener(GameEventListener listener){
            listeners.Remove(listener);
        }
        
        public void Raise(string s, int v1){
            
            for (int i = listeners.Count - 1 ; i >= 0; --i)
            {
                listeners[i].RaiseEvent(s, v1, 0);
            }
            
        }
        
        public void Raise(string s){
            
            for (int i = listeners.Count - 1 ; i >= 0; --i)
            {
                listeners[i].RaiseEvent(s, 0, 0);
            }
            
        }
        
        
    }
}