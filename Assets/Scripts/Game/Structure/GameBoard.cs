using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ssm.data;
using System;

namespace ssm.game.structure{
        
    public class GameBoard : MonoBehaviour {
       
        public static int Turn = 0;
        public static int MaxTurn = 0;
        public static float TurnTime = 0f;
        public static GameTerms.Phase Phase = GameTerms.Phase.None;
        
        //Character Data 고정
        [SerializeField]
        public Character character1;
        [SerializeField]
        public Character character2;
        
        //초기 값 세팅
        public void Initialize(PlayableCharacter c1, PlayableCharacter c2){
            // Clone & Convert Character data
            character1 = new Character(c1,1);   
            character2 = new Character(c2,2);  
            //Set Max Stat and Start Stat      
            // character1.item.Operate(StatTokenFactory.OperateType.OnStartGame, character1, character2);
            // character2.item.Operate(StatTokenFactory.OperateType.OnStartGame, character2, character1);
            character1.GetLastPlayData().token.OnGameStart(character1, character2);
            character2.GetLastPlayData().token.OnGameStart(character2, character1);
        }
       
        //------------------------------[Ready]------------------------------
        public void AddPlayData(){
            character1.AddPlayData();
            character2.AddPlayData();
        }

        public void CalculateOnTurnStart(){
            character1.GetLastPlayData().token.OnTurnStart(character1, character2);
            character2.GetLastPlayData().token.OnTurnStart(character2, character1);
            
        }
        public void CalculateExpectations(){
            character1.expectation.Reset(character1,character2);
            character2.expectation.Reset(character2,character1);
        }
        //------------------------------[Pose]------------------------------
        public void ProcessMotions(){
            //Getting Motion From BP
            character1.GetLastPlayData().motion = character1.behaviourPattern.Calculate(character1, character2);
            character2.GetLastPlayData().motion = character2.behaviourPattern.Calculate(character2, character1);

            //Get Token via Motion
            character1.GetLastPlayData().token.AddRange(character1.expectation.CloneExpectationViaMotion(character1.GetLastPlayData().motion));
            character2.GetLastPlayData().token.AddRange(character2.expectation.CloneExpectationViaMotion(character2.GetLastPlayData().motion));
        }
        

        //------------------------------[Calculate]------------------------------
        public void CalcuateCollision(){
            GameTerms.Motion myMotion = character1.GetLastPlayData().motion;
            GameTerms.Motion otherMotion = character2.GetLastPlayData().motion;
            bool isCollide = false;
            switch(myMotion){
                case GameTerms.Motion.None:
                    switch(otherMotion){
                        case GameTerms.Motion.None:
                        break;
                        case GameTerms.Motion.Attack:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Strike:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Defence:
                        break;
                        case GameTerms.Motion.Charge:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Avoid:
                        break;
                        case GameTerms.Motion.Taunt:
                        break;
                    }
                break;
                case GameTerms.Motion.Attack:
                    switch(otherMotion){
                        case GameTerms.Motion.None:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Attack:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Strike:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Defence:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Charge:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Avoid:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Taunt:
                        isCollide = true;
                        break;
                    }
                break;
                case GameTerms.Motion.Strike:
                    switch(otherMotion){
                        case GameTerms.Motion.None:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Attack:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Strike:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Defence:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Charge:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Avoid:
                        break;
                        case GameTerms.Motion.Taunt:
                        isCollide = true;
                        break;
                    }
                break;
                case GameTerms.Motion.Defence:
                    switch(otherMotion){
                        case GameTerms.Motion.None:
                        break;
                        case GameTerms.Motion.Attack:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Strike:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Defence:
                        break;
                        case GameTerms.Motion.Charge:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Avoid:
                        break;
                        case GameTerms.Motion.Taunt:
                        break;
                    }
                break;
                case GameTerms.Motion.Charge:
                    switch(otherMotion){
                        case GameTerms.Motion.None:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Attack:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Strike:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Defence:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Charge:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Avoid:                            
                        isCollide = false;
                        break;
                        case GameTerms.Motion.Taunt:
                        isCollide = true;
                        break;
                    }
                break;
                case GameTerms.Motion.Avoid:
                    switch(otherMotion){
                        case GameTerms.Motion.None:
                        break;
                        case GameTerms.Motion.Attack:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Strike:                            
                        break;
                        case GameTerms.Motion.Defence:
                        break;
                        case GameTerms.Motion.Charge:
                        // isCollide = true;
                        break;
                        case GameTerms.Motion.Avoid:
                        break;
                        case GameTerms.Motion.Taunt:
                        break;
                    }
                break;
                case GameTerms.Motion.Taunt:
                    switch(otherMotion){
                        case GameTerms.Motion.None:
                        break;
                        case GameTerms.Motion.Attack:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Strike:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Defence:                            
                        break;
                        case GameTerms.Motion.Charge:
                        isCollide = true;
                        break;
                        case GameTerms.Motion.Avoid:                            
                        break;
                        case GameTerms.Motion.Taunt:
                        break;
                    }
                break;
            }
            // TODO : 추가적인 충돌 회피상황 있으면 정리(Avoid 등?)
            Debug.Log("Collision : " + isCollide);
            character1.GetLastPlayData().collision = isCollide;
            character2.GetLastPlayData().collision = isCollide;
        }
        
       
        
