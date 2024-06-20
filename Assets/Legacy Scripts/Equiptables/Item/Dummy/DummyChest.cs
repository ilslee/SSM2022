using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
namespace ssm.game.structure{
    public class DummyChest : Item
    {
        internal float[] maxHealth;
        internal float[] startHealth;
        internal float[] maxEnergy;
        internal float[] startEnergy;
        public DummyChest(int grade = 0): base(grade){
            maxHealth =     new float[3]{0f,3f,7f};
            startHealth =   new float[3]{0f,3f,7f};
            maxEnergy =       new float[3]{3f,4f,5f};
            startEnergy =     new float[3]{0f,0f,0f};

            
        }
        public override ModifierList GetModifiersOnStart(){
            ModifierList returnVal = new ModifierList();
            // returnVal.Add(new ModifierToken(GameTerms.MTType.Health, GameTerms.MTHow.Max, maxHealth[grade]));
            // returnVal.Add(new ModifierToken(GameTerms.MTType.Energy, GameTerms.MTHow.Max, maxEnergy[grade]));

            // returnVal.Add(new ModifierToken(GameTerms.MTType.Health, GameTerms.MTHow.Start, startHealth[grade]));
            // returnVal.Add(new ModifierToken( GameTerms.MTType.Energy, GameTerms.MTHow.Start, startEnergy[grade]));
            returnVal.Add(new ModifierToken(GameTerms.MTType.Health, ModifierTokenCondition.OnStart));
            return returnVal;
        }
        
    }
}
*/