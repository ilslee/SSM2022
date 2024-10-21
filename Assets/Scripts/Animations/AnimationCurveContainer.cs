using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AnimationCurveContainer", menuName = "SSM/AnimationCurveContainer")]

public class AnimationCurveContainer : ScriptableObject
{
    public enum AnimationType {None, FastRebound1}
    public AnimationCurve fastRebound1;
}
