using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    static private string path = @"M:/EKKE/Szakdolgozat";

    public static void LoadSettings<T>(ref T data, string filePath)
        where T: ISaveable
    {
        string loadPath = string.Format("{0}/{1}", path, filePath);

        if (File.Exists(loadPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(loadPath, FileMode.Open);

            try
            {
                data.Load(formatter.Deserialize(stream) as ISaveable);
            }
            finally
            {
                stream.Close();
            }
        }
        else SaveSettings(data, filePath);
    }

    public static void SaveSettings<T>(T dataToStore, string filePath) //path
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string loadPath = string.Format("{0}/{1}", path, filePath);

        FileStream stream = new FileStream(loadPath, FileMode.Create);

        formatter.Serialize(stream, dataToStore);

        stream.Close();
    }
}