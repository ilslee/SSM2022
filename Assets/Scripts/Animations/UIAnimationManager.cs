using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    public AnimationCurveContainer acc;
    private Vector2 destination;
    private float timer;
    private float duration;
    public void Start(){
        timer = 0f;
        duration = 0f;
    }
    public void FixedUpdate(){
        if(timer < duration){

            timer += Time.deltaTime;
        }
        // Debug.Log("AnimatinoContainer!");
    }
    public void Position(Vector2 dest, float d, AnimationCurveContainer.AnimationType cx, AnimationCurveContainer.AnimationType cy = AnimationCurveContainer.AnimationType.None){
        //gameObject.GetComponent<RectTransform>().anchoredPosition
    }
    public void Scale(Vector2 dest, float d, AnimationCurveContainer.AnimationType cx, AnimationCurveContainer.AnimationType cy = AnimationCurveContainer.AnimationType.None){

    }
    public void Rotate(Vector2 dest, float d, AnimationCurveContainer.AnimationType cx, AnimationCurveContainer.AnimationType cy = AnimationCurveContainer.AnimationType.None){

    }
}