        public void CalculateConseqence(){
            
            character1.GetLastPlayData().token.ApplyToken(Token.Category.SwordPower);
            character2.GetLastPlayData().token.ApplyToken(Token.Category.SwordPower);
            character1.GetLastPlayData().token.ApplyToken(Token.Category.ShieldPower);
            character2.GetLastPlayData().token.ApplyToken(Token.Category.ShieldPower);
            character1.GetLastPlayData().token.Cap(character1);
            character2.GetLastPlayData().token.Cap(character2);

            //ConvertPower
            ConvertPower(character1);
            ConvertPower(character2);

            //CalculateDamage
            CalcuateDamage(character1, character2);
            CalcuateDamage(character2, character1);
            
            
            
            //EnergeConsumption TakeBack
            ConvertEnergyConsumptionTakeBakcToEnergyGain(character1);
            ConvertEnergyConsumptionTakeBakcToEnergyGain(character2);

            
            //Damage To Health Loss
            ConvertDamageToHealthLoss(character1);
            ConvertDamageToHealthLoss(character2);


            //Manage Poison(TODO)

            
            //Convert EnergyGainWithNoCollision to GainNextTurn
            ConvertEnergeGainWithNoCollitionToEnergyGainNext(character1);
            ConvertEnergeGainWithNoCollitionToEnergyGainNext(character2);

            //Apply Health/Energy Gain and Loss to Current
            character1.GetLastPlayData().token.ApplyToken(Token.Category.Health);
            character2.GetLastPlayData().token.ApplyToken(Token.Category.Health);
            
            character1.GetLastPlayData().token.ApplyToken(Token.Category.Energy);
            character2.GetLastPlayData().token.ApplyToken(Token.Category.Energy);
            
            character1.GetLastPlayData().token.Cap(character1);
            character2.GetLastPlayData().token.Cap(character2);

            //------------------------------------------------------------[Organize at last]
            character1.GetLastPlayData().token.Organize();
            character2.GetLastPlayData().token.Organize();
        }

