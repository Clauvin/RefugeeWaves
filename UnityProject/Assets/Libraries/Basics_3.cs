using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Library in progress for fast prototyping in Unity.
/// 
/// Version 3. And needing to use semantic versioning.
/// </summary>
namespace Basics_3
{
    /// <summary>
    /// Class LoadScene.
    /// 
    /// Responsible for loading scenes.
    /// </summary>
    public static class LoadScene
    {
        public static void Load(int cena)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(cena);
        }

        public static void LoadAlphaWarning()
        {
            Load((int)Game_Scenes.Alpha_Warning);
        }

        public static void LoadMainMenu()
        {
            Load((int)Game_Scenes.Main_Menu);
        }

        public static void LoadMainGameplay()
        {
            Load((int)Game_Scenes.Main_GamePlay);
        }

        public static void LoadVictoryScreen()
        {
            Load((int)Game_Scenes.Victory_Screen);
        }

        public static void LoadDefeatScreen()
        {
            Load((int)Game_Scenes.Defeat_Screen);
        }

        public static void CloseGame()
        {
            Application.Quit();
        }

    }

    /// <summary>
    /// Classe Conversions.
    /// 
    /// Manages value conversion.
    /// </summary>

    public static class Conversions
    {

        public static float DegreeToRadian(float degree)
        {
            return degree * Mathf.PI / 180;
        }

        public static float RadianToDegree(float radian)
        {
            return radian * 180 / Mathf.PI;
        }
    }

    public enum Game_Scenes
    {
        Alpha_Warning = 0,
        Main_Menu = 1,
        Main_GamePlay = 2,
        Victory_Screen = 3,
        Defeat_Screen = 4
    }

    public enum Commerce_Actions
    {
        Open_Commerce = 0,
        Closed_Commerce = 1,
        Buying = 2,
        Selling = 3,
        Lending = 4
    }
}


