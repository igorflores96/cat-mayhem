using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{

    private GameData _gameData;

    [SerializeField]
    private string _fileName;

    [SerializeField]
    private bool _useEncryption;

    private List<IDataPersistence> _dataPersistenceObjects;

    private FileDataHandler _dataHandler;

    public static DataPersistenceManager _instance { get; private set; }

    private void Awake()
    {
        if(_instance != null)
        {
            Debug.Log("Mais de um datapersistencemanager apareceu. Destruindo o novo.");
            Destroy(this.gameObject);
            return;
        }
        
        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        _dataHandler = new FileDataHandler(Application.persistentDataPath, _fileName, _useEncryption);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this._dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame()
    {
        this._gameData = new GameData();
    }

    public void LoadGame()
    {

        this._gameData = _dataHandler.Load();
        
        if(this._gameData == null)
        {
            Debug.Log("Não foi encontrado um jogo, criando um do zero.");
            return;
        }

        foreach (IDataPersistence dataPersistenceObject in _dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(_gameData);
        }
    }

    public void SaveGame()
    {
        if(this._gameData == null)
        {
            return;
        }
        foreach (IDataPersistence dataPersistenceObject in _dataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(_gameData);
        }
        _dataHandler.Save(_gameData);
    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> _dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(_dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return _gameData != null;
    }
}
