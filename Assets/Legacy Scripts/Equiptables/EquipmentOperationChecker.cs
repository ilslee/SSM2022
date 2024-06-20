using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* EquiptmentOperationChecker
장착 가능한 객체(BP Chip, Item)의 동작 조건을 판단하는 SO
여기서 BP Chip, Item 이 분기된다. 

BP Chip : Condition을 기반으로 Pose / Motion을 결정
Item : Condition을 기반으로 Stats 가감

*/
/*
namespace ssm.data{
    public class EquiptmentOperationChecker : ScriptableObject
    {
        public enum Timing{None, Static, Every, Previous}
        public enum Phase{None, Ready, Pose, Motion, Adjust, Compare, Result, Feedback}
        //대상
        public enum Target{None, Me, Opponent, Both}
        
        public enum Stats{None, Health, Energy, Attack, Defence, AttackSlot, DefenceSlot, Damage}
        public enum Pose{None, Sword, Shield, Move}
        public enum Motion{None, Stay, Normal, Enhace}

        public enum Comparison{None, More, Less, Equal, Above, Below}
        
        public Timing timing;
        public float timingValue;
        public Phase phase;
        public Target target;
        public Stats Stats;
        public Comparison StatsComparison;
        public float  StatsValue;
        public Pose pose;
        public Motion motion;
        public void Reset(){
            timing = Timing.None;
            timingValue = 0f;
            phase = Phase.None;
            target = Target.None;
            Stats = Stats.None;
            StatsComparison = Comparison.None;
            StatsValue = 0f;
            pose = Pose.None;
            motion = Motion.None;
        }
    }
}
*/