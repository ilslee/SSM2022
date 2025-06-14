
using System.Collections.Generic;

public static class GameTerms
{
    public enum Phase{  None, StartGame, FinishGame, Recovery, Expectation, InputReady, Motion, Calculation, Feedback,
                        Game_Start, TransitionEnter, Countdown, Turn_Ready, Animation_Idle, Turn_Calculate, Animation_Calc1, Animation_Calc2, 
                        Turn_CheckGameEnd, Animation_End1, Animation_End2, Game_End, TransitionExit}
    
    public enum TokenType { None,      
                            Question, History, Status,//아이콘에만 사용되는 인덱스 설정
                            AttackAction, StrikeAction, DefenceAction, ChargeAction, RestAction, AvoidAction, // Actions0
                            Power, Energy, Consumption, Efficiency, //MultiTypeToken의 Subtype용
                            
                            HPCurrent, HPMax, HPStart, //Health 
                            EPCurrent, EPMax, EPStart, EPConsumption,//Energy

                            CollisionWin, CollisionLose, NoCollision,
                            AttackPower, AttackEfficiency, StrikePower, StrikeEfficiency, SwordEPAvailable, StrikeConsumption, // Sword power and energy
                            DefencePower, DefenceEfficiency, CollisionGeneration, ChargePower, ChargeEfficiency, ShieldEPAvailable, ChargeConsumption, // Shield power and energy
                            RestPower, AvoidPower, AvoidEfficiency, AvoidAdaptiveConsumption, RestGeneration, AvoidGeneration, // Move power and energy
                            SwrodPower, SwordEfficiency, ShieldPower, ShieldEfficiency, MovePower, MoveEfficiency,
                            OffensivePower, OffensiveEfficiency, DefensivePower, DefensiveEfficiency,
                            BasePower, EnergyPower, AdditionalPower, TotalPower, Efficieny,
                            Damage,
                            Poisonous, Poisoned, Nurture, Vigor, Regeneration, Transfusion, Circulation, Circulating, Recovery // Life Tokens
                            }



    /* TokenOccasion
    Static : 변하지 않는 스탯류 (Max 어쩌구..)
    Dynamic : 항상 변하는 스탯류
    Motions : 동작 계산시 발생하는 것들
    TurnStart : 턴 시작 시 발생 - 주로 턴 흐름과 관련된 
    Calculation : 충돌 시 발생(Power 비교 시)
    Feedback : 충돌 이후 발생
    */
    public enum TokenOccasion { None, Static, Dynamic, 
                                MotionNone, Attack, Strike, Defence, Charge, Avoid, Rest,
                                Sword, Shield, Move, Offensive, Defensive, // Actions1
                                Damage, Calculation, Consumption, TurnStart, Feedback, Give, Take,
                                

    }

    public enum Layout{ None, Left, Right, Top, Bottom}

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

public class BPToken{
    
    
    public enum Character{None, Me, Other, Both}
    public enum ConditionType {None}
    public enum Comparison{None}
    public enum TimeType{None}
    public enum BehaviourOccasion{None, Activation, Deactivation}
    public enum BehaviourType{None, Rewind, Shffle}
    
    public enum Motion{
        None, Attack, Strike, Defence, Charge, Rest, Avoid, 
        Random, Prev1, Prev2, Win, Lose, Same, NotOnPrevMotion, NotOnPrevMove, OnPrevMotion, OnPrevMove, EnergyUse, EnergyNoUse
    }
    
    
}