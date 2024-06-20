using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssm.data{
    public class BPCharacterGenerator : MonoBehaviour
    {
        // private List<string> charactName;
        private int difficulty = -1;
        private int opponentID;

        public ItemContainer itemContainer;
        public void Reset(int d){
            difficulty = d;
            opponentID = 0;
        }
        public BPCharacter Generate(int difficulty, bool isBoss = false){
            BPCharacter opponentCharacter = ScriptableObject.CreateInstance("BPCharacter") as BPCharacter;
            opponentCharacter.name = InitCharacterName();
            
            //GenerateCore
            opponentCharacter.item.Add(GenerateCharacterCore(opponentCharacter.name));
            //GenerateItems : Parts
            //GenerateItems : Accessaries
            //Generate BPs

            
            //TODO : Add Core to Character
            opponentID ++;
            return opponentCharacter;
        }

        private string InitCharacterName(){
            
            string difficultyString = "";
            switch(difficulty){
                case 1:
                difficultyString = "Easy-";
                break;
                case 2:
                difficultyString = "Normal-";
                break;
                case 3:
                difficultyString = "Hard-";
                break;
                case 4:
                difficultyString = "Easy-";
                break;

            }
            
            string characterIDString = "";
            if(opponentID < 10){
                characterIDString = "-0" + opponentID.ToString();
            }else{
                characterIDString = "-" + opponentID.ToString();
            }
            string returnVal = "Character " + difficultyString + characterIDString;
            return returnVal;
            
            
        }

        private ItemData GenerateCharacterCore(string charaterName){
            //Init Character's Core
            ItemData characterCore = ScriptableObject.CreateInstance("ItemData") as ItemData;
            characterCore.name = charaterName + "'s Core";
            characterCore.grade = 0;
            characterCore.family = ItemData.Family.None;
            characterCore.part = ItemData.Part.Core;
            int healthMin = 0;
            int healthMax = 0;
            int energyMin = 0;
            int energyMax = 0;
            int swordPowerMin = 0;
            int swordPowerMax = 0;
            int shieldPowerMin = 0;
            int shieldPowerMax = 0;
            switch(difficulty){
                case 1:
                healthMin = 15;
                healthMax = 30;
                energyMin = 3;
                energyMax = 5;
                swordPowerMin = 3;
                swordPowerMax = 5;
                shieldPowerMin = 3;
                shieldPowerMax = 5;
                break;
                case 2:            
                healthMin = 20;
                healthMax = 35;
                energyMin = 4;
                energyMax = 7;
                swordPowerMin = 4;
                swordPowerMax = 7;
                shieldPowerMin = 4;
                shieldPowerMax = 7;
                break;
                case 3:                
                healthMin = 25;
                healthMax = 40;
                energyMin = 5;
                energyMax = 9;
                swordPowerMin = 5;
                swordPowerMax = 9;
                shieldPowerMin = 5;
                shieldPowerMax = 9;                
                break;
                case 4:                
                healthMin = 30;
                healthMax = 45;
                energyMin = 6;
                energyMax = 10;
                swordPowerMin = 6;
                swordPowerMax = 10;
                shieldPowerMin = 6;
                shieldPowerMax = 10;
                break;
            }
            
            float healthVal = (float)MathTool.GetRandomIntWithin(healthMin, healthMax);
            TokenGrade healthMaxToken = new TokenGrade();
            healthMaxToken.category = Token.Category.Health;
            healthMaxToken.behaviour = Token.Behaviour.Max;
            healthMaxToken.occasion = Token.Occasion.OnStartGame;
            healthMaxToken.target = Token.Target.Me;
            healthMaxToken.value0 = new float[3]{healthVal, healthVal, healthVal};

            TokenGrade healthCurToken = new TokenGrade();
            healthCurToken.category = Token.Category.Health;
            healthCurToken.behaviour = Token.Behaviour.Current;
            healthCurToken.occasion = Token.Occasion.OnStartGame;
            healthCurToken.target = Token.Target.Me;
            healthCurToken.value0 = new float[3]{healthVal, healthVal, healthVal};

            float energyVal = (float)MathTool.GetRandomIntWithin(energyMin, energyMax);
            TokenGrade energyMaxToken = new TokenGrade();
            energyMaxToken.category = Token.Category.Energy;
            energyMaxToken.behaviour = Token.Behaviour.Max;
            energyMaxToken.occasion = Token.Occasion.OnStartGame;
            energyMaxToken.target = Token.Target.Me;
            energyMaxToken.value0 = new float[3]{energyVal, energyVal, energyVal};

            float swordPowerVal = (float)MathTool.GetRandomIntWithin(swordPowerMin, swordPowerMax);
            TokenGrade swordPowerMaxToken = new TokenGrade();
            swordPowerMaxToken.category = Token.Category.SwordPower;
            swordPowerMaxToken.behaviour = Token.Behaviour.Max;
            swordPowerMaxToken.occasion = Token.Occasion.OnStartGame;
            swordPowerMaxToken.target = Token.Target.Me;
            swordPowerMaxToken.value0 = new float[3]{swordPowerVal, swordPowerVal, swordPowerVal};

            float shieldPowerVal = (float)MathTool.GetRandomIntWithin(shieldPowerMin, shieldPowerMax);
            TokenGrade shieldPowerMaxToken = new TokenGrade();
            shieldPowerMaxToken.category = Token.Category.ShieldPower;
            shieldPowerMaxToken.behaviour = Token.Behaviour.Max;
            shieldPowerMaxToken.occasion = Token.Occasion.OnStartGame;
            shieldPowerMaxToken.target = Token.Target.Me;
            shieldPowerMaxToken.value0 = new float[3]{shieldPowerVal, shieldPowerVal, shieldPowerVal};
            //
            characterCore.tokens.Add(healthMaxToken);
            characterCore.tokens.Add(healthCurToken);
            characterCore.tokens.Add(energyMaxToken);
            characterCore.tokens.Add(swordPowerMaxToken);
            characterCore.tokens.Add(shieldPowerMaxToken);

            return characterCore;
        }

        private List<ItemData> GenerateItemParts(bool isBoss){
            List<ItemData> parts = new List<ItemData>();
            // List<int> partsFamilyIndex = new List<int>();
            // for (int i = 1; i < itemContainer.itemFamilyCount; i++)
            // {
            //     partsFamilyIndex.Add(i);
            // }
            int totalItemCount = 6;
            int itemLowerGrade = 0;
            int itemHigherGrade = 0;
            int numOfitemLowerGrade = 0;
            // int numOfItemHighLevel = 0;
            

            switch(difficulty){
                case 1:
                //Item Level 0 : 2~4
                //Item Level 1 : 2~4 (level 1들끼리는 모두 다른 Family)
                itemLowerGrade = 0;
                itemHigherGrade = 1;
                numOfitemLowerGrade = MathTool.GetRandomIntRange(2,4);
                break;
                case 2:
                //Item Level 1 : 2~4
                //Item Level 2 : 2~4
                itemLowerGrade = 1;
                itemHigherGrade = 2;
                numOfitemLowerGrade = MathTool.GetRandomIntRange(2,4);
                break;
                case 3:
                //Item Level 2 : 2~4
                //Item Level 3 : 2~4
                itemLowerGrade = 0;
                itemHigherGrade = 0;
                numOfitemLowerGrade = MathTool.GetRandomIntRange(2,4);
                break;
                case 4:
                //Item Level 3 : 6                
                itemLowerGrade = 3;
                itemHigherGrade = 3;
                numOfitemLowerGrade = 6;
                break;
            }
            // numOfItemHighLevel = totalItemCount - numOfItemHighLevel;
            List<int> partOrder = MathTool.GetShuffledInts(totalItemCount);
            ItemData.Part GetPartViaInt(int i){
                switch(i){
                    case 0:
                    return ItemData.Part.Arms;
                    case 1:
                    return ItemData.Part.Chest;
                    case 2:
                    return ItemData.Part.Head;
                    case 3:
                    return ItemData.Part.Legs;
                    case 4:
                    return ItemData.Part.Sword;
                    case 5:
                    return ItemData.Part.Sheild;
                }
                
                Debug.LogError("BPCharacterGenerator.GenerateItemParts.GetPartViaInt : Out of Index!!" );
                return ItemData.Part.None;;
            }
            
            int generationCount = 0;
            for (int i = 0; i < totalItemCount; i++)
            {
                ItemData.Part part = GetPartViaInt(i);
                ItemData.Family family = itemContainer.GetRandomFamily();
                int grade = itemLowerGrade;
                if(generationCount >= numOfitemLowerGrade){
                    grade = itemHigherGrade;
                }
                parts.Add(itemContainer.DuplicateItem(family, part, grade));
                generationCount ++;
            }
            
            if(isBoss == false){ //Manage Exceptions : Avoid too many set item generation
                
            }else{ //Set Boss Item

            }
            
            return parts;
        }

        private List<ItemData> GenerateItemAccessaries(){
            List<ItemData> accessaries = new List<ItemData>();
            switch(difficulty){
                case 1:
                break;
                case 2:
                break;
                case 3:
                break;
                case 4:
                break;
            }
            return accessaries;
        }
    }
}