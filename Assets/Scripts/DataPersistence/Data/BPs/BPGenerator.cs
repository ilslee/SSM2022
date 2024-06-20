using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;

public class BPGenerator : MonoBehaviour
{
    
    public enum EventKeyword{
        None
    }
    public struct State{

    }
    public enum StatusKeyword{
        None
    }
    public enum TimeKeyword{
        None
    }
    private List<BPT.Motion> motionBase;
    private List<BPT.Motion> motionOffensive;
    private List<BPT.Motion> motionDefensive;
    private List<BPT.Motion> motionMoreSword;
    private List<BPT.Motion> motionMoreShield;
    private List<BPT.Motion> motionMoreMove;
    private List<BPT.Motion> motionMoreAttack;
    private List<BPT.Motion> motionMoreStrike;
    private List<BPT.Motion> motionMoreDefence;
    private List<BPT.Motion> motionMoreCharge;
    private List<BPT.Motion> motionMoreAvoid;
    private List<BPT.Motion> motionMoreTaunt;
    private List<BPT.Motion> motionMoreEnergy;
    private List<BPT.Motion> motionMoreSwordPower;
    private List<BPT.Motion> motionMoreShieldPower;
    private List<BPT.Motion> motionSpecialRandom;
    private List<BPT.Motion> motionSpecialOthersPrev1;
    private List<BPT.Motion> motionSpecialOthersPrev2;
    private List<BPT.Motion> motionSpecialWin;
    private List<BPT.Motion> motionSpecialLose;
    private List<BPT.Motion> motionSpecialSame;
    private List<BPT.Motion> motionSpecialNotOnPrevMotion;
    private List<BPT.Motion> motionSpecialNotOnPrevMove;
    private List<BPT.Motion> motionSpecialOnPrevMotion;
    private List<BPT.Motion> motionSpecialOnPrevMove;
    private List<BPT.Motion> motionSpecialEnergyUse;
    private List<BPT.Motion> motionSpecialNoEnergyUse;
    

    public enum MotionKeyword{None, Even, Random}
    public enum BehaviourKeyword{None}

    public void Start(){
        
    }
    public BPT.Event GenerateEvent(){
        return new BPT.Event();
    }

