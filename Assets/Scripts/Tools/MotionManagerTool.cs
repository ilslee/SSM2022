using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.game.structure{
    public static class MotionManagerTool
    {
        public static GameTerms.Motion GetMotionForMotionCheck(GameTerms.Motion m = GameTerms.Motion.None){
            List<GameTerms.Motion> pool = new List<GameTerms.Motion>();
            pool.Add(GameTerms.Motion.Attack);
            pool.Add(GameTerms.Motion.Strike);
            pool.Add(GameTerms.Motion.Defence);
            pool.Add(GameTerms.Motion.Charge);
            pool.Add(GameTerms.Motion.Avoid);
            pool.Add(GameTerms.Motion.Taunt);
            if(m != GameTerms.Motion.None) pool.Add(m);
            int count = pool.Count;
            return pool[MathTool.GetRandomIndex(pool.Count)];
        }
    }
}