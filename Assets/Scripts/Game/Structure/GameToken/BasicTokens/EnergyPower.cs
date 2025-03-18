using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure.token{
    public class EnergyPower : Power
    {
        //Power의 Occation은 각 동작, 혹은 Offensive, Diffensive 적용 가능
        public EnergyPower(GameTerms.TokenOccasion o, bool isOffensive, float v0 = 0f) : base(GameTerms.TokenType.EnergyPower, o, isOffensive, v0){
            isDynamic = true;
        }

        public override void Yeild()
        {
            //액티브 에피션시가 없거나  경우 계산 할 것 없으므로 반환
            if(GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Has(GameTerms.TokenType.Efficieny) == false)return;
            Efficiency eff = GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Find(GameTerms.TokenType.Efficieny) as Efficiency;
            if(eff.isActive == false)return;
            Debug.Log("EnergyPower.Yield  " + value0 + " /  eff.value0 : " + eff.value0);
            //Power에서 역산
            float epConsumption = Mathf.Ceil(value0 / eff.value0) * -1f; // Combine 쉽도록 음수로 변경
            Debug.Log("EnergyPower.Yield  epConsumption : " + epConsumption);
            EPCurrent epConsumptionToken = new EPCurrent(epConsumption);
            GameBoard.Instance().FindCharacter(characterIndex).GetLastPlayData().Combine(epConsumptionToken);
        }
    }
}