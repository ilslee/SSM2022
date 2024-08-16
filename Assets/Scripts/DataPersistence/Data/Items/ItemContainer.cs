using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ssm.game.structure;
namespace ssm.data{
    /*
    [CreateAssetMenu(fileName = "ItemContainer", menuName = "SSM/Item/CreateItemContainer")]
    public class ItemContainer : ScriptableObject{
        public int itemFamilyCount = 7;
        public List<ItemData> basic;
        public List<ItemData> assassin;
        public List<ItemData> blacksmith;
        public List<ItemData> death;
        public List<ItemData> emperor;
        public List<ItemData> jester;
        public List<ItemData> life;

        public ItemData DuplicateItem(ItemData.Family f, ItemData.Part p, int g){
            ItemData sourceItem = GetItemFamily(f).Find(x => x.part == p);
            if(sourceItem.family != f || sourceItem.part != p){
                Debug.LogError("ItemContainer.DuplicateItem : Cannont Find Suitable Item in " + f.ToString() + " / " + p.ToString());
            }
            ItemData clonedItem = ScriptableObject.Instantiate(sourceItem) as ItemData;
            clonedItem.grade = g;
            return clonedItem;
        }
        private List<ItemData> GetItemFamily(ItemData.Family f){
            switch(f){
                case ItemData.Family.Assassin:
                return assassin;
                case ItemData.Family.Blacksmith:
                return blacksmith;
                case ItemData.Family.Death:
                return death;
                case ItemData.Family.Emperor:
                return emperor;
                case ItemData.Family.Life:
                return life;
            }
            return basic;
        }
        public ItemData.Family GetRandomFamily(){
            int index = MathTool.GetRandomIntRange(1, itemFamilyCount);
             switch(index){
                case 1:
                return ItemData.Family.Assassin;
                case 2:
                return ItemData.Family.Blacksmith;
                case 3:
                return ItemData.Family.Death;
                case 4:
                return ItemData.Family.Emperor;
                case 5:
                return ItemData.Family.None;
                case 6:
                return ItemData.Family.Life;
            }
            return ItemData.Family.Default;;
        }
    }
    */
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