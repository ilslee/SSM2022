using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ssm.data
{
    public class DataPersistenceManager : MonoBehaviour
    {
        [Header("File Storage Config")]
        [SerializeField] private string fileName;
        
        private SSMGameData gameData;
        private List<IDataPersistence> dataPersistenceObjects;
        private FileDataHandler dataHandler;
        public static DataPersistenceManager instance {get;private set;}
        private void Awake(){
            if(instance != null){
                Debug.LogError("Found more than one Data Persitence manager in the scene");
            }
            instance = this;
        }

        private void Start(){
            dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }
        public void NewGame(){
            this.gameData = new SSMGameData();
        }
        public void LoadGame(){
            
            // TODO - Load any saved data from a file using the data handler
            gameData = dataHandler.Load();

            // if no data can be found, initialize to a new game
            if(this.gameData == null){
                Debug.Log("No data was found. Initializing data to defaults.");
                NewGame();
            }
            //TODO - push the loaded data to all other scripts that need it
            foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
                dataPersistenceObj.LoadData(gameData);
            }
        }
        public void SaveGame(){
            //TODO - pass the data to other scripts so they can update it
            foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
                dataPersistenceObj.SaveData(gameData);
            }
            // TODO - save that data to a file using the data handler
            dataHandler.Save(gameData);
        }

        private void OnApplicationQuit(){
            SaveGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects(){
            IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

            return new List<IDataPersistence>(dataPersistenceObjects);
        }
    }
}