using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ssm.game.structure;
using System.Security.Cryptography.X509Certificates;
namespace ssm.data.item{
    
    [CreateAssetMenu(fileName = "ItemContainer", menuName = "SSM/Item/ItemContainer")]
    public class ItemContainer : ScriptableObject{
        public int itemFamilyCount = 7;
        public List<ItemData> basic;
        public List<ItemData> assassin;
        public List<ItemData> blacksmith;
        public List<ItemData> clown;
        public List<ItemData> dancer;
        public List<ItemData> death;
        public List<ItemData> emperor;
        public List<ItemData> fighter;
        public List<ItemData> life;
        public List<ItemData> orator;
        public List<ItemData> soldier;
        
        //-----------------------------------[Accessories]
        public List<SetItem> setAssasin;
        public List<SetItem> setBlacksmith;
        public List<SetItem> setClown;
        public List<SetItem> setDancer;
        public List<SetItem> setDeath;
        public List<SetItem> setEmperor;
        public List<SetItem> setFighter;
        public List<SetItem> setLife;
        public List<SetItem> setOrator;
        public List<SetItem> setSoldier;
        //-----------------------------------[Accessories]
        public List<ItemData> accessory;

        public ItemData GetPart(ItemData.Family f, ItemData.Part p, int g){
            ItemData sourceItem = GetPartFamily(f).Find(x => x.part == p && x.grade == g);
            if(sourceItem == null){
                Debug.LogError("ItemContainer.GetItem : Cannont Find Suitable Item in " + f.ToString() + " / " + p.ToString());
                return new ItemData();
            }else{
                return sourceItem;
            }
        }
        private List<ItemData> GetPartFamily(ItemData.Family f){
            switch(f){
                case ItemData.Family.Assassin:
                return assassin;
                case ItemData.Family.Blacksmith:
                return blacksmith;
                case ItemData.Family.Clown:
                return clown;
                case ItemData.Family.Dancer:
                return dancer;
                case ItemData.Family.Death:
                return death;
                case ItemData.Family.Emperor:
                return emperor;
                case ItemData.Family.Fighter:
                return fighter;
                case ItemData.Family.Life:
                return life;
                case ItemData.Family.Orator:
                return orator;
                case ItemData.Family.Soldier:
                return soldier;
            }
            return basic;
        }
        public List<SetItem> GetSetFamily(ItemData.Family f){
            switch(f){
                case ItemData.Family.Assassin:
                return setAssasin;
                case ItemData.Family.Blacksmith:
                return setBlacksmith;
                case ItemData.Family.Clown:
                return setClown;
                case ItemData.Family.Dancer:
                return setDancer;
                case ItemData.Family.Death:
                return setDeath;
                case ItemData.Family.Emperor:
                return setEmperor;
                case ItemData.Family.Fighter:
                return setFighter;
                case ItemData.Family.Life:
                return setLife;
                case ItemData.Family.Orator:
                return setOrator;
                case ItemData.Family.Soldier:
                return setSoldier;
            }
            Debug.LogError("ItemContainer.GetSetFamily : No suitable family set found where " + f.ToString());
            return new List<SetItem>();
        }
        public ItemData.Family GetRandomFamily(){
            ItemData.Family[] container = new ItemData.Family[]{
                                            ItemData.Family.Assassin, ItemData.Family.Blacksmith, ItemData.Family.Clown,
                                            ItemData.Family.Dancer, ItemData.Family.Death, ItemData.Family.Emperor, ItemData.Family.Fighter,
                                            ItemData.Family.Life, ItemData.Family.Orator, ItemData.Family.Soldier};
            return container[MathTool.GetRandomIndex(container.Length)];
        }
    }
    
    /*
    [System.Serializable]
    public class ItemIndexer{
        public GameTerms.ItemFamily family;
        public GameTerms.ItemPart part;
        public int grade;

        public ItemIndexer(){
            family = GameTerms.ItemFamily.None;
            part = GameTerms.ItemPart.None;
            grade = 0;
        }

        public ItemIndexer(GameTerms.ItemFamily f, GameTerms.ItemPart p, int g){
            family = f;
            part = p;
            grade = g;
        }
    }
    */
}