using System.Collections;
using System.Collections.Generic;
using ssm.data;
using UnityEngine;
using TMPro;
using ssm.data.item;
namespace ssm.game.structure{
    public class AIGameItemTester : MonoBehaviour
    {
        public ItemData.Family character1ItemType;
        public float character1ItemGrade;

        public ItemData.Family character2ItemType;
        public float character2ItemGrade;

        public int numOfGame;

        // public ItemContainer itemContainer;

        private Game game;
        public void Start(){
            Debug.Log("AI Game Item Tester, Start.");
        }
    }
}