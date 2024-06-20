using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.structure{
    public class Stat
    {
        public float health; //Power 계산시에는 Base Power로 이용
        public float energy;
        public float aggression;
        public float solidity;
        public Stat(float health = 0,float energy = 0, float aggression = 0, float solidity = 0){
            this.health = health;
            this.energy = energy;
            this.aggression = aggression;
            this.solidity = solidity;
        }
        public static Stat operator +(Stat a, Stat b) =>
        new Stat(a.health + b.health, a.energy + b.energy, a.aggression + b.aggression, a.solidity + b.solidity);
        
        public Stat Clone() =>
        new Stat(health, energy, aggression, solidity);

        public void CapStat(Stat max){
            if(health > max.health) health = max.health;
            if(energy > max.energy) energy = max.energy;
            else if(energy < 0 ) energy = 0;
            if(aggression > max.aggression) aggression = max.aggression;
            else if(aggression < 0 ) aggression = 0;
            if(solidity > max.solidity) solidity =max.solidity;
            else if(solidity < 0 ) solidity = 0;
        }

        public override string ToString(){
            return "Health : " + health + " / Energy : " + energy + " / Agg : " + aggression + " / Sol : " + solidity;
        }
    }
}

