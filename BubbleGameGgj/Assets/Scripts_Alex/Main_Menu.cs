using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Main_Menu : MonoBehaviour
{
    // Método para iniciar el juego
    public TransitionManager transitionManager;
    public void PlayGame()
    {
        transitionManager.StartTransition();
    }
    // Método para salir del juego
    public void SalirDelJuego()
    {
        // Funciona en un build en el editor no hace nada
        Application.Quit();
        Debug.Log("El juego se ha cerrado."); // Esto si lo puedes ver en el editor en un texto
    }
}