        private void ModifyGaugePower(Character me){
            /*
            Token.Occasion occatsionMotion = GetOccationMotion(me.GetLastPlayData().motion);
            Token.Occasion occatsionMove = GetOccationSSM(me.GetLastPlayData().motion);
            
            float swordPowerGain = GetValueFromToken(me, me.token, Token.Category.SwordPower, Token.Behaviour.Gain);
            float swordPowerLoss = GetValueFromToken(me, me.token, Token.Category.SwordPower, Token.Behaviour.Loss);
            float shieldPowerGain = GetValueFromToken(me, me.token, Token.Category.ShieldPower, Token.Behaviour.Gain);
            float shieldPowerLoss = GetValueFromToken(me, me.token, Token.Category.ShieldPower, Token.Behaviour.Loss);
            
            Token swordPowerGainTK = new Token(Token.Category.SwordPower, Token.Behaviour.Gain);
            swordPowerGainTK.value0 = swordPowerGain;
            Token swordPowerLossTK = new Token(Token.Category.SwordPower, Token.Behaviour.Loss);
            swordPowerLossTK.value0 = swordPowerLoss;
            Token shieldPowerGainTK = new Token(Token.Category.ShieldPower, Token.Behaviour.Gain);
            shieldPowerGainTK.value0 = shieldPowerGain;
            Token shieldPowerLossTK = new Token(Token.Category.ShieldPower, Token.Behaviour.Loss);
            shieldPowerLossTK.value0 = shieldPowerLoss;
            // Debug.Log("Gameboard.ModifyGaugePower : " + swordPowerGain.ToString() + "/" + swordPowerLoss.ToString()  + "//" + 
            // shieldPowerGain.ToString() + "/" + shieldPowerLoss.ToString());
            me.GetLastPlayData().token.Combine(swordPowerGainTK);
            me.GetLastPlayData().token.Combine(swordPowerLossTK);
            me.GetLastPlayData().token.Combine(shieldPowerGainTK);
            me.GetLastPlayData().token.Combine(shieldPowerLossTK);
            */
        }
        private void ConvertPower(Character me){
            /*
            Token.Occasion motion = GetOccationMotion(me.GetLastPlayData().motion);
            Token.Occasion move = GetOccationSSM(me.GetLastPlayData().motion);
            Token.Category gaugeID = GetPowerGaugeTarget(me.GetLastPlayData().motion);
            Token.Behaviour powerType = GetPowerType(me.GetLastPlayData().motion);
            
            //1. 에너지 변환율
            // float energeConvertionRateMotion = me.token.Find(Token.Category.EnergyConversion, Token.Behaviour.Rate, motion).value0;
            // float energeConvertionRateMove = me.token.Find(Token.Category.EnergyConversion, Token.Behaviour.Rate, move).value0;
            Token energeConvertionRateTK = new Token(Token.Category.EnergyConversion, Token.Behaviour.Rate);
            energeConvertionRateTK.value0 = GetValueFromToken(me, me.token, Token.Category.EnergyConversion, Token.Behaviour.Rate);
            
            //2-1. 에너지 최대치
            float energeConsumptionionMax = GetValueFromToken(me, me.token, Token.Category.EnergyConversion, Token.Behaviour.Max);
            //2-2. 에너지 현재값
            float currentEnergy = me.GetLastPlayData().token.Find(Token.Category.Energy, Token.Behaviour.Current).value0;
            float energyConsumption = Mathf.Min(currentEnergy, energeConsumptionionMax);
            //2-3. 에너지 소모량
            Token energeConsumptionTK = new Token(Token.Category.Energy, Token.Behaviour.Loss);
            energeConsumptionTK.value0 = energyConsumption;
            
            //2-3. 에너지에서 오는 파워
            Token powerFromEnergyTK = new Token(Token.Category.Power, Token.Behaviour.Energy);
            powerFromEnergyTK.value0 = Mathf.Min(energeConvertionRateTK.value0 * energeConsumptionTK.value0);
            
            //3. 게이지에서 오는 파워
            float gauge = me.GetLastPlayData().token.Find(gaugeID, Token.Behaviour.Current).value0;
            Token powerFromGaugeTK = new Token(Token.Category.Power, Token.Behaviour.Gauge);
            powerFromGaugeTK.value0 = gauge;
            
            //4. 추가 파워            
            //TODO : 이거저거 추가 가능
            Token additionalPowerTK = new Token(Token.Category.Power, Token.Behaviour.Additional);
            additionalPowerTK.value0 = GetValueFromToken(me, me.token, Token.Category.Power, Token.Behaviour.Additional);

            //5. 기본 파워
            Token powerBaseTK = new Token(Token.Category.Power, Token.Behaviour.Base);
            powerBaseTK.value0 = GetValueFromToken(me, me.token, Token.Category.Power, Token.Behaviour.Base);;

            Token powerTK = new Token(Token.Category.Power, powerType);
            powerTK.value0 = powerBaseTK.value0 + powerFromGaugeTK.value0 + powerFromEnergyTK.value0 + additionalPowerTK.value0;
            // Debug.Log("Power (" + powerTK.behaviour + "/W"+ powerTK.value0 + ") b: " + powerBaseTK.value0 + " / e: " + powerFromEnergyTK.value0 + " / g: " + powerFromGaugeTK.value0 + " / a: " + additionalPowerTK.value0);
            //PlayData에 추가
            me.GetLastPlayData().token.Combine(energeConvertionRateTK);
            me.GetLastPlayData().token.Combine(energeConsumptionTK);
            me.GetLastPlayData().token.Combine(powerFromEnergyTK);
            me.GetLastPlayData().token.Combine(powerFromGaugeTK);
            me.GetLastPlayData().token.Combine(additionalPowerTK);
            me.GetLastPlayData().token.Combine(powerBaseTK);
            me.GetLastPlayData().token.Combine(powerTK);
            */
        }

