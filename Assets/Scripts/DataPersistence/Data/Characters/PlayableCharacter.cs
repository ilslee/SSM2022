using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ssm.data.item;
using ssm.data.token;

namespace ssm.data{
    [System.Serializable]
    /*
    + Item
    + Memory( = StatB, Motion, Direction, StatA)
    + Buff / Debuff
    */
    public class PlayableCharacter : Character
    {
        
        public ItemContainer itemContainer;
        public List<ItemData> part;
        public List<ItemData> accessory;
        public int accessoryCapability;
        public List<SetItem> set;
        public List<Token> core;
        public int score;
        public override void Reset(){
            //Items
            part = new List<ItemData>();
            accessory = new List<ItemData>();
            accessoryCapability = 0;
            set = new List<SetItem>();
            core = new List<Token>();
            Token hpMax = new Token();
            hpMax.type = GameTerms.TokenType.HPMax;
            hpMax.value = 0f;
            Token hpCurrent = new Token();
            hpCurrent.type = GameTerms.TokenType.HPCurrent;
            hpCurrent.value = 0f;
            
            Token epMax = new Token();
            epMax.type = GameTerms.TokenType.EPMax;
            epMax.value = 0f;
            Token epCurrent = new Token();
            epCurrent.type = GameTerms.TokenType.EPCurrent;
            epCurrent.value = 0f;
            

            core.Add(hpMax);   
            core.Add(hpCurrent);   
            core.Add(epMax);   
            core.Add(epCurrent);   
        }

        // public PlayableCharacter Clone(){
        //     PlayableCharacter clone = ScriptableObject.CreateInstance("PlayableCharacter") as PlayableCharacter;
            
        //     clone.part = this.part.ToList();
        //     return clone;
        // }
        public void OnValidate()
        {
            UpdateSetItemData();
        }

        private void UpdateSetItemData(){
            set.Clear();
            ItemData.Family[] families = new ItemData.Family[]{
                                            ItemData.Family.Assassin, ItemData.Family.Blacksmith, ItemData.Family.Clown,
                                            ItemData.Family.Dancer, ItemData.Family.Death, ItemData.Family.Emperor, ItemData.Family.Fighter,
                                            ItemData.Family.Life, ItemData.Family.Orator, ItemData.Family.Soldier};        
            if(part.All(x => x is ItemData) == false ) return;
            for (int i = 0; i < families.Length; i++)
            {
                List<ItemData> d = part.FindAll(x => x.family == families[i]);
                if(d.Count <2) continue;
                int countOfGrade3 = 0;
                int countOfGrade2AndAbobe = 0;
                int countOfGrade1AndAvobe = 0;
                for (int n = 0; n < d.Count; n++)
                {
                    switch(d[n].grade){
                        case 3:
                        countOfGrade3 ++;
                        countOfGrade2AndAbobe ++;
                        countOfGrade1AndAvobe ++;
                        break;
                        case 2:
                        countOfGrade2AndAbobe ++;
                        countOfGrade1AndAvobe ++;
                        break;
                        case 1:
                        countOfGrade1AndAvobe ++;
                        break;
                    }
                }
                if(countOfGrade3 == 4){ //Add Set 3
                    Debug.Log("<!!!> PlayableCharacter.UpdateSetItemData : "+families[i].ToString()+" Set level 3 has completed.");
                    set.Add(itemContainer.GetSetFamily(families[i])[2]);
                }else if(countOfGrade2AndAbobe >= 3){ //Add Set 2
                    Debug.Log("<!!> PlayableCharacter.UpdateSetItemData : "+families[i].ToString()+" Set level 2 has completed.");
                    set.Add(itemContainer.GetSetFamily(families[i])[1]);
                }else if(countOfGrade1AndAvobe >= 2){ //Add Set 1
                    Debug.Log("<!> PlayableCharacter.UpdateSetItemData : "+families[i].ToString()+" Set level 1 has completed.");
                    set.Add(itemContainer.GetSetFamily(families[i])[0]);

                }
            }
            
        }
    }
}