using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ssm.game.structure{
    public class ModifierToken
    {
        public GameTerms.MTWhen when;
        // public GameTerms.MTWho target;
        public MTCondition condition;
        public GameTerms.MTType type;
        public GameTerms.MTHow how;
        public List<GameTerms.Motion> motionRestriction;
        
        public float value;
        public int duration;
        
        public ModifierToken(GameTerms.MTType t, GameTerms.MTHow how, float v, int d = 0){
            
            type = t;
            this.how = how;
            // target = GameTerms.MTWho.Me;            
            value = v;
            duration = d;
        }
        public ModifierToken(GameTerms.MTType t, MTCondition c){
            type = t;
            condition = c;
        }
        public ModifierToken(GameTerms.MTType t, float v, int d = 0){
            
            type = t;
            how = GameTerms.MTHow.None;
            // target = GameTerms.MTWho.Me;            
            value = v;
            duration = d;
        }
        public void ApplyToStat(Stat stat){
            switch(type){
                case GameTerms.MTType.Health:
                switch(how){
                    case GameTerms.MTHow.Max:
                    case GameTerms.MTHow.Start:
                    case GameTerms.MTHow.GainNextTurn:
                    stat.health += value;
                    break;                  
                }
                break;
                case GameTerms.MTType.Energy:
                switch(how){
                    case GameTerms.MTHow.Max:
                    case GameTerms.MTHow.Start:
                    case GameTerms.MTHow.GainNextTurn:                    
                    stat.energy += value;
                    break;
                }
                break;
                case GameTerms.MTType.SwordPower:
                switch(how){
                    case GameTerms.MTHow.Max:
                    case GameTerms.MTHow.Start:
                    case GameTerms.MTHow.GainNextTurn:  
                    stat.aggression += value;                  
                    break;
                }
                break;
                case GameTerms.MTType.ShieldPower:
                switch(how){
                    case GameTerms.MTHow.Max:
                    case GameTerms.MTHow.Start:
                    case GameTerms.MTHow.GainNextTurn:     
                    stat.solidity += value;               
                    break;
                }
                break;
            }
            
        }
        // public static ModifierToken operator +(ModifierToken a, ModifierToken b){
        //     ModifierToken token = new ModifierToken(a.target, a.type, a.value + b.value, a.duration + b.duration);
        //     //TODO : Modifier Token의 더하기 시나리오 정의
        //     return token;
        // }
        public void Combine(ModifierToken source){
            switch(type){
                case GameTerms.MTType.None:
                break;
                // case GameTerms.MTType.Health:
                // case GameTerms.MTType.Energy:
                // case GameTerms.MTType.SwordPower:
                // case GameTerms.MTType.ShieldPower:
                // case GameTerms.MTType.Power:
                // case GameTerms.MTType.Damage:
                default:
                value+=source.value;
                break;
            }
            
        }
        
        public override string ToString()
        {
            string toStr = type.ToString() + " / " + how.ToString() + "/ v:"+ value.ToString() +"/ d:"+ duration.ToString();
            return toStr;
        }
        public static bool IsSameToekn(ModifierToken a, ModifierToken b){
            if(a.type == b.type && a.how == b.how) return true;
            else return false;
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------
    public class ModifierList : List<ModifierToken>{
        public void CombinModifierList(ModifierList target){
            foreach(var item in target){
                // AddModifierToken(item);
                ModifierToken originalToken = this.Find(m => m.type == item.type && m.how == item.how);
                if(originalToken != null) {
                    originalToken.Combine(item);
                }
                else {
                    this.Add(new ModifierToken(item.type, item.how, item.value));
                }
            }
        }
        public void AddModifierToken(ModifierToken token){
            foreach(var item in this){
                if(ModifierToken.IsSameToekn(item, token)){
                    item.Combine(token);
                    return;
                }
            }            
            this.Add(token);
        }
        /*
        public void ApplyModifierOnCalculation(ModifierList modifier){
            foreach (var item in modifier)
            {
                switch(item.type){
                    case GameTerms.MTType.Health:
                    case GameTerms.MTType.Energy:
                    case GameTerms.MTType.SwordPower:
                    case GameTerms.MTType.ShieldPower:
                    ModifierToken token = FindModifierToken(item.type, GameTerms.MTHow.Current);
                    switch(item.how){
                        case GameTerms.MTHow.GainNextTurn:
                        token.value += item.value;
                        break;
                        case GameTerms.MTHow.LossNextTurn:
                        case GameTerms.MTHow.Loss:
                        // if(HasModifierToken())                        
                        token.value -= item.value;
                        break;
                    }
                    
                    break;
                    
                }
            }
        }
        
        
        public void ApplyModifierOnReady(ModifierList modifier){
            foreach (var item in modifier)
            {
                switch(item.type){
                    case GameTerms.MTType.Health:
                    case GameTerms.MTType.Energy:
                    case GameTerms.MTType.SwordPower:
                    case GameTerms.MTType.ShieldPower:
                    ModifierToken token = FindModifierToken(item.type, GameTerms.MTHow.Current);
                    switch(item.how){
                        case GameTerms.MTHow.Recover:
                        token.value += item.value;
                        break;
                        case GameTerms.MTHow.Decline:
                        token.value -= item.value;
                        break;
                    }
                    
                    break;
                    
                }
            }
        }
        
        public ModifierToken FindModifierToken(GameTerms.MTType type, GameTerms.MTHow how = GameTerms.MTHow.None){
            
            ModifierToken token = this.Find(m => m.type == type && m.how == how);
            if(token == null) {
                return new ModifierToken(GameTerms.MTType.None, GameTerms.MTHow.None ,0);
                // return null;
            }
            else return token;            
        }
        */
        public float FindModifierTokenValue(GameTerms.MTType type, GameTerms.MTHow how = GameTerms.MTHow.None){
            ModifierToken token = this.Find(m => m.type == type && m.how == how);
            if(token == null) {
                return 0f;
            }else{
                return token.value;
            }
        }

        public void ChangeModifierTokenHow(GameTerms.MTType type, GameTerms.MTHow how, GameTerms.MTHow how2){
            ModifierToken token = this.Find(m => m.type == type && m.how == how);
            if(token == null) {
                // this.AddModifierToken(new ModifierToken(type, GameTerms.MTHow.Invalid, 0f));
                return;
            }else{
                token.how = how2;                
            }
        }
        /*
        public ModifierList GetModifiers(GameTerms.MTWhen when){
            ModifierList returnVal = new ModifierList();
            foreach(var item in this){
                if(item.when == when) returnVal.AddModifierToken(item);
            }
            return returnVal;
        }
        */
        public bool HasModifierToken(GameTerms.MTType type, GameTerms.MTHow how = GameTerms.MTHow.None){
            ModifierToken token = this.Find(m => m.type == type && m.how == how );
            if(token == null) {
                return false;
            }else{
                return true;
            }
        }
        // 하나의 MT을 여러개로 분리하여 재정의해야할 때 사용
        public void RearrangeModifiers(ModifierList target){
            foreach(ModifierToken item in this){
                //Steal (SwordPower & ShieldPower)
                if(item.how == GameTerms.MTHow.Steal){
                    this.AddModifierToken(new ModifierToken(item.type, GameTerms.MTHow.Modify, item.value));
                    target.AddModifierToken(new ModifierToken(item.type, GameTerms.MTHow.Modify, item.value * -1f));
                    // this.Remove(item); // Remove는 외부에서 재처리
                }
                
            }
        }
        public void ApplyToStat(Stat stat){
            foreach(var item in this){
                switch(item.type){
                    case GameTerms.MTType.Health:
                    stat.health += item.value;
                    break;
                    case GameTerms.MTType.Energy:
                    stat.energy += item.value;
                    break;
                    case GameTerms.MTType.SwordPower:
                    stat.aggression += item.value;
                    break;
                    case GameTerms.MTType.ShieldPower:
                    stat.solidity += item.value;
                    break;
                }
            }
        }
        public override string ToString()
        {
            string toStr = this.Count.ToString();
            for (int i = 0; i < this.Count; i++)
            {
                toStr += "\n  item "+ i + " : " + this[i].ToString();
            }
            return toStr;
        }
        
    }

}