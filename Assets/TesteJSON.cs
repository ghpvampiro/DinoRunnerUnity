using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SingletonBehaviour<TesteJSON> : MonoBehaviour where TesteJSON : SingletonBehaviour<TesteJSON>
{
    public static TesteJSON instance { get; protected set; }

    private const string DataObjectKey = "DATA_OBJECT_KEY";

    [Serializable]
    public struct DataObject
    {
 
        [SerializeField] public int scoreDino;

    }

    [SerializeField] private DataObject _data;

    /// <UI>
     
    public Text textScore;
    
    /// </UI>

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            throw new System.Exception("An instance of this singleton already exists.");
        }
        else
        {
            instance = (TesteJSON)this;
        }
    }


    private void Awake()
    {
        //base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(DataObjectKey))
        {
            _data = Newtonsoft.Json.JsonConvert.DeserializeObject<DataObject>(PlayerPrefs.GetString(DataObjectKey));
        }
        else
        {
            _data = new DataObject();

            InitializeData();

            Save();
        }
    }

    public void Save()
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
        PlayerPrefs.SetString(DataObjectKey, json);
    }


    private void InitializeData()
    {
        _data.scoreDino = 000;
        
        return;
    }



  
}
