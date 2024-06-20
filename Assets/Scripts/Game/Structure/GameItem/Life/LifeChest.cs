using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public class LifeChest : BasicChest
    {
        public float[] healthRecoveryTurnCounter;
        public LifeChest(int grade = 0): base(grade){
            stFactory.Add(new StatTokenFactory(StatTokenFactory.OperateType.OnStartTurn, RecoverHealthOccasionally));            
        }
        internal override void InitializeNumbers()
        {
            maxHealth =     new float[3]{3f,7f,11f};
            startHealth =   new float[3]{3f,7f,11f};
            maxEnergy =     new float[3]{3f,4f,5f};
            startEnergy =   new float[3]{0f,0f,0f};

            healthRecoveryTurnCounter = new float[3]{8f, 6f, 4f};
        }
        private void RecoverHealthOccasionally(Character me, Character Other){
            if((float)GameBoard.Turn % healthRecoveryTurnCounter[grade] == 0f){
                // me.GetLastPlayData().token.Combine(new StatToken(GameTerms.StatTokenType.Health, GameTerms.StatTokenCategory.Current, 1f));
            }
        }
    }
}