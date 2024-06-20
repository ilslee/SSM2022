using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ssm.data{
    [System.Serializable]
    /*
    + Item
    + Memory( = StatB, Motion, Direction, StatA)
    + Buff / Debuff
    */
    public class PlayableCharacter : Character
    {
        
        // public List<ItemIndexer> item;
        public List<ItemData> item;
        // public ItemIndexer head;
        // public ItemIndexer body;
        // public ItemIndexer arms;
        // public ItemIndexer legs;
        // public ItemIndexer sword;
        // public ItemIndexer shield;
        //Stats
        // public int maxHealth;
        // public int currentHealth;
        // public int maxEnergy;
        // public int currentEnergy;
        // public int maxAttack;
        // public int currentAttack;
        // public int maxDefence;
        // public int currentDefence;
        //Test variable
        public int score;
        public override void Reset(){
            //Stats
            // maxHealth = 0;
            // currentHealth = 0;
            // maxEnergy = 0;
            // currentEnergy = 0;
            // maxAttack = 0;
            // currentAttack = 0;
            // maxDefence = 0;
            // currentDefence = 0;
            //Items
            item = new List<ItemData>();
            // Debug.Log("Playable Character's Item - " + item);
            // head = new ItemIndexer();
            // body = new ItemIndexer();
            // arms = new ItemIndexer();
            // legs = new ItemIndexer();
            // sword = new ItemIndexer();
            // shield = new ItemIndexer();
            
        }

        public PlayableCharacter Clone(){
            PlayableCharacter clone = ScriptableObject.CreateInstance("PlayableCharacter") as PlayableCharacter;
            
            // clone.maxHealth = this.maxHealth;
            // clone.currentHealth = this.currentHealth;
            // clone.maxEnergy = this.maxEnergy;
            // clone.currentEnergy = this.currentEnergy;
            // clone.maxAttack = this.maxAttack;
            // clone.currentAttack = this.currentAttack;
            // clone.maxDefence = this.maxDefence;
            // clone.currentDefence = this.currentDefence;
            //Items
            // clone.head = this.head;
            // clone.body = this.body;
            // clone.arms = this.arms;
            // clone.legs = this.legs;
            // clone.sword = this.sword;
            // clone.shield = this.shield;
            clone.item = this.item.ToList();
            return clone;
        }
        //public List<Accessory> accessory; //TODO 액세서리 구현은 나중에
        /*
        public PlayableCharacter(){
            
            // head = new BodyPart(BodyPart.Part.Head, BodyPart.Family.None, 0);
            // body = new BodyPart(BodyPart.Part.Body, BodyPart.Family.None, 0);
            // arms = new BodyPart(BodyPart.Part.Arms, BodyPart.Family.None, 0);
            // legs = new BodyPart(BodyPart.Part.Legs, BodyPart.Family.None, 0);
            // sword = new BodyPart(BodyPart.Part.Sword, BodyPart.Family.None, 0);
            // shield = new BodyPart(BodyPart.Part.Shield, BodyPart.Family.None, 0);

            


            score = 0;
        }

        public virtual PlayerMotion PlayMotion(){
            int motionCount = System.Enum.GetValues(typeof(PlayerMotion)).Length;
            int motionID = MathTool.RandomInt(1, motionCount-1);
            // Debug.Log("motionCount : " + motionCount + " / motionID : " + motionID);
            return (PlayerMotion)motionID;
        }

        public virtual PlayerDirection PlayDirection(){
            int directionCount = System.Enum.GetValues(typeof(PlayerDirection)).Length;
            int directionID = MathTool.RandomInt(0, directionCount-1);
            return (PlayerDirection)directionID;
        }

        
        */
    }
}