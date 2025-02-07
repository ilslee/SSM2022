using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
namespace ssm.game.appearance{
    
    [CreateAssetMenu(fileName = "NewIconContainer", menuName = "SSM/IconContainer")]
    public class IconContainer : ScriptableObject
    {
        public List<Icon> container;
        public void Reset(){
            container = new List<Icon>();
        }
    }
    [Serializable]
    public class Icon{
        public enum IconType{   None, Question, HP, EP, History, Status, 
                                Attack, Strike, Defence, Charge, Rest, Avoid}
        public IconType type;
        public string name;
        public int id;
        [TextArea]
        public string explanation;
        public Sprite image;
    }
}