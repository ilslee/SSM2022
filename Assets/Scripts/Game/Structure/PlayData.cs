using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

namespace ssm.game.structure{
    
    //턴 데이터를 저장하기 위한 클래스
    public class PlayData{
        
        public GameTerms.Motion motion;
        //충돌 여부
        public bool collision;
        
        public GameTokenList token;
        // public StatTokenList[] expectation;
        
        public PlayData(){
            Reset();
        }

        // public PlayData CloneLast(){            
        //     return new PlayData(statEnd, bpIndex);
        // }
        public void Reset(){
            motion = GameTerms.Motion.None;
            collision = false;
            
            token = new GameTokenList();            
            
            
        }
        
        public override string ToString()
        {
            string toStr = motion.ToString();
            toStr += "\n token : ";
            toStr += token.ToString();
            
            return toStr;
        }

        public void InheritGameToken(GameTokenList from){
            foreach(GameToken t in from){
                switch(t.type){
                    case GameTerms.TokenType.Health:
                    case GameTerms.TokenType.Energy:
                    token.Combine(t);
                    break;
                }
            }
        }
    }
}
