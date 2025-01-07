using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AnimationCurveContainer", menuName = "SSM/AnimationCurveContainer")]

public class AnimationCurveContainer : ScriptableObject
{
    public enum Type {None, FastRebound1, FastSmooth1}
    public AnimationCurve fastRebound1;
    public AnimationCurve fastsmooth1;

    public AnimationCurve GetCurve(Type t){
        switch(t){
            case Type.FastRebound1:
            return fastRebound1;
            case Type.FastSmooth1:
            return fastsmooth1;
            default : 
            return fastRebound1;
        }

    }
}
