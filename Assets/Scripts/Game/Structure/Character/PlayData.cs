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
        
        public TokenList token;
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
            
            token = new TokenList();            
            
            
        }
        
        public override string ToString()
        {
            string toStr = motion.ToString();
            toStr += "\n token : ";
            toStr += token.ToString();
            
            return toStr;
        }

        public void InheritGameToken(TokenList from){
            foreach(Token t in from){
                switch(t.type){
                    case GameTerms.TokenType.HPCurrent:
                    case GameTerms.TokenType.EPCurrent:
                    token.Combine(t);
                    break;
                }
            }
        }
    }
}