        private float GetValueFromToken(Character me, TokenList target, Token.Category c, Token.Behaviour b){
            float returnVal = 0f;
            float valueMotion = target.Find(c, b, GetOccationMotion(me.GetLastPlayData().motion)).value0;
            float valueMove = target.Find(c, b, GetOccationSSM(me.GetLastPlayData().motion)).value0;
            returnVal = valueMotion + valueMove;
            return returnVal;
        }

        private bool GetAvailabilityFromToken(Character me, TokenList target, Token.Category c, Token.Behaviour b){
            bool availabilityMotion = target.Has(c, b, GetOccationMotion(me.GetLastPlayData().motion));
            bool availabilityMove = target.Has(c, b, GetOccationSSM(me.GetLastPlayData().motion));
            if(availabilityMove == true || availabilityMove == true) return true;
            else return false;
        }
        private void CalcuateDamage(Character me, Character other){
            /*
            float myPower = me.GetLastPlayData().token.Find(Token.Category.Power, GetPowerType(me.GetLastPlayData().motion)).value0;
            float otherPower = other.GetLastPlayData().token.Find(Token.Category.Power, GetPowerType(other.GetLastPlayData().motion)).value0;
            float damageGive = 0f;
            switch(GetPowerType(me.GetLastPlayData().motion)){
                case Token.Behaviour.Offensive:
                damageGive = myPower;
                if(myPower > otherPower) damageGive += GetValueFromToken(me, me.token, Token.Category.Damage, Token.Behaviour.Gain);
                Token damageGiveTk = new Token(Token.Category.Damage, Token.Behaviour.Give);
                damageGiveTk.value0 = damageGive;
                //최대 데미지로 토큰 배분
                me.GetLastPlayData().token.Combine(damageGiveTk);
                Token damageTakeTk = new Token(Token.Category.Damage, Token.Behaviour.Take);
                damageTakeTk.value0 = damageGive;
                other.GetLastPlayData().token.Combine(damageTakeTk);
                
                break;
                case Token.Behaviour.Defensive:
                break;
            }
            //Defence쪽에서 감소 적용: 이건 상대의 공방과 상관 없이 적용
            Token damageLossTK = new Token(Token.Category.Damage, Token.Behaviour.Loss);
            damageLossTK.value0 = otherPower;
            other.GetLastPlayData().token.Combine(damageLossTK);
            if(damageGive > otherPower){
                Token damageRedueTK = new Token(Token.Category.Damage, Token.Behaviour.Reduce);
                damageRedueTK.value0 = GetValueFromToken(other, other.token, Token.Category.Damage, Token.Behaviour.Reduce);
                other.GetLastPlayData().token.Combine(damageRedueTK);
            }
            */
        }
        
