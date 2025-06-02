using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ssm.ui
{
    public class UIAnimationManager : MonoBehaviour
    {
        public AnimationCurveContainer acc;
        public List<UIAnimationToken> animations;
        //애니메이션 콜백을 처리할 인터페이스가 있는지 유뮤. 있으면 함수 실행 없으면 건너뜀(애니메이션만 진행)
        public IUIAnimationInterface animationInterface;
        public void Start()
        {
            animations = new List<UIAnimationToken>();
            
        }
        public void AddInterface(IUIAnimationInterface a)
        {
            animationInterface = a;
        }
        public void FixedUpdate()
        {
            // Debug.Log("Num of Animation : " + animations.Count);
            if (animations.Count > 0)
            {
                for (int i = animations.Count - 1; i >= 0; i--)
                {
                    if (animations[i].isAnimationFinished() == true)
                    {
                        // animations[i].OnAnimationFinished();
                        if(animationInterface != null) animationInterface.OnAnimationFinish(i);
                        animations[i] = null;
                        animations.RemoveAt(i);
                    }
                    else
                    {

                        float val = animations[i].CalculateAnimation();
                        if(animationInterface != null) animationInterface.OnAnimationUpdate(i, val);
                    }
                }

            }
        }
        public void AddAnimation(UIAnimationToken t)
        {
            // animations.Add(t);
            int prevTokenID = animations.FindIndex(x => x.target == t.target && x.GetType() == t.GetType());
            if (prevTokenID != -1)
            {
                // Debug.Log("Found overwrapped animation where " + prevToken.target.name + " / " + prevToken.animationTokenType.ToString());
                animations[prevTokenID] = null;
                animations.RemoveAt(prevTokenID);
            }            
            animations.Add(t);
            if(animationInterface != null) animationInterface.OnAnimationStart(animations.Count - 1);
        }
    }
}