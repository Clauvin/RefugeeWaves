using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class PersistenceManager
{

    public static GameInstance game;

    public static void saveGame()
    {
        game = new GameInstance();
        game.PreparingSaveFile();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.waves");
        bf.Serialize(file, PersistenceManager.game);
        file.Close();
    }

    public static void loadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenRead(Application.persistentDataPath + "/savedGames.waves");
        game = (GameInstance)bf.Deserialize(file);
        game.PlacingSavedFilesBack();
        file.Close();
    }
}