    public BPT.State GenerateState(){
        return new BPT.State();
    }
    private void InitMotions(){
        // 기본 모션 풀 : 공공공스스방방방차차회회회타
        motionBase = new List<BPT.Motion>();
        motionBase.Add(BPT.Motion.Attack);
        motionBase.Add(BPT.Motion.Attack);
        motionBase.Add(BPT.Motion.Attack);
        motionBase.Add(BPT.Motion.Strike);
        motionBase.Add(BPT.Motion.Strike);
        motionBase.Add(BPT.Motion.Defence);
        motionBase.Add(BPT.Motion.Defence);
        motionBase.Add(BPT.Motion.Defence);
        motionBase.Add(BPT.Motion.Charge);
        motionBase.Add(BPT.Motion.Charge);
        motionBase.Add(BPT.Motion.Avoid);
        motionBase.Add(BPT.Motion.Avoid);
        motionBase.Add(BPT.Motion.Avoid);
        motionBase.Add(BPT.Motion.Taunt);

        motionOffensive = new List<BPT.Motion>();
        motionOffensive.Add(BPT.Motion.Attack);
        motionOffensive.Add(BPT.Motion.Attack);
        motionOffensive.Add(BPT.Motion.Strike);
        motionOffensive.Add(BPT.Motion.Strike);
        motionOffensive.Add(BPT.Motion.Charge);
        motionOffensive.Add(BPT.Motion.Charge);

        motionDefensive = new List<BPT.Motion>();
        motionDefensive.Add(BPT.Motion.Defence);
        motionDefensive.Add(BPT.Motion.Defence);
        motionDefensive.Add(BPT.Motion.Defence);
        motionDefensive.Add(BPT.Motion.Avoid);
        motionDefensive.Add(BPT.Motion.Avoid);
        motionDefensive.Add(BPT.Motion.Taunt);

        motionMoreSword = new List<BPT.Motion>();
        motionMoreSword.Add(BPT.Motion.Attack);
        motionMoreSword.Add(BPT.Motion.Attack);
        motionMoreSword.Add(BPT.Motion.Attack);
        motionMoreSword.Add(BPT.Motion.Strike);
        motionMoreSword.Add(BPT.Motion.Strike);
        motionMoreSword.Add(BPT.Motion.Strike);

        motionMoreShield = new List<BPT.Motion>();
        motionMoreShield.Add(BPT.Motion.Defence);
        motionMoreShield.Add(BPT.Motion.Defence);
        motionMoreShield.Add(BPT.Motion.Defence);
        motionMoreShield.Add(BPT.Motion.Charge);
        motionMoreShield.Add(BPT.Motion.Charge);
        motionMoreShield.Add(BPT.Motion.Charge);

        motionMoreMove = new List<BPT.Motion>();
        motionMoreMove.Add(BPT.Motion.Avoid);
        motionMoreMove.Add(BPT.Motion.Avoid);
        motionMoreMove.Add(BPT.Motion.Avoid);
        motionMoreMove.Add(BPT.Motion.Avoid);
        motionMoreMove.Add(BPT.Motion.Taunt);
        motionMoreMove.Add(BPT.Motion.Taunt);

        motionMoreAttack = new List<BPT.Motion>();
        motionMoreAttack.Add(BPT.Motion.Attack);
        motionMoreAttack.Add(BPT.Motion.Attack);
        motionMoreAttack.Add(BPT.Motion.Attack);
        motionMoreAttack.Add(BPT.Motion.Attack);
        motionMoreAttack.Add(BPT.Motion.Attack);
        motionMoreAttack.Add(BPT.Motion.Attack);

        motionMoreStrike = new List<BPT.Motion>();
        motionMoreStrike.Add(BPT.Motion.Strike);
        motionMoreStrike.Add(BPT.Motion.Strike);
        motionMoreStrike.Add(BPT.Motion.Strike);
        motionMoreStrike.Add(BPT.Motion.Strike);

        motionMoreDefence = new List<BPT.Motion>();
        motionMoreDefence.Add(BPT.Motion.Defence);
        motionMoreDefence.Add(BPT.Motion.Defence);
        motionMoreDefence.Add(BPT.Motion.Defence);
        motionMoreDefence.Add(BPT.Motion.Defence);
        motionMoreDefence.Add(BPT.Motion.Defence);
        motionMoreDefence.Add(BPT.Motion.Defence);

        motionMoreCharge = new List<BPT.Motion>();
        motionMoreCharge.Add(BPT.Motion.Charge);
        motionMoreCharge.Add(BPT.Motion.Charge);
        motionMoreCharge.Add(BPT.Motion.Charge);
        motionMoreCharge.Add(BPT.Motion.Charge);

        motionMoreAvoid = new List<BPT.Motion>();
        motionMoreAvoid.Add(BPT.Motion.Avoid);
        motionMoreAvoid.Add(BPT.Motion.Avoid);
        motionMoreAvoid.Add(BPT.Motion.Avoid);
        motionMoreAvoid.Add(BPT.Motion.Avoid);
        motionMoreAvoid.Add(BPT.Motion.Avoid);
        motionMoreAvoid.Add(BPT.Motion.Avoid);

        motionMoreTaunt = new List<BPT.Motion>();
        motionMoreTaunt.Add(BPT.Motion.Taunt);
        motionMoreTaunt.Add(BPT.Motion.Taunt);

        motionMoreEnergy = new List<BPT.Motion>();
        motionMoreEnergy.Add(BPT.Motion.Defence);
        motionMoreEnergy.Add(BPT.Motion.Defence);
        motionMoreEnergy.Add(BPT.Motion.Avoid);
        motionMoreEnergy.Add(BPT.Motion.Avoid);
        motionMoreEnergy.Add(BPT.Motion.Taunt);
        motionMoreEnergy.Add(BPT.Motion.Taunt);

        motionMoreSwordPower = new List<BPT.Motion>();
        motionMoreSwordPower.Add(BPT.Motion.Attack);
        motionMoreSwordPower.Add(BPT.Motion.Attack);
        motionMoreSwordPower.Add(BPT.Motion.Attack);
        motionMoreSwordPower.Add(BPT.Motion.Avoid);
        motionMoreSwordPower.Add(BPT.Motion.Avoid);

        motionMoreShieldPower = new List<BPT.Motion>();
        motionMoreShieldPower.Add(BPT.Motion.Defence);
        motionMoreShieldPower.Add(BPT.Motion.Defence);
        motionMoreShieldPower.Add(BPT.Motion.Defence);
        motionMoreShieldPower.Add(BPT.Motion.Avoid);
        motionMoreShieldPower.Add(BPT.Motion.Avoid);
        //-----------------------------------------------------------------
        motionSpecialRandom = new List<BPT.Motion>();
        motionSpecialRandom.Add(BPT.Motion.Random);
        motionSpecialRandom.Add(BPT.Motion.Random);
        motionSpecialRandom.Add(BPT.Motion.Random);
        motionSpecialRandom.Add(BPT.Motion.Random);
        motionSpecialRandom.Add(BPT.Motion.Random);
        motionSpecialRandom.Add(BPT.Motion.Random);

        motionSpecialOthersPrev1 = new List<BPT.Motion>();
        motionSpecialOthersPrev1.Add(BPT.Motion.Prev1);
        motionSpecialOthersPrev1.Add(BPT.Motion.Prev1);
        motionSpecialOthersPrev1.Add(BPT.Motion.Prev1);
        motionSpecialOthersPrev1.Add(BPT.Motion.Prev1);
        motionSpecialOthersPrev1.Add(BPT.Motion.Prev1);
        motionSpecialOthersPrev1.Add(BPT.Motion.Prev1);
        
        motionSpecialOthersPrev2 = new List<BPT.Motion>();
        motionSpecialOthersPrev2.Add(BPT.Motion.Prev2);
        motionSpecialOthersPrev2.Add(BPT.Motion.Prev2);
        motionSpecialOthersPrev2.Add(BPT.Motion.Prev2);
        motionSpecialOthersPrev2.Add(BPT.Motion.Prev2);
        motionSpecialOthersPrev2.Add(BPT.Motion.Prev2);
        motionSpecialOthersPrev2.Add(BPT.Motion.Prev2);

        motionSpecialWin = new List<BPT.Motion>();
        motionSpecialWin.Add(BPT.Motion.Win);
        motionSpecialWin.Add(BPT.Motion.Win);
        motionSpecialWin.Add(BPT.Motion.Win);

        motionSpecialLose = new List<BPT.Motion>();
        motionSpecialLose.Add(BPT.Motion.Lose);
        motionSpecialLose.Add(BPT.Motion.Lose);
        motionSpecialLose.Add(BPT.Motion.Lose);

        motionSpecialSame = new List<BPT.Motion>();
        motionSpecialSame.Add(BPT.Motion.Same);
        motionSpecialSame.Add(BPT.Motion.Same);
        motionSpecialSame.Add(BPT.Motion.Same);
        motionSpecialSame.Add(BPT.Motion.Same);
        motionSpecialSame.Add(BPT.Motion.Same);
        motionSpecialSame.Add(BPT.Motion.Same);

        motionSpecialNotOnPrevMotion = new List<BPT.Motion>();
        motionSpecialNotOnPrevMotion.Add(BPT.Motion.NotOnPrevMotion);
        motionSpecialNotOnPrevMotion.Add(BPT.Motion.NotOnPrevMotion);
        motionSpecialNotOnPrevMotion.Add(BPT.Motion.NotOnPrevMotion);
        motionSpecialNotOnPrevMotion.Add(BPT.Motion.NotOnPrevMotion);
        motionSpecialNotOnPrevMotion.Add(BPT.Motion.NotOnPrevMotion);
        motionSpecialNotOnPrevMotion.Add(BPT.Motion.NotOnPrevMotion);

        motionSpecialNotOnPrevMove = new List<BPT.Motion>();
        motionSpecialNotOnPrevMove.Add(BPT.Motion.NotOnPrevMove);
        motionSpecialNotOnPrevMove.Add(BPT.Motion.NotOnPrevMove);
        motionSpecialNotOnPrevMove.Add(BPT.Motion.NotOnPrevMove);

        motionSpecialOnPrevMotion = new List<BPT.Motion>();
        motionSpecialOnPrevMotion.Add(BPT.Motion.OnPrevMotion);
        motionSpecialOnPrevMotion.Add(BPT.Motion.OnPrevMotion);
        motionSpecialOnPrevMotion.Add(BPT.Motion.OnPrevMotion);

        motionSpecialOnPrevMove = new List<BPT.Motion>();
        motionSpecialOnPrevMove.Add(BPT.Motion.OnPrevMove);
        motionSpecialOnPrevMove.Add(BPT.Motion.OnPrevMove);
        motionSpecialOnPrevMove.Add(BPT.Motion.OnPrevMove);
        motionSpecialOnPrevMove.Add(BPT.Motion.OnPrevMove);
        motionSpecialOnPrevMove.Add(BPT.Motion.OnPrevMove);
        motionSpecialOnPrevMove.Add(BPT.Motion.OnPrevMove);

        motionSpecialEnergyUse = new List<BPT.Motion>();
        motionSpecialEnergyUse.Add(BPT.Motion.EnergyUse);
        motionSpecialEnergyUse.Add(BPT.Motion.EnergyUse);
        motionSpecialEnergyUse.Add(BPT.Motion.EnergyUse);
        motionSpecialEnergyUse.Add(BPT.Motion.EnergyUse);
        motionSpecialEnergyUse.Add(BPT.Motion.EnergyUse);
        motionSpecialEnergyUse.Add(BPT.Motion.EnergyUse);

        motionSpecialNoEnergyUse = new List<BPT.Motion>();
        motionSpecialNoEnergyUse.Add(BPT.Motion.EnergyNoUse);
        motionSpecialNoEnergyUse.Add(BPT.Motion.EnergyNoUse);
        motionSpecialNoEnergyUse.Add(BPT.Motion.EnergyNoUse);
        motionSpecialNoEnergyUse.Add(BPT.Motion.EnergyNoUse);
        motionSpecialNoEnergyUse.Add(BPT.Motion.EnergyNoUse);
        motionSpecialNoEnergyUse.Add(BPT.Motion.EnergyNoUse);
    }
    public void SetBPGenerationBlueprint(int difficulty){

    }

