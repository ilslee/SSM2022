using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    public AnimationCurveContainer acc;
    public List<UIAnimationToken> animations;
    public void Start(){
        animations = new List<UIAnimationToken>();
    }
    public void FixedUpdate(){
        // Debug.Log("Num of Animation : " + animations.Count);
        if(animations.Count > 0){
            for (int i = animations.Count-1; i >= 0; i--)
            {
                if(animations[i].isAnimationFinished() == true){
                    animations[i].OnAnimationFinished();
                    animations.Remove(animations[i]);
                }else animations[i].Yield();
            }
            
        }
    }
    public void AddAnimation(UIAnimationToken t){
        // animations.Add(t);
        UIAnimationToken prevToken = animations.Find(x => x.target == t.target && x.GetType() == t.GetType());
        if(prevToken != null) {
            // Debug.Log("Found overwrapped animation where " + prevToken.target.name + " / " + prevToken.animationTokenType.ToString());
            animations.Remove(prevToken);
        }
        animations.Add(t);
    }
}
