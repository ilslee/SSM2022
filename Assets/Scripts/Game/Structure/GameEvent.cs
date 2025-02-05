using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ssm.game.structure{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "SSM/Event/Game")]
    public class GameEvent : ScriptableObject
    {
        public const string GAME_START_START = "GameStartStart";
        public const string GAME_START = "GameStart";
        public const string GAME_START_END = "GameStartEnd";
        public const string TRANSITION_ENTER_START = "TransitionEnterStart";
        public const string TRANSITION_ENTER = "TransitionEnter";
        public const string TRANSITION_ENTER_END = "TransitioinEnterEnd";
        public const string COUNTDOWN_START = "CountdownStart";
        public const string COUNTDOWN = "Countdown";
        public const string COUNTDOWN_END = "CountdownEnd";
        public const string TURN_READY_START = "TurnReadyStart";
        public const string TURN_READY = "TurnReady";
        public const string TURN_READY_END = "TurnReadyEnd";
        public const string TURN_CALCULATE_START = "TurnCalculateStart";
        public const string TURN_CALCULATE = "TurnCalculate";
        public const string TURN_CALCULATE_END = "TurnCalculateEnd";
        public const string ANIMATION_CALC1 = "AnimationCalc1";
        public const string ANIMATION_CALC2 = "AnimationCalc2";
        public const string ANIMATION_END1 = "AnimationEnd1";
        public const string ANIMATION_END2 = "AnimationEnd2";
        public const string GAME_END_START = "GameEndStart";
        public const string GAME_END = "GameEnd";
        public const string GAME_END_END = "GameEndEnd";
        public const string TRANSITION_EXIT_START = "TransitionExitStart";
        public const string TRANSITION_EXIT = "TransitionExit";
        public const string TRANSITION_EXIT_END = "TransitionExitEnd";

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
        
        public void Raise(string s, float v){
            
            for (int i = listeners.Count - 1 ; i >= 0; --i)
            {
                listeners[i].RaiseEvent(s, v);
            }
            
        }
        
        public void Raise(string s){
            
            for (int i = listeners.Count - 1 ; i >= 0; --i)
            {
                listeners[i].RaiseEvent(s, 0f);
            }
            
        }
        
        
    }
}