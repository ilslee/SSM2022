using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.ui;
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
                    animations[i] = null;
                    animations.RemoveAt(i);
                }else animations[i].CalculateAnimation();
            }
            
        }
    }
    public void AddAnimation(UIAnimationToken t){
        // animations.Add(t);
        int prevTokenID = animations.FindIndex(x => x.target == t.target && x.GetType() == t.GetType());
        if(prevTokenID != -1) {
            // Debug.Log("Found overwrapped animation where " + prevToken.target.name + " / " + prevToken.animationTokenType.ToString());
            animations[prevTokenID] = null;
            animations.RemoveAt(prevTokenID);
        }
        animations.Add(t);
    }
}
