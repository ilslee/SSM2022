using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ssm.data{
    [System.Serializable]
    public class Character : ScriptableObject
    {
        public string characterName;
        public virtual void Reset(){
            characterName = "No Name";
        }
        /*
        public Character(){
            name = "No Name";
        }
        */
    }
}