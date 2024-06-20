using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure{
    public class GameItemCoreSA : Item
    {
        internal float[] maxHealth;
        internal float[] maxEnergy;
        internal float[] maxSwordPower;
        internal float[] maxShieldPower;
        internal float[] startHealth;
        internal float[] startEnergy;
        internal float[] startSwordPower;
        internal float[] startShieldPower;
        public GameItemCoreSA(int grade = 0): base(grade){
            
            grade = 3; //TODO : 나중에 강제 세팅 없앨 것

            maxHealth =     new float[3]{10f, 100f, 1000f};
            startHealth =   new float[3]{10f, 100f, 1000f};
            
            maxEnergy =     new float[3]{2f, 3f, 4f};
            startEnergy =   new float[3]{0f,0f,0f};
            
            maxSwordPower =     new float[3]{1f, 2f, 3f};
            startSwordPower =   new float[3]{0f,0f,0f};
            
            maxShieldPower =     new float[3]{1f, 2f, 3f};
            startShieldPower =   new float[3]{0f,0f,0f};

            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartGame, SetStatOnStart));
        }
        public void SetStatOnStart(Character me, Character other){
            // Debug.Log("GameItemCoreSA.SetStatOnStart");
            // me.maxStat.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Max, maxHealth[grade]));
            // me.maxStat.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Max, maxEnergy[grade]));
            // me.maxStat.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Max, maxSwordPower[grade]));
            // me.maxStat.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Max, maxShieldPower[grade]));
        
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current, startHealth[grade]));
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Energy, GameTerms.StatTokenCategory.Current, startEnergy[grade]));
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.SwordPower, GameTerms.StatTokenCategory.Current, startSwordPower[grade]));
            // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.ShieldPower, GameTerms.StatTokenCategory.Current, startShieldPower[grade]));
            
        }
       
        /*
        public override ModifierList GetInitialStat(){
            ModifierList stat = new ModifierList();
            stat.Add(new ModifierToken(GameTerms.MTType.Health, GameTerms.MTHow.Current, 1000));
            stat.Add(new ModifierToken(GameTerms.MTType.Energy,GameTerms.MTHow.Current, 0));
            stat.Add(new ModifierToken(GameTerms.MTType.SwordPower,GameTerms.MTHow.Current, 0));
            stat.Add(new ModifierToken(GameTerms.MTType.ShieldPower,GameTerms.MTHow.Current, 0));

            stat.Add(new ModifierToken(GameTerms.MTType.Health, GameTerms.MTHow.Max, 1000));
            stat.Add(new ModifierToken(GameTerms.MTType.Energy, GameTerms.MTHow.Max, 2));
            stat.Add(new ModifierToken(GameTerms.MTType.SwordPower, GameTerms.MTHow.Max, 1));
            stat.Add(new ModifierToken(GameTerms.MTType.ShieldPower, GameTerms.MTHow.Max, 1));
            return stat;
        }
        */
    }
}