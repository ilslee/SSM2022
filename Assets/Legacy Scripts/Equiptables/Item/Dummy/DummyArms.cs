using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
namespace ssm.game.structure{
    public class DummyArms : Item
    {
        internal float[] maxSwordPower;
        internal float[] startSwordPower;
        internal float[] maxShieldPower;
        internal float[] startShieldPower;
        public DummyArms(int grade = 0): base(grade){
            maxSwordPower =     new float[3]{2f,3f,4f};
            startSwordPower =   new float[3]{0f,0f,0f};
            maxShieldPower =       new float[3]{2f,3f,4f};
            startShieldPower =     new float[3]{0f,0f,0f};

        }
        
        public override ModifierList GetModifiersOnStart(){
            ModifierList returnVal = new ModifierList();
            returnVal.Add(new ModifierToken(GameTerms.MTType.SwordPower, GameTerms.MTHow.Max, maxSwordPower[grade]));
            returnVal.Add(new ModifierToken(GameTerms.MTType.ShieldPower, GameTerms.MTHow.Max, maxShieldPower[grade]));

            returnVal.Add(new ModifierToken(GameTerms.MTType.SwordPower, GameTerms.MTHow.Start, startSwordPower[grade]));
            returnVal.Add(new ModifierToken( GameTerms.MTType.ShieldPower, GameTerms.MTHow.Start, startShieldPower[grade]));
            return returnVal;
        }
        
    }
}
*/