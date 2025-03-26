using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.game.structure;
namespace ssm.game.appearance{
    public class HPGaugeManager : GaugeManager
    {
        internal override float GetValveFromData()
        {
            // return base.GetValveFromData();
            return GameBoard.Instance().FindCharacter(characterIndex).SearchToken(GameTerms.TokenType.HPCurrent).value0;
        }
    }
}
