using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace ssm.game.structure{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        public GameEventResponser response;
        
        [System.Serializable]
        public class GameEventResponser : UnityEvent<string, float>
        {
            private string type;
            private string id;
            private string val;

            public string EventType {
                get{
                    return type;
                }
            }
            public string EventIndex {
                get{
                    return id;
                }
            }
            public string EventValue {
                get{
                    return val;
                }
            }
        }


    private void OnEnable(){
        gameEvent.RegisterListener(this);
    }
    private void OnDisable(){
        gameEvent.UnregisterListener(this);
    }
    public void RaiseEvent(string s, float v){
        response.Invoke(s,v);
    }
        
    }
}