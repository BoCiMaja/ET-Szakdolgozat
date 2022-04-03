using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class SaveSystem
{
    static private string path = Application.persistentDataPath + "/saves";

    public static T LoadSettings<T>(string filePath)
        where T: ISaveable, new()
    {
        string loadPath = string.Format("{0}/{1}", path, filePath);

        if (File.Exists(loadPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            SurrogateSelector selector = new SurrogateSelector();
            Vector3SerializationSurrogates vector3Surrogate =
                new Vector3SerializationSurrogates();

            selector.AddSurrogate(typeof(Vector3),
                                  new StreamingContext(StreamingContextStates.All),
                                  vector3Surrogate);

            formatter.SurrogateSelector = selector;

            FileStream stream = new FileStream(loadPath, FileMode.Open);

            try
            {
                T data = new T();
                data.Load(formatter.Deserialize(stream) as ISaveable);
            
                stream.Close();
            
                return data;
            }
            catch(System.Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }
        else throw new System.Exception("Save cannot found.");
    }

    public static void SaveSettings<T>(T dataToStore, string filePath) //path
    {
        string savePath = string.Format("{0}/{1}", path, filePath);

        if(!Directory.Exists(savePath))
            Directory.CreateDirectory(path);

        BinaryFormatter formatter = new BinaryFormatter();

        SurrogateSelector selector = new SurrogateSelector();
        Vector3SerializationSurrogates vector3Surrogate =
            new Vector3SerializationSurrogates();

        selector.AddSurrogate(typeof(Vector3),
                              new StreamingContext(StreamingContextStates.All),
                              vector3Surrogate);

        formatter.SurrogateSelector = selector;

        FileStream stream = new FileStream(savePath, FileMode.Create);

        formatter.Serialize(stream, dataToStore);

        stream.Close();
    }
}