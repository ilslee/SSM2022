
using System.Collections.Generic;

public static class GameTerms
{
    public enum Phase{  None, StartGame, FinishGame, Recovery, Expectation, InputReady, Motion, Calculation, Feedback    }
    
    public enum TokenType { None,                             
                            AttackAction, StrikeAction, DefenceAction, ChargeAction, RestAction, AvoidAction, // Actions0
                            
                            HPCurrent, HPMax, HPStart, //Health 
                            EPCurrent, EPMax, EPStart, //Energy

                            CollisionWin, CollisionLose, NoCollision,
                            AttackPower, AttackEfficiency, StrikePower, StrikeEfficiency, StrikeConsumption, // Sword power and energy
                            DefencePower, DefenceEfficiency, CollisionGeneration, ChargePower, ChargeEfficiency, ChargeConsumption, // Shield power and energy
                            RestPower, AvoidPower, AvoidEfficiency, AvoidAdaptiveConsumption, RestGeneration, AvoidGeneration, // Move power and energy
                            BasePower, EnergyPower, AdditionalPower, TotalPower, 
                            Damage
                            }




    public enum TokenOccasion { None, Static, Dynamic, 
                                MotionNone, Attack, Strike, Defence, Charge, Avoid, Rest,
                                Sword, Shield, Move, Offensive, Defensive, // Actions1
                                Recover, Feedback, Give, Take

    }



    public enum MTType{  None, 
                                    Health, AdaptiveHealth, Energy, AdaptiveEnergy,
                                    SwordPower, ShieldPower, 
                                    Power, OffensivePower, DefensivePower, Damage, DamageReduction, 
                                    Attack, Strike, Defence, Charge, Avoid, Taunt, Red, Blue, Green,
                                    }
    public enum MTWho{None,  Game, Me, Opponent, Both}
    public enum MTWhen{ None, OnMax, OnStart, OnRecovery,
                        MEAttack, MEStrike, MEDefence, MECharge, MEAvoid, METaunt}
                        


    public enum ItemFamily{None, Basic, Life, Assassin, Blacksmith, Death, Emperor, Hester}
    public enum ItemPart{None, Sword, Shield, Head, Body, Arms, Legs, Core, Accessory, Set}
    /*
        1. Current  현재값
        -------------------------[OnMidification] : 지속 효과들을 넣어둠
        -------------------------[OnCalculation] : 매 턴 계산
        2. Min Max  Adaptive 값들이 있으면 최대치
        3. GainNextTurn     ApplyModifierOnCalculation 에서 적용되는 증가
        4. LossNextTurn     ApplyModifierOnCalculation 에서 Opponent에 의해 적용되는 감소
        5. Consume  ApplyModifierOnCalculation 에서 Me에 의해 적용되는 감소
        6. Absorb   흡수. ApplyModifierOnCalculation에서 GainNextTurn-Me로 변경
        7. Steal    훔치기. ApplyModifierOnReady Recover-Me와 Decline-Opponent로 변경되어 적용
        8. Recover  ApplyModifierOnReady 에서 적용되는 증가
        9. Decline  ApplyModifierOnReady 에서 적용되는 감소
        10. Invalid 특정 내용을 무효화(주로 동작)
        11. OnCalculation : 계산단계에서 적용
        12. StatModification : 턴 시작시 조정 단계에서 적용

    */
    public enum MTHow{  None, Current, Min, Max, Start, GainNextTurn, LossNextTurn, Steal, Consume, Recover, Decline,Modify,Give, Take, Additional, Invalid, Prevent, 
                        OnModification, OnCalculation }

    //----------------------------------- Conditional Item
    // public enum ConditionWhen{None, At, Previous, PreviousDuration, Duration, Current, Every}
    // public enum ConditionWho{None, Game, Me, Opponent, Both}
    // public enum ConditionWhat{None, Health, Energy, Attack, AttackSlot, Defence, DefenceSlot, DamageApplied, DamageTaken, Turn}
    // public enum ConditionHow{None, More, Less, Avobe, Below, Equal, Incresed, Decreced}
    //----------------------------------- BP
    

