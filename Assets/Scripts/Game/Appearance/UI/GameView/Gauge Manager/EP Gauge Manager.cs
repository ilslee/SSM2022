using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.appearance{
    public class EPGaugeManager : GaugeManager
    {
        internal override float GetValveFromData()
        {
            // return base.GetValveFromData();
            // return GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.EPCurrent).value0;
            return 0f;
        }
    }
}