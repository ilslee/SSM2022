using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.data
{
    public interface IDataPersistence
    {
        void LoadData(SSMGameData data);
        void SaveData(SSMGameData data);
    } 
}