using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    
    public static void SavePlayer (GameManager player)
    {

        GameManager.instance.saveDate = DateTime.Now.ToString();

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.death";
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static playerData LoadPlayer ()
    {

        string path = Application.persistentDataPath + "/player.death";
        
        

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            playerData data = formatter.Deserialize(stream) as playerData;
            stream.Close();

            return data;

        } else
        {
            Debug.LogError("Error file not found in" + path);
            return null;
        }
        
    }
    
}
