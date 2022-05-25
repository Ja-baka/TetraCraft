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

    public T Load<T>(T defaultSaveData) 
        where T : notnull
    {
        if (File.Exists(_path) == false)
        {
            Save(defaultSaveData);
            return defaultSaveData;
        }

        using FileStream file = File.Open(_path, FileMode.Open);
        T savedData = (T) _formatter.Deserialize(file);
        file.Close();
        return savedData;
    }

    public void Save<T>(T saveData)
    {
        using FileStream file = File.Create(_path);
        _formatter.Serialize(file, saveData);
        file.Close();
    }
}
