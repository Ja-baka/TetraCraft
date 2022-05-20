using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Storage
{
    private readonly string _path;
    private BinaryFormatter _formatter;

    public Storage()
    {
        _path = Application.persistentDataPath + "/LeaderBoard.save";
        _formatter = new BinaryFormatter();
    }

    public object Load(object defaultSaveData) 
    {
        if (File.Exists(_path) == false)
        {
            if (defaultSaveData != null)
            {
                Save(defaultSaveData);
            }
            return defaultSaveData;
        }

        FileStream file = File.Open(_path, FileMode.Open);
        object savedData = _formatter.Deserialize(file);
        file.Close();
        return savedData;
    }

    public void Save(object saveData)
    {
        using FileStream file = File.Create(_path);
        _formatter.Serialize(file, saveData);
        file.Close();
    }
}
