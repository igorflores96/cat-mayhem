using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string _dataDirectoryPath = "";
    private string _dataFileName = "";
    private bool _useEncryption = false;
    private readonly string _encryptionCodeWord = "word";

    public FileDataHandler(string DataDirectoryPath, string DataFileName, bool UseEncryption)
    {
        this._dataDirectoryPath = DataDirectoryPath;
        this._dataFileName = DataFileName;
        this._useEncryption = UseEncryption;
    }

    public GameData Load()
    {
        string _fullPath = Path.Combine(_dataDirectoryPath, _dataFileName);
        GameData _loadedData = null;
        if(File.Exists(_fullPath))
        {
            try
            {
                string _dataToLoad = "";
                using (FileStream _stream = new FileStream(_fullPath, FileMode.Open))
                {
                    using (StreamReader _reader = new StreamReader(_stream))
                    {
                        _dataToLoad = _reader.ReadToEnd();
                    }
                }

                if(_useEncryption)
                {
                    _dataToLoad = EncryptDecrypt(_dataToLoad);
                }

                _loadedData = JsonUtility.FromJson<GameData>(_dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Ocorreu um erro tentando carregar a data do jogo." + _fullPath + "\n" + e);
            }
        }

        return _loadedData;
    }

    public void Save(GameData data)
    {
        string _fullPath = Path.Combine(_dataDirectoryPath, _dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_fullPath));

            string _dataToStore = JsonUtility.ToJson(data, true);

            if (_useEncryption)
            {
                _dataToStore = EncryptDecrypt(_dataToStore);
            }

            using (FileStream _stream = new FileStream(_fullPath, FileMode.Create))
            {
                using (StreamWriter _writer = new StreamWriter(_stream))
                {
                    _writer.Write(_dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Ocorreu um erro tentando salvar o jogo no arquivo." + _fullPath + "\n" + e);
        }
    }

    private string EncryptDecrypt(string data)
    {
        string _modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            _modifiedData += (char)(data[i] ^ _encryptionCodeWord[i % _encryptionCodeWord.Length]);
        }

        return _modifiedData;
    }
}
