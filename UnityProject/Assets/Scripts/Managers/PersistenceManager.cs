using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class PersistenceManager {

	public static List<GameInstance> games = new List<GameInstance>();

	public static void saveGame()
	{
		games.Add (GameInstance.current);
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "savedGames.waves");
		bf.Serialize (file, PersistenceManager.games);
	}

}
