using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class BasicLegs : Item
    {
        internal float[] avoidSteal;
        internal float[] avoidEnergeConversionRate;
        internal float[] tauntSteal;
        
        public BasicLegs(int grade = 0): base(grade){
            InitializeNumbers();
            
            
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionAvoid, CalculateAvoid));
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnMotionTaunt, CalculateTaunt));
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnExceedEnergyTakeBack, CalculateExceedEnergyTakeBack));
            // stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnConsequence, CalculateConseqence));
        }
        internal virtual void InitializeNumbers(){
            avoidSteal = new float[3]{1f, 2f, 3f};
            avoidEnergeConversionRate = new float[3]{1f, 1f, 1f};
            tauntSteal = new float[3]{1f, 2f, 3f};
        }


        internal void CalculateAvoid(Character me, Character other){
            // float energyConsumption = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current).value0;
            // float avoidPower = Mathf.Floor(energyConsumption * avoidEnergeConversionRate[grade]);
            
            // StatTokenList target = me.expectation[(int)GameTerms.Motion.Avoid];
            // target.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Defensive, avoidPower));
            // target.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Loss, energyConsumption));
            // target.Combine(new StatToken(GameTerms.StatTokenType.ExceedEnergyTakeBack, GameTerms.StatTokenCategory.Current));
            // target.Combine(new StatToken(GameTerms.StatTokenType.InvalidColisionByStrike, GameTerms.StatTokenCategory.Current));
            // target.Combine(new StatToken(GameTerms.StatTokenType.StealSwordPower, GameTerms.StatTokenCategory.Give, avoidSteal[grade]));
            // RecoverEnergy(target);
        }
        internal void CalculateTaunt(Character me, Character other){
            // StatTokenList target = me.expectation[(int)GameTerms.Motion.Taunt];
            // target.Combine(new StatToken(GameTerms.StatTokenType.StealSwordPower, GameTerms.StatTokenCategory.Give, tauntSteal[grade]));
            // target.Combine(new StatToken(GameTerms.StatTokenType.StealShieldPower, GameTerms.StatTokenCategory.Give, tauntSteal[grade]));
            // RecoverEnergy(target);
        }

        private void RecoverEnergy(StatTokenList target ){
            target.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.GainNextTurn, 1f));
        }
        private void CalculateExceedEnergyTakeBack(Character me, Character other){
            // if(me.GetLastPlayData().motion != GameTerms.Motion.Avoid || me.GetLastPlayData().collision != true) return; //모션이 Avoid가 아니거나 충돌이 없으면 중단

            // StatTokenList myTarget = me.GetLastPlayData().expectation[(int)me.GetLastPlayData().motion];
            // StatTokenList otherTarget = other.GetLastPlayData().expectation[(int)other.GetLastPlayData().motion];
            
            // float powerExcess = myTarget.Find(GameTerms.StatTokenType.Power).value0 - otherTarget.Find(GameTerms.StatTokenType.Power).value0;
            // // 초과에너지 회복이 없거나 && 내가 이기지 못하면(=초과에너지 없음) 중단
            // if(myTarget.Has(GameTerms.StatTokenType.ExceedEnergyTakeBack)==false || powerExcess <= 0) return; 

            // float reversedAvoidEnergeConversionRate = 1 / avoidEnergeConversionRate[grade];
            // float energyConsumptionExcess = Mathf.Ceil(powerExcess * reversedAvoidEnergeConversionRate);
            // // float energyConsumption = myTarget.Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Loss).value0;
            // myTarget.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Gain, energyConsumptionExcess));

            
        }
        // public void OnCalculation(Character me, Character other){
        //     if(GameBoard.Phase == GameTerms.Phase.Expectation){
        //         CalculateAvoid(me, me.expectation[(int)GameTerms.Motion.Avoid]);
        //         CalculateTaunt(me, me.expectation[(int)GameTerms.Motion.Taunt]);

        //         SetAvoidAdjustment(me, me.expectation[(int)GameTerms.Motion.Avoid]);
        //         SetTauntAdjustment(me, me.expectation[(int)GameTerms.Motion.Taunt]);
        //     }else if(GameBoard.Phase == GameTerms.Phase.Calculate){
        //         if(me.GetLastPlayData().motion == GameTerms.Motion.Avoid) {
        //             CalculateAvoid(me, me.GetLastPlayData().token);
        //             SetAvoidAdjustment(me, me.GetLastPlayData().token);
        //         }
        //         else if(me.GetLastPlayData().motion == GameTerms.Motion.Taunt) {
        //             CalculateTaunt(me, me.GetLastPlayData().token);
        //             SetTauntAdjustment(me, me.GetLastPlayData().token);
        //         }
        //     }
        // }

        // internal void CalculateAvoid(Character me, StatTokenList address){
        //     float energyConsumption = me.GetLastPlayData().token.Find(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current).value0;
        //     float energyConversionRate = avoidEnergeConversionRate[grade];
        //     float avoidPower = Mathf.Floor(energyConsumption * energyConversionRate);
        //     address.Combine(new StatToken(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Defensive, avoidPower));
        //     address.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Loss, energyConsumption));
        // }
        // internal void CalculateTaunt(Character me, StatTokenList address){
        //     // Taunt는 기능 없음
        // }

        // internal void SetAvoidAdjustment(Character me, StatTokenList address){
        //     address.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.GainNextTurn,1f));
        // }
        // internal void SetTauntAdjustment(Character me, StatTokenList address){
        //     address.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.GainNextTurn,1f));
        // }

        
        /*
        internal void CalculateConseqence(Character me, Character other){
            if(me.GetLastPlayData().motion == GameTerms.Motion.Avoid){
                if(me.GetLastPlayData().collision == false && other.GetLastPlayData().token.Has(GameTerms.StatTokenType.Power, GameTerms.StatTokenCategory.Offensive)){
                    //상대의 모션에 따른 스탯 훔침
                    if(other.GetLastPlayData().motion == GameTerms.Motion.Attack || other.GetLastPlayData().motion == GameTerms.Motion.Strike){
                        other.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.LossNextTurn, avoidSteal[grade]));
                        me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.GainNextTurn, avoidSteal[grade]));
                    }else if(other.GetLastPlayData().motion == GameTerms.Motion.Defence || other.GetLastPlayData().motion == GameTerms.Motion.Charge)
                        other.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.LossNextTurn, avoidSteal[grade]));
                        me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.GainNextTurn, avoidSteal[grade]));
                    }
                
            }
            else if(me.GetLastPlayData().motion == GameTerms.Motion.Taunt){
                if(me.GetLastPlayData().collision == false){
                    other.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.LossNextTurn, tauntSteal[grade]));
                    other.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.LossNextTurn, tauntSteal[grade]));
                    me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.GainNextTurn, tauntSteal[grade]));
                    me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.GainNextTurn, tauntSteal[grade]));
                }
            }
        }*/

        // public void GetPowerSource(Character me, Character other){
        //     //Avoid
        //     me.powerSource[(int)GameTerms.Motion.Avoid].Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.ConversionRate, avoidEnergeConversionRate[grade]));
        //     //Taunt는 없음
        // }
    }
}