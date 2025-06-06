using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;
using ssm.game.structure.token;
namespace ssm.game.structure{
    
    //턴 데이터를 저장하기 위한 클래스
    public class PlayData : TokenList{
        
        public GameTerms.Motion motion;
        //충돌 여부
        public bool collision;
        // public TokenList token;
        // public StatTokenList[] expectation;
        
        public PlayData(int index) : base(index){
            motion = GameTerms.Motion.None;
            collision = false;
            // Reset();
        }

        // public PlayData CloneLast(){            
        //     return new PlayData(statEnd, bpIndex);
        // }
        public void Reset(){
            
        }
        
        public override string ToString()
        {
            string toStr = "[PlayData] of character " + characterIndex +"----------";
            toStr += "\n Motion : " + motion.ToString() + " / coiilsion : " + collision.ToString();
            for (int i = 0; i < this.Count; i++)
            {
                toStr += " \n token [" + i + "]: " + this[i].type.ToString() + " / " + this[i].occasion.ToString() + " / " +this[i].value0.ToString();    
            }
            
            toStr += "\n [End of PlayData] of character " + characterIndex +"----------";
            return toStr;
        }

        public void Inherit(PlayData from){
            foreach (GameToken t in from)
            {
                this.Combine(t.Clone());
                /*
                switch (t.type)
                {
                    case GameTerms.TokenType.HPCurrent:
                    case GameTerms.TokenType.EPCurrent:
                        this.Combine(t.Clone());
                        break;
                }
                */
            }
        }
    }
}
