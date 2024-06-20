using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
namespace ssm.game.structure{
    public class DummyHead : Item
    {
        internal float[] maxHealth;
        internal float[] startHealth;
        internal float[] damageReduction;
        public DummyHead(int grade = 0): base(grade){
            maxHealth =         new float[3]{1f,2f,3f};
            startHealth =       new float[3]{1f,2f,3f};
            damageReduction =   new float[3]{0f,1f,2f};
        }
        public override ModifierList GetModifiersOnStart(){
            ModifierList returnVal = new ModifierList();
            returnVal.Add(new ModifierToken(GameTerms.MTType.Health, GameTerms.MTHow.Max, maxHealth[grade]));
            returnVal.Add(new ModifierToken(GameTerms.MTType.Health, GameTerms.MTHow.Start, startHealth[grade]));
            return returnVal;
        }
        public override float GetDamageReduction(Character me, Character other){
            return damageReduction[grade];
        }
    }
    
}
*/