    public BPData GenerateBPData(EventKeyword evtKey, StatusKeyword stsKey, TimeKeyword timKey, MotionKeyword moKey, BehaviourKeyword behavKey, int length){
        // BPData data = ScriptableObject.CreateInstance("BPData") as BPData;
        
        BPData data = new BPData();
        data.conditionEvent = GenerateBPConditionEvent(evtKey);
        data.conditionStatus = GenerateBPConditionStatus(stsKey);
        data.conditionTime = GenerateBPConditionTime(timKey);
        // data.condition = GenerateBPCondition(conKey);

        data.motion = GenerateBPMotion(moKey, length);
        data.behaviour = GenerateBPBehaviour(behavKey);
        return data;
    }
    private BPT.Event GenerateBPConditionEvent(EventKeyword keyword){
        return new BPT.Event();
    }
    private BPT.State GenerateBPConditionStatus(StatusKeyword keyword){
        return new BPT.State();
    }
    private BPT.Time GenerateBPConditionTime(TimeKeyword keyword){
        return new BPT.Time();
    }
    // private List<object> GenerateBPCondition(ConditionKeyword key){
    //     List<object> bpCondition = new List<object>();
    //     switch(key){
            
    //         //return empty - default;
    //         // bpCondition.Add(BPT.Essential.StepUp);

