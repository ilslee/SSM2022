using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.data.gameDialogue
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "SSM/Data/GameEvent")]
    public class GameDialogue : ScriptableObject
    {
        public int shotIndex;
        public List<GameDialogueShot> shot;
        public void Reset(){
            shotIndex = 0;
            shot = new List<GameDialogueShot>();
        }
    }   
    [Serializable]
    public class GameDialogueShot{
        public enum GameDialogueCameraTarget {None, Player, Opponent, Instructor, System}
        public GameDialogueCameraTarget cameraTarget;
        public GameDialogueLine line;
        
        public GameDialogueShot(){
            cameraTarget = GameDialogueCameraTarget.None;
            line = new GameDialogueLine();
        }
    } 

    [Serializable]
    public class GameDialogueLine{
        public string characterName;
        public int lineIndex;
        [TextArea]
        public List<string> line;
        public GameDialogueLine(){
            characterName = "No Name";
            lineIndex = 0;
            line = new List<string>();
        }
    }
}
