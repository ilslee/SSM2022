using System.Collections;
using System.Collections.Generic;
using ssm.data.gameDialogue;
using ssm.game.structure;
using UnityEngine;

namespace ssm.data.league{
    [CreateAssetMenu(fileName = "GameData", menuName = "SSM/Data/GameData")]
    public class Game : ScriptableObject {
        
        public GameDialogue preGameDialogue;
        public GameDialogue postGameDialogue;
        public PlayableCharacter player;
        public BPCharacter opponent;
    }
}