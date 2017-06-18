using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class PersistenceManager {

    public static GameInstance game;

	public static void saveGame()
	{
        game = new GameInstance();
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "savedGames.waves");
		bf.Serialize (file, PersistenceManager.game);
	}

}
