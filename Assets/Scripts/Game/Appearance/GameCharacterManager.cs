using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using Unity.VisualScripting;
using UnityEngine;
namespace ssm.game.appearance{
    public class GameCharacterManager : MonoBehaviour
    {
        public int characterIndex = 0;
        private Animator anim;
        private void Start(){
            anim = gameObject.GetComponent<Animator>();
        }
        private void AnimationCalc1(){
            GameTerms.Motion m = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().motion;
            switch(m){
                case GameTerms.Motion.Attack:
                anim.SetTrigger("Attack");
                break;
                case GameTerms.Motion.Strike:
                anim.SetTrigger("Strike");
                break;
                case GameTerms.Motion.Defence:
                anim.SetTrigger("Defend");
                break;
                case GameTerms.Motion.Charge:
                anim.SetTrigger("Charge");
                break;
                case GameTerms.Motion.Rest:
                anim.SetTrigger("Rest");
                break;
                case GameTerms.Motion.Avoid:
                anim.SetTrigger("Avoid");
                break;
            }
        }
        public void ManageGameEvent(string type, float value){
            switch(type){
                case GameEvent.ANIMATION_CALC1:
                AnimationCalc1();
                break;
            }
            // anim.SetTrigger("")
        }
    }
}