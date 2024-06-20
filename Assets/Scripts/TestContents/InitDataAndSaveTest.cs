using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ssm.data;
/*
public class InitDataAndSaveTest : MonoBehaviour, IDataPersistence
{
    public DataPersistenceManager dataManager ;
    public TextMeshProUGUI nameTextfield;
    public TextMeshProUGUI worldTextfield;
    private void Start(){

    }
    public void ResetData(){
        //gameData = new ssm.game.structureData();
        dataManager.NewGame();
    }

    public void InitData(){
        dataManager.SaveGame();
    }

    public void LoadData(ssm.game.structureData gameData){
        nameTextfield.text = "Character Name : " + gameData.player.name;
        worldTextfield.text = "World Available : " +  gameData.worldAvailable.ToString();
    }
    public void SaveData(ssm.game.structureData gameData){
        Debug.Log("SaveData on Text Contents");
        gameData.worldAvailable = 100;
        gameData.player.name = "new name given";
    }
}
*/