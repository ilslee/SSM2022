using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class BasicChest : Item
    {
        internal float[] maxHealth;
        internal float[] startHealth;
        internal float[] maxEnergy;
        internal float[] startEnergy;
        public BasicChest(int grade = 0): base(grade){
            InitializeNumbers();

            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartGame, SetStatOnStart));
            
        }

        internal virtual void InitializeNumbers(){
            maxHealth =     new float[3]{0f,3f,7f};
            startHealth =   new float[3]{0f,3f,7f};
            maxEnergy =     new float[3]{3f,4f,5f};
            startEnergy =   new float[3]{0f,0f,0f};
        }

        public void SetStatOnStart(Character me, Character other){
            
            // me.maxStat.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Max, maxHealth[grade]));
            // me.maxStat.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Max, maxEnergy[grade]));
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current, startHealth[grade]));
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current, startEnergy[grade]));
            
        }
                
    }
}