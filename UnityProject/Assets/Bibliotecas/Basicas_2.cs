using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Biblioteca para prototipagem rápida na Unity.
/// 
/// Versão 2, criada para uso no jogo 2, pra Global Game Jam 2017.
/// </summary>
namespace Basicas_2
{
    /// <summary>
    /// Classe Reset.
    /// 
    /// Responsável por carregar cenas, recarregando uma cena específica.
    /// </summary>
    public static class CarregaCena
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


