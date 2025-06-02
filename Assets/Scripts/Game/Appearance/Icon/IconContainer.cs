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
        public Icon FindIcon(GameTerms.TokenType t){
            Icon returnVal = container.Find(x => x.type==t);
            if (returnVal != null)
            {
                // Debug.Log("IconContainer.FindIcon : Icon "+returnVal)
                return returnVal;   
            }
            else
            {
                return new Icon();
            }
            
        }
    }
    [Serializable]
    public class Icon{
        
        public GameTerms.TokenType type;
        public string name;
        public int id;
        [TextArea]
        public string explanation;
        public Sprite image;
    }
}