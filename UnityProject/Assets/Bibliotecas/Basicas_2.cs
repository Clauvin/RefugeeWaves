﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Library in progress for fast prototyping in Unity.
/// 
/// Version 2, created for use in the game 2, for the Global Game Jam 2017.
/// </summary>
namespace Basicas_2
{
    /// <summary>
    /// Class LoadScene.
    /// 
    /// Responsible for loading scenes.
    /// </summary>
    public static class LoadScene
    {
        public static void Carrega(int cena)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(cena);
        }

        public static void CarregaMenuPrincipal()
        {
            Carrega((int)Cenas_do_Jogo.Main_Menu);
        }

        public static void CarregaGameplay()
        {
            Carrega((int)Cenas_do_Jogo.Main_GamePlay);
        }

        public static void CarregaVictoryScreen()
        {
            Carrega((int)Cenas_do_Jogo.Victory_Screen);
        }

        public static void CarregaDefeatScreen()
        {
            Carrega((int)Cenas_do_Jogo.Defeat_Screen);
        }

        public static void FechaJogo()
        {
            Application.Quit();
        }

    }

    /// <summary>
    /// Classe Conversoes.
    /// 
    /// Responsável por conversões de valores para outros valores.
    /// </summary>

    public static class Conversoes
    {

        public static float DeGrauParaRadiano(float grau)
        {
            return grau * Mathf.PI / 180;
        }

        public static float DeRadianoParaGrau(float radiano)
        {
            return radiano * 180 / Mathf.PI;
        }
    }

    public enum Cenas_do_Jogo
    {
        Main_Menu = 0,
        Main_GamePlay = 1,
        Victory_Screen = 2,
        Defeat_Screen = 3
    }
}