        private void ConvertDamageToHealthLoss(Character me){
            float damageTake = me.GetLastPlayData().token.Find(Token.Category.Damage, Token.Behaviour.Take).value0;
            float damageLoss = me.GetLastPlayData().token.Find(Token.Category.Damage, Token.Behaviour.Loss).value0;
            float damageReduce = me.GetLastPlayData().token.Find(Token.Category.Damage, Token.Behaviour.Reduce).value0;
            float finalDamage = damageTake - damageLoss - damageReduce;
            // Debug.Log("Gameterms.ConvertDamageToHealthLoss - finalDamage : " + damageTake.ToString() + " - " + damageLoss + " = " +finalDamage.ToString());
            if(finalDamage > 0f){
                Token healthLossTk = new Token(Token.Category.Health, Token.Behaviour.Loss);
                healthLossTk.value0 = finalDamage;
                me.GetLastPlayData().token.Combine(healthLossTk);
            }
        }
        
        private void ConvertEnergyConsumptionTakeBakcToEnergyGain(Character me){
            /*
            if(GetAvailabilityFromToken(me, me.token, Token.Category.Energy, Token.Behaviour.TakeBackExceed) == false)return;
            

            //상대방의 최대 데미지를 Damage, Loss와 ConvertedPower로 막는다
            //상대방의 최대 데미지에서 Damage, Loss 분을 제외
            float damageTake = me.GetLastPlayData().token.Find(Token.Category.Damage, Token.Behaviour.Take).value0;            
            float damageLoss = me.GetLastPlayData().token.Find(Token.Category.Damage, Token.Behaviour.Loss).value0;
            float damageReduce = me.GetLastPlayData().token.Find(Token.Category.Damage, Token.Behaviour.Reduce).value0;
            float actualDamage = damageTake - damageLoss - damageReduce;
            //나머지를 막기 위해 필요한 에너지 산줄(a)
            //실제 사용한 에너지에서 (a)를 제외
            // Debug.Log("-- TakeBalck Available!! -- actualDamage : " + actualDamage.ToString() + "/ damageTake : " + damageTake.ToString());
            if(actualDamage > 0f) return; // 실제 데미지가 0 이상이면(변환할 게 없음) 종료.
            float conversionValue = 0f;
            if(damageTake <= 0f) { // 받은 공격이 없다면(싱대방이 Power, Deffencive)
                conversionValue = damageLoss; // 사용 에너지량 전체를 회복
            }else{
                conversionValue = MathF.Abs(actualDamage); // 음수 데미지 양수로 전환
            }            
            // Debug.Log("-- TakeBalck Happens!! -- value : " + conversionValue.ToString());
            float conversionRate = me.GetLastPlayData().token.Find(Token.Category.EnergyConversion, Token.Behaviour.Rate).value0;
            if(conversionRate <= 0f) return; // 에너지를 사용하는 동작이 아니면 반환
            float conversionEnergyMax = Mathf.Floor(conversionValue /  conversionRate);
            //최대 회복량과 실제 사용양중 적은 쪽을 반환
            float energyUsage = me.GetLastPlayData().token.Find(Token.Category.Energy, Token.Behaviour.Loss).value0;
            float conversionEnergy = Mathf.Min(conversionEnergyMax, energyUsage);
            // Debug.Log("-- TakeBalck Result!! -- revocer : " + conversionEnergy.ToString() + "  / usage : " + energyUsage.ToString());
            if(conversionEnergy > 0f){
                Token energyGain = new Token(Token.Category.Energy, Token.Behaviour.GainNextTurn);
                energyGain.value0 = conversionEnergy;
                me.GetLastPlayData().token.Combine(energyGain);
            }
            */
        }