    //         break;
    //     }
    //     return bpCondition;
    // }
    private List<BPT.Motion> GenerateBPMotion(MotionKeyword key, int length){
        List<BPT.Motion> bpMotion = new List<BPT.Motion>();
        List<BPT.Motion> bpMotionCandicate = new List<BPT.Motion>();
        int bpMotionID = 0;
        switch(key){
            case MotionKeyword.Even:
            bpMotionCandicate.Add(BPT.Motion.Attack);
            bpMotionCandicate.Add(BPT.Motion.Strike);
            bpMotionCandicate.Add(BPT.Motion.Defence);
            bpMotionCandicate.Add(BPT.Motion.Charge);
            bpMotionCandicate.Add(BPT.Motion.Avoid);
            bpMotionCandicate.Add(BPT.Motion.Taunt);            
            for (int i = 0; i < length; i++)
            {
                bpMotionID = MathTool.GetRandomIndex(bpMotionCandicate.Count);
                bpMotion.Add(bpMotionCandicate[bpMotionID]);
            }
            ContainLeastOneOffensiveMotion(bpMotion);
            break;

            case MotionKeyword.Random:
            bpMotion.Add(BPT.Motion.Random);
            break;
            case MotionKeyword.None:
            Debug.LogError("BPGenerator.GenerateBPMotion : No Motion Keyword.");
            //return empty - default;
            break;
        }
        return bpMotion;

        List<BPT.Motion> ContainLeastOneOffensiveMotion(List<BPT.Motion> originalMotion){
            bool noOffinsiveMotion = true;
            foreach(BPT.Motion item in originalMotion){
                if(IsOffensiveMotion(item) == true){
                    noOffinsiveMotion = false;
                    break;
                }
            }
            if(noOffinsiveMotion == true){ // change one motion to offensive if ther is no offensive motion
                int targetID = MathTool.GetRandomIndex(originalMotion.Count);
                List<BPT.Motion> offiensiveMOtionCandicate = new List<BPT.Motion>();
                offiensiveMOtionCandicate.Add(BPT.Motion.Attack);
                offiensiveMOtionCandicate.Add(BPT.Motion.Strike);
                offiensiveMOtionCandicate.Add(BPT.Motion.Charge);
                int offensiveMotionID = MathTool.GetRandomIndex(offiensiveMOtionCandicate.Count);
                originalMotion.RemoveAt(targetID);
                originalMotion.Insert(targetID, offiensiveMOtionCandicate[offensiveMotionID]);
            }

            return originalMotion;
        }

        bool IsOffensiveMotion(BPT.Motion motion){
            switch(motion){
                case BPT.Motion.Attack:
                case BPT.Motion.Strike:
                case BPT.Motion.Charge:                
                return true;
            }
            return false;
        }
    }

