using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame(PlayerController3D player)
    {
        
#if UNITY_EDITOR
        string path = Application.streamingAssetsPath + "/" + player.stats.Name + ".save";
#elif UNITY_ANDROID
        string path = Application.persistentDataPath + "/" + player.stats.name + ".save";
#endif
        PlayerData data = new PlayerData(player);

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    private static void SaveNewPlayer(PlayerData data)
    {
#if UNITY_EDITOR
        string path = Application.streamingAssetsPath + "/" + data.Name + ".save";
#elif UNITY_ANDROID
        string path = Application.persistentDataPath + "/" + data.Name + ".save";
#endif
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData LoadGame(string name)
    {
#if UNITY_EDITOR
        string path = Application.streamingAssetsPath + "/" + name + ".save";
#elif UNITY_ANDROID
        string path = Application.persistentDataPath + "/" + name + ".save";
#endif

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = (PlayerData)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else
        {
            PlayerData data = new PlayerData();
            SaveNewPlayer(data);
            return data;
        }
    }
    public static void NewGame(string name)
    {
#if UNITY_EDITOR
        string path = Application.streamingAssetsPath + "/" + name + ".save";
#elif UNITY_ANDROID
        string path = Application.persistentDataPath + "/" + name + ".save";
#endif
        PlayerData data = new PlayerData(name);

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
}
