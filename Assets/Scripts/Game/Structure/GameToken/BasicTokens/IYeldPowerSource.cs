using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token
{
    public interface IYeldPowerSource
    {
        public MultiTypeToken YieldMTT(GameTerms.Motion m);
    }
}