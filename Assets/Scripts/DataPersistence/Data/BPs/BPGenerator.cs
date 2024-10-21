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
    private List<BPToken.Motion> motionBase;
    private List<BPToken.Motion> motionOffensive;
    private List<BPToken.Motion> motionDefensive;
    private List<BPToken.Motion> motionMoreSword;
    private List<BPToken.Motion> motionMoreShield;
    private List<BPToken.Motion> motionMoreMove;
    private List<BPToken.Motion> motionMoreAttack;
    private List<BPToken.Motion> motionMoreStrike;
    private List<BPToken.Motion> motionMoreDefence;
    private List<BPToken.Motion> motionMoreCharge;
    private List<BPToken.Motion> motionMoreAvoid;
    private List<BPToken.Motion> motionMoreTaunt;
    private List<BPToken.Motion> motionMoreEnergy;
    private List<BPToken.Motion> motionMoreSwordPower;
    private List<BPToken.Motion> motionMoreShieldPower;
    private List<BPToken.Motion> motionSpecialRandom;
    private List<BPToken.Motion> motionSpecialOthersPrev1;
    private List<BPToken.Motion> motionSpecialOthersPrev2;
    private List<BPToken.Motion> motionSpecialWin;
    private List<BPToken.Motion> motionSpecialLose;
    private List<BPToken.Motion> motionSpecialSame;
    private List<BPToken.Motion> motionSpecialNotOnPrevMotion;
    private List<BPToken.Motion> motionSpecialNotOnPrevMove;
    private List<BPToken.Motion> motionSpecialOnPrevMotion;
    private List<BPToken.Motion> motionSpecialOnPrevMove;
    private List<BPToken.Motion> motionSpecialEnergyUse;
    private List<BPToken.Motion> motionSpecialNoEnergyUse;
    

    public enum MotionKeyword{None, Even, Random}
    public enum BehaviourKeyword{None}

    public void Start(){
        
    }
    
    private void InitMotions(){
        // 기본 모션 풀 : 공공공스스방방방차차회회회타
        motionBase = new List<BPToken.Motion>();
        motionBase.Add(BPToken.Motion.Attack);
        motionBase.Add(BPToken.Motion.Attack);
        motionBase.Add(BPToken.Motion.Attack);
        motionBase.Add(BPToken.Motion.Strike);
        motionBase.Add(BPToken.Motion.Strike);
        motionBase.Add(BPToken.Motion.Defence);
        motionBase.Add(BPToken.Motion.Defence);
        motionBase.Add(BPToken.Motion.Defence);
        motionBase.Add(BPToken.Motion.Charge);
        motionBase.Add(BPToken.Motion.Charge);
        motionBase.Add(BPToken.Motion.Avoid);
        motionBase.Add(BPToken.Motion.Avoid);
        motionBase.Add(BPToken.Motion.Avoid);
        motionBase.Add(BPToken.Motion.Rest);

        motionOffensive = new List<BPToken.Motion>();
        motionOffensive.Add(BPToken.Motion.Attack);
        motionOffensive.Add(BPToken.Motion.Attack);
        motionOffensive.Add(BPToken.Motion.Strike);
        motionOffensive.Add(BPToken.Motion.Strike);
        motionOffensive.Add(BPToken.Motion.Charge);
        motionOffensive.Add(BPToken.Motion.Charge);

        motionDefensive = new List<BPToken.Motion>();
        motionDefensive.Add(BPToken.Motion.Defence);
        motionDefensive.Add(BPToken.Motion.Defence);
        motionDefensive.Add(BPToken.Motion.Defence);
        motionDefensive.Add(BPToken.Motion.Avoid);
        motionDefensive.Add(BPToken.Motion.Avoid);
        motionDefensive.Add(BPToken.Motion.Rest);

        motionMoreSword = new List<BPToken.Motion>();
        motionMoreSword.Add(BPToken.Motion.Attack);
        motionMoreSword.Add(BPToken.Motion.Attack);
        motionMoreSword.Add(BPToken.Motion.Attack);
        motionMoreSword.Add(BPToken.Motion.Strike);
        motionMoreSword.Add(BPToken.Motion.Strike);
        motionMoreSword.Add(BPToken.Motion.Strike);

        motionMoreShield = new List<BPToken.Motion>();
        motionMoreShield.Add(BPToken.Motion.Defence);
        motionMoreShield.Add(BPToken.Motion.Defence);
        motionMoreShield.Add(BPToken.Motion.Defence);
        motionMoreShield.Add(BPToken.Motion.Charge);
        motionMoreShield.Add(BPToken.Motion.Charge);
        motionMoreShield.Add(BPToken.Motion.Charge);

        motionMoreMove = new List<BPToken.Motion>();
        motionMoreMove.Add(BPToken.Motion.Avoid);
        motionMoreMove.Add(BPToken.Motion.Avoid);
        motionMoreMove.Add(BPToken.Motion.Avoid);
        motionMoreMove.Add(BPToken.Motion.Avoid);
        motionMoreMove.Add(BPToken.Motion.Rest);
        motionMoreMove.Add(BPToken.Motion.Rest);

        motionMoreAttack = new List<BPToken.Motion>();
        motionMoreAttack.Add(BPToken.Motion.Attack);
        motionMoreAttack.Add(BPToken.Motion.Attack);
        motionMoreAttack.Add(BPToken.Motion.Attack);
        motionMoreAttack.Add(BPToken.Motion.Attack);
        motionMoreAttack.Add(BPToken.Motion.Attack);
        motionMoreAttack.Add(BPToken.Motion.Attack);

        motionMoreStrike = new List<BPToken.Motion>();
        motionMoreStrike.Add(BPToken.Motion.Strike);
        motionMoreStrike.Add(BPToken.Motion.Strike);
        motionMoreStrike.Add(BPToken.Motion.Strike);
        motionMoreStrike.Add(BPToken.Motion.Strike);

        motionMoreDefence = new List<BPToken.Motion>();
        motionMoreDefence.Add(BPToken.Motion.Defence);
        motionMoreDefence.Add(BPToken.Motion.Defence);
        motionMoreDefence.Add(BPToken.Motion.Defence);
        motionMoreDefence.Add(BPToken.Motion.Defence);
        motionMoreDefence.Add(BPToken.Motion.Defence);
        motionMoreDefence.Add(BPToken.Motion.Defence);

        motionMoreCharge = new List<BPToken.Motion>();
        motionMoreCharge.Add(BPToken.Motion.Charge);
        motionMoreCharge.Add(BPToken.Motion.Charge);
        motionMoreCharge.Add(BPToken.Motion.Charge);
        motionMoreCharge.Add(BPToken.Motion.Charge);

        motionMoreAvoid = new List<BPToken.Motion>();
        motionMoreAvoid.Add(BPToken.Motion.Avoid);
        motionMoreAvoid.Add(BPToken.Motion.Avoid);
        motionMoreAvoid.Add(BPToken.Motion.Avoid);
        motionMoreAvoid.Add(BPToken.Motion.Avoid);
        motionMoreAvoid.Add(BPToken.Motion.Avoid);
        motionMoreAvoid.Add(BPToken.Motion.Avoid);

        motionMoreTaunt = new List<BPToken.Motion>();
        motionMoreTaunt.Add(BPToken.Motion.Rest);
        motionMoreTaunt.Add(BPToken.Motion.Rest);

        motionMoreEnergy = new List<BPToken.Motion>();
        motionMoreEnergy.Add(BPToken.Motion.Defence);
        motionMoreEnergy.Add(BPToken.Motion.Defence);
        motionMoreEnergy.Add(BPToken.Motion.Avoid);
        motionMoreEnergy.Add(BPToken.Motion.Avoid);
        motionMoreEnergy.Add(BPToken.Motion.Rest);
        motionMoreEnergy.Add(BPToken.Motion.Rest);

        motionMoreSwordPower = new List<BPToken.Motion>();
        motionMoreSwordPower.Add(BPToken.Motion.Attack);
        motionMoreSwordPower.Add(BPToken.Motion.Attack);
        motionMoreSwordPower.Add(BPToken.Motion.Attack);
        motionMoreSwordPower.Add(BPToken.Motion.Avoid);
        motionMoreSwordPower.Add(BPToken.Motion.Avoid);

        motionMoreShieldPower = new List<BPToken.Motion>();
        motionMoreShieldPower.Add(BPToken.Motion.Defence);
        motionMoreShieldPower.Add(BPToken.Motion.Defence);
        motionMoreShieldPower.Add(BPToken.Motion.Defence);
        motionMoreShieldPower.Add(BPToken.Motion.Avoid);
        motionMoreShieldPower.Add(BPToken.Motion.Avoid);
        //-----------------------------------------------------------------
        motionSpecialRandom = new List<BPToken.Motion>();
        motionSpecialRandom.Add(BPToken.Motion.Random);
        motionSpecialRandom.Add(BPToken.Motion.Random);
        motionSpecialRandom.Add(BPToken.Motion.Random);
        motionSpecialRandom.Add(BPToken.Motion.Random);
        motionSpecialRandom.Add(BPToken.Motion.Random);
        motionSpecialRandom.Add(BPToken.Motion.Random);

        motionSpecialOthersPrev1 = new List<BPToken.Motion>();
        motionSpecialOthersPrev1.Add(BPToken.Motion.Prev1);
        motionSpecialOthersPrev1.Add(BPToken.Motion.Prev1);
        motionSpecialOthersPrev1.Add(BPToken.Motion.Prev1);
        motionSpecialOthersPrev1.Add(BPToken.Motion.Prev1);
        motionSpecialOthersPrev1.Add(BPToken.Motion.Prev1);
        motionSpecialOthersPrev1.Add(BPToken.Motion.Prev1);
        
        motionSpecialOthersPrev2 = new List<BPToken.Motion>();
        motionSpecialOthersPrev2.Add(BPToken.Motion.Prev2);
        motionSpecialOthersPrev2.Add(BPToken.Motion.Prev2);
        motionSpecialOthersPrev2.Add(BPToken.Motion.Prev2);
        motionSpecialOthersPrev2.Add(BPToken.Motion.Prev2);
        motionSpecialOthersPrev2.Add(BPToken.Motion.Prev2);
        motionSpecialOthersPrev2.Add(BPToken.Motion.Prev2);

        motionSpecialWin = new List<BPToken.Motion>();
        motionSpecialWin.Add(BPToken.Motion.Win);
        motionSpecialWin.Add(BPToken.Motion.Win);
        motionSpecialWin.Add(BPToken.Motion.Win);

        motionSpecialLose = new List<BPToken.Motion>();
        motionSpecialLose.Add(BPToken.Motion.Lose);
        motionSpecialLose.Add(BPToken.Motion.Lose);
        motionSpecialLose.Add(BPToken.Motion.Lose);

        motionSpecialSame = new List<BPToken.Motion>();
        motionSpecialSame.Add(BPToken.Motion.Same);
        motionSpecialSame.Add(BPToken.Motion.Same);
        motionSpecialSame.Add(BPToken.Motion.Same);
        motionSpecialSame.Add(BPToken.Motion.Same);
        motionSpecialSame.Add(BPToken.Motion.Same);
        motionSpecialSame.Add(BPToken.Motion.Same);

        motionSpecialNotOnPrevMotion = new List<BPToken.Motion>();
        motionSpecialNotOnPrevMotion.Add(BPToken.Motion.NotOnPrevMotion);
        motionSpecialNotOnPrevMotion.Add(BPToken.Motion.NotOnPrevMotion);
        motionSpecialNotOnPrevMotion.Add(BPToken.Motion.NotOnPrevMotion);
        motionSpecialNotOnPrevMotion.Add(BPToken.Motion.NotOnPrevMotion);
        motionSpecialNotOnPrevMotion.Add(BPToken.Motion.NotOnPrevMotion);
        motionSpecialNotOnPrevMotion.Add(BPToken.Motion.NotOnPrevMotion);

        motionSpecialNotOnPrevMove = new List<BPToken.Motion>();
        motionSpecialNotOnPrevMove.Add(BPToken.Motion.NotOnPrevMove);
        motionSpecialNotOnPrevMove.Add(BPToken.Motion.NotOnPrevMove);
        motionSpecialNotOnPrevMove.Add(BPToken.Motion.NotOnPrevMove);

        motionSpecialOnPrevMotion = new List<BPToken.Motion>();
        motionSpecialOnPrevMotion.Add(BPToken.Motion.OnPrevMotion);
        motionSpecialOnPrevMotion.Add(BPToken.Motion.OnPrevMotion);
        motionSpecialOnPrevMotion.Add(BPToken.Motion.OnPrevMotion);

        motionSpecialOnPrevMove = new List<BPToken.Motion>();
        motionSpecialOnPrevMove.Add(BPToken.Motion.OnPrevMove);
        motionSpecialOnPrevMove.Add(BPToken.Motion.OnPrevMove);
        motionSpecialOnPrevMove.Add(BPToken.Motion.OnPrevMove);
        motionSpecialOnPrevMove.Add(BPToken.Motion.OnPrevMove);
        motionSpecialOnPrevMove.Add(BPToken.Motion.OnPrevMove);
        motionSpecialOnPrevMove.Add(BPToken.Motion.OnPrevMove);

        motionSpecialEnergyUse = new List<BPToken.Motion>();
        motionSpecialEnergyUse.Add(BPToken.Motion.EnergyUse);
        motionSpecialEnergyUse.Add(BPToken.Motion.EnergyUse);
        motionSpecialEnergyUse.Add(BPToken.Motion.EnergyUse);
        motionSpecialEnergyUse.Add(BPToken.Motion.EnergyUse);
        motionSpecialEnergyUse.Add(BPToken.Motion.EnergyUse);
        motionSpecialEnergyUse.Add(BPToken.Motion.EnergyUse);

        motionSpecialNoEnergyUse = new List<BPToken.Motion>();
        motionSpecialNoEnergyUse.Add(BPToken.Motion.EnergyNoUse);
        motionSpecialNoEnergyUse.Add(BPToken.Motion.EnergyNoUse);
        motionSpecialNoEnergyUse.Add(BPToken.Motion.EnergyNoUse);
        motionSpecialNoEnergyUse.Add(BPToken.Motion.EnergyNoUse);
        motionSpecialNoEnergyUse.Add(BPToken.Motion.EnergyNoUse);
        motionSpecialNoEnergyUse.Add(BPToken.Motion.EnergyNoUse);
    }
    public void SetBPGenerationBlueprint(int difficulty){

    }

    public BPData GenerateBPData(EventKeyword evtKey, StatusKeyword stsKey, TimeKeyword timKey, MotionKeyword moKey, BehaviourKeyword behavKey, int length){
        // BPData data = ScriptableObject.CreateInstance("BPData") as BPData;
        
        BPData data = new BPData();
        // data.conditionEvent = GenerateBPConditionEvent(evtKey);
        // data.conditionStatus = GenerateBPConditionStatus(stsKey);
        // data.conditionTime = GenerateBPConditionTime(timKey);
        // data.condition = GenerateBPCondition(conKey);

        // data.motion = GenerateBPMotion(moKey, length);
        // data.behaviour = GenerateBPBehaviour(behavKey);
        return data;
    }
   
    // private List<object> GenerateBPCondition(ConditionKeyword key){
    //     List<object> bpCondition = new List<object>();
    //     switch(key){
            
    //         //return empty - default;
    //         // bpCondition.Add(BPToken.Essential.StepUp);

    //         break;
    //     }
    //     return bpCondition;
    // }
    private List<BPToken.Motion> GenerateBPMotion(MotionKeyword key, int length){
        List<BPToken.Motion> bpMotion = new List<BPToken.Motion>();
        List<BPToken.Motion> bpMotionCandicate = new List<BPToken.Motion>();
        int bpMotionID = 0;
        switch(key){
            case MotionKeyword.Even:
            bpMotionCandicate.Add(BPToken.Motion.Attack);
            bpMotionCandicate.Add(BPToken.Motion.Strike);
            bpMotionCandicate.Add(BPToken.Motion.Defence);
            bpMotionCandicate.Add(BPToken.Motion.Charge);
            bpMotionCandicate.Add(BPToken.Motion.Avoid);
            bpMotionCandicate.Add(BPToken.Motion.Rest);            
            for (int i = 0; i < length; i++)
            {
                bpMotionID = MathTool.GetRandomIndex(bpMotionCandicate.Count);
                bpMotion.Add(bpMotionCandicate[bpMotionID]);
            }
            ContainLeastOneOffensiveMotion(bpMotion);
            break;

            case MotionKeyword.Random:
            bpMotion.Add(BPToken.Motion.Random);
            break;
            case MotionKeyword.None:
            Debug.LogError("BPGenerator.GenerateBPMotion : No Motion Keyword.");
            //return empty - default;
            break;
        }
        return bpMotion;

        List<BPToken.Motion> ContainLeastOneOffensiveMotion(List<BPToken.Motion> originalMotion){
            bool noOffinsiveMotion = true;
            foreach(BPToken.Motion item in originalMotion){
                if(IsOffensiveMotion(item) == true){
                    noOffinsiveMotion = false;
                    break;
                }
            }
            if(noOffinsiveMotion == true){ // change one motion to offensive if ther is no offensive motion
                int targetID = MathTool.GetRandomIndex(originalMotion.Count);
                List<BPToken.Motion> offiensiveMOtionCandicate = new List<BPToken.Motion>();
                offiensiveMOtionCandicate.Add(BPToken.Motion.Attack);
                offiensiveMOtionCandicate.Add(BPToken.Motion.Strike);
                offiensiveMOtionCandicate.Add(BPToken.Motion.Charge);
                int offensiveMotionID = MathTool.GetRandomIndex(offiensiveMOtionCandicate.Count);
                originalMotion.RemoveAt(targetID);
                originalMotion.Insert(targetID, offiensiveMOtionCandicate[offensiveMotionID]);
            }

            return originalMotion;
        }

        bool IsOffensiveMotion(BPToken.Motion motion){
            switch(motion){
                case BPToken.Motion.Attack:
                case BPToken.Motion.Strike:
                case BPToken.Motion.Charge:                
                return true;
            }
            return false;
        }
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
            m = GameTerms.BPMotion.Rest;
            break;
        }
        return m;
    }
    */
}