    public class BPCondition{
        //Character
            public const string DEVIDER = "devider"; // Condition이 여러개인 경우 구분하기 위해 사용
            public const string CHARACTER_ME = "character_me";
            public const string CHARACTER_OTHER = "character_other";
            public const string CHARACTER_BOTH = "character_both";
            public const string CHARACTER_NONE = "character_none"; // inverse 조건처럼 활용할 수 있음
            //What-Stat
            public const string STAT_HEALTH = "stat_health";
            public const string STAT_ENERGY = "stat_energy";
            public const string STAT_SWORD = "stat_sword";
            public const string STAT_SHIELD = "stat_shield";
            public const string STAT_DAMAGE_GIVE = "stat_damage_give";
            public const string STAT_DAMAGE_TAKE = "stat_damage_take";
            
            //What-Motion : BPMotion에서 같이 사용
            public const string MOTION_ATTACK = "motion_attack";
            public const string MOTION_STRIKE = "motion_strike";
            public const string MOTION_DEFENCE = "motion_defence";
            public const string MOTION_CHARGE = "motion_charge";
            public const string MOTION_AVOID = "motion_avoid";
            public const string MOTION_TAUNT = "motion_taunt";
            public const string MOTION_SWORD = "motion_sword";
            public const string MOTION_SHIELD = "motion_shield";
            public const string MOTION_LEGS = "motion_legs";
            public const string MOTION_OFFENSIVE = "motion_offensive";
            public const string MOTION_DEFENSIVE = "motion_defensive";

            //How-Modification
            public const string MODIFICATION_GAIN = "modification_gain";
            public const string MODIFICATION_LOSS = "modification_loss";
            //How-Count
            // public const string COUNT = "count"; // 무언가의 횟수를 헤아릴 때. 숫자가 아닌 행위와 연결. COMPARISON으로 대채 가능할 듯
            //Comparison
            public const string COMPARISON_SAME = "comparison_same"; // +Number
            public const string COMPARISON_MORE = "comparison_more"; //
            public const string COMPARISON_LESS = "comparison_less";
                        
            //Time
            public const string TIME_AT = "time_at"; // + Number
            public const string TIME_FROM = "time_from"; // + Number + TIME_TO + Number
            public const string TIME_TO = "time_to"; // + Number
            public const string TIME_PREVIOUS = "time_previous"; // + Number
            
            //Timeless
            public const string STATIC_STEP_UP = "static_step_up";
            public const string STATIC_ALWAYS = "static_always";


            public const string LINKER_AND = "linker_and";
            public const string LINKER_OR = "linker_or";
    }

    
    public class BPBehaviour{
        // public const string REWIND = "rewind";
    }
    // public enum BPBehaviour{None, Default, RandomIndexAtFirstStart, DestroyAfterUse}

    
    // public enum Pose{None, Sword, Shield, Move, Random, OtherPrev1Pose, OtherPrev2Pose, Winning, Losing, Same}
    // public enum Motion{None, Stay, Normal, Enhance}
    public enum Motion{None, Attack, Strike, Defence, Charge, Rest, Avoid, Taunt}
    // public enum DamageType{None, Attack, Defence}
    //, FastAttack, Block, Blitz
         
}

public class BPT{
    
    public enum Essential{StepUp}
    public enum Linker{And}
    public enum Subject{}
    public enum Object{}
    public enum Method{}
    public enum TimeMethod{}
    public enum Comparison{}
    public enum Motion{
        None, Attack, Strike, Defence, Charge, Avoid, Taunt, 
        Random, Prev1, Prev2, Win, Lose, Same, NotOnPrevMotion, NotOnPrevMove, OnPrevMotion, OnPrevMove, EnergyUse, EnergyNoUse
    }
    
    public enum Behaviour{None}

    public class Event{
        public Subject subj;
        public Object obj;
        public Method method;
        public Comparison comparison;
        public float value0;
        public float value1;
    }

    public class State{
        public Subject subj;
        public Object obj;
        public Comparison comparison;
        public float value0;
        public float value1;
    }

    public class Time{
        public Comparison comparison;
        public float value0;
        public float value1;
    }
}