    private List<BPT.Behaviour> GenerateBPBehaviour(BehaviourKeyword key){
        List<BPT.Behaviour> bpBehaviour = new List<BPT.Behaviour>();
        switch(key){
            case BehaviourKeyword.None:
            //return empty - default;
            break;
        }
        return bpBehaviour;
    }
    /*
    public List<BPData.Condition> GenerateCondition(){
        List<BPData.Condition> condition = new List<BPData.Condition>();
        //기본 컨디션
        BPData.Condition defaultCondition = new BPData.Condition();
        condition.Add(defaultCondition);
        return condition;
    }

    //지정된 길이만큼 모션을 만들어 반환
    public List<GameTerms.BPMotion> GenerateBPMotion(int l, Keyword k = Keyword.None){
        List<GameTerms.BPMotion> bpMotions = new List<GameTerms.BPMotion>();
        // MathTool.GetRandomIntWithin(4,5,6)
        for (int i = 0; i < l; i++)
        {
            bpMotions.Add(GetRandomBPMotion());
        }
        return bpMotions;
    }

    private GameTerms.BPMotion GetRandomBPMotion(){
        int motionIndex = MathTool.GetRandomIndex(5);
        GameTerms.BPMotion m = GameTerms.BPMotion.None;
        switch(motionIndex){
            case 0:
            m = GameTerms.BPMotion.Attack;
            break;
            case 1:
            m = GameTerms.BPMotion.Strike;
            break;
            case 2:
            m = GameTerms.BPMotion.Defence;
            break;
            case 3:
            m = GameTerms.BPMotion.Charge;
            break;
            case 4:
            m = GameTerms.BPMotion.Avoid;
            break;
            case 5:
            m = GameTerms.BPMotion.Taunt;
            break;
        }
        return m;
    }
    */
}