        private void ConvertEnergeGainWithNoCollitionToEnergyGainNext(Character me){
            /*
            if(me.GetLastPlayData().collision == true)return;
            float energeGainWithNoCollition = GetValueFromToken(me, me.token, Token.Category.Energy, Token.Behaviour.GainWithNoCollision);            
            if(energeGainWithNoCollition <= 0f)return;
            // Debug.Log("Gameboard.ConvertEnergeGainWithNoCollitionToEnergyGainNext Triggered : " + (energeGainWithNoCollition).ToString());
            Token EnergyGainTK = new Token(Token.Category.Energy, Token.Behaviour.GainNextTurn);
            EnergyGainTK.value0 = energeGainWithNoCollition;
            me.GetLastPlayData().token.Combine(EnergyGainTK);
            */
        }

        private Token.Occasion GetOccationMotion(GameTerms.Motion m){
            Token.Occasion returnVal = Token.Occasion.None;
            switch(m){                
                case GameTerms.Motion.None:
                returnVal = Token.Occasion.OnMotionNone;
                break;
                case GameTerms.Motion.Attack:
                returnVal = Token.Occasion.OnMotionAttack;
                break;
                case GameTerms.Motion.Strike:
                returnVal = Token.Occasion.OnMotionStrike;
                break;
                case GameTerms.Motion.Defence:
                returnVal = Token.Occasion.OnMotionDefence;
                break;
                case GameTerms.Motion.Charge:
                returnVal = Token.Occasion.OnMotionCharge;
                break;
                case GameTerms.Motion.Avoid:
                returnVal = Token.Occasion.OnMotionAvoid;
                break;
                case GameTerms.Motion.Taunt:
                returnVal = Token.Occasion.OnMotionTaunt;
                break;
            }
            return returnVal;
        }        
        private Token.Occasion GetOccationSSM(GameTerms.Motion m){
            Token.Occasion returnVal = Token.Occasion.None;
            switch(m){                
                case GameTerms.Motion.None:
                returnVal = Token.Occasion.OnMotionNone;
                break;
                case GameTerms.Motion.Attack:
                case GameTerms.Motion.Strike:
                returnVal = Token.Occasion.OnMotionSword;
                break;
                case GameTerms.Motion.Defence:
                case GameTerms.Motion.Charge:
                returnVal = Token.Occasion.OnMotionShield;
                break;
                case GameTerms.Motion.Avoid:
                case GameTerms.Motion.Taunt:
                returnVal = Token.Occasion.OnMotionMove;
                break;
            }
            return returnVal;
        }
        private Token.Behaviour GetPowerType(GameTerms.Motion m){
            Token.Behaviour returnVal = Token.Behaviour.Defensive;
            switch(m){                
                case GameTerms.Motion.None:
                case GameTerms.Motion.Defence:
                case GameTerms.Motion.Avoid:
                case GameTerms.Motion.Taunt:
                returnVal = Token.Behaviour.Defensive;
                break;
                case GameTerms.Motion.Attack:
                case GameTerms.Motion.Strike:
                case GameTerms.Motion.Charge:
                returnVal = Token.Behaviour.Offensive;
                break;
                
            }
            return returnVal;
        }        
        private Token.Category GetPowerGaugeTarget(GameTerms.Motion m){
            Token.Category returnVal = Token.Category.None;
            switch(m){                
                case GameTerms.Motion.None:
                case GameTerms.Motion.Avoid:
                case GameTerms.Motion.Taunt:
                returnVal = Token.Category.None;
                break;
                case GameTerms.Motion.Attack:
                case GameTerms.Motion.Strike:
                returnVal = Token.Category.SwordPower;
                break;
                
                case GameTerms.Motion.Defence:
                case GameTerms.Motion.Charge:
                returnVal = Token.Category.ShieldPower;
                break;                
            }
            return returnVal;
        }
        
        
    }
    
    

   


}