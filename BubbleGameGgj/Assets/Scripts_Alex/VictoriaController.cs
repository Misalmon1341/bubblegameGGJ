using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaController : MonoBehaviour
{
    public AudioSource musicaVictoria; // El AudioSource que contiene la m�sica de victoria

    void Start()
    {
        // Verifica si el AudioSource est� asignado
        if (musicaVictoria == null)
        {
            musicaVictoria = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Si la m�sica ha terminado, cargamos el men� principal
        if (!musicaVictoria.isPlaying)
        {
            RegresarAlMenu();
        }
    }

    // Funci�n para regresar al men� principal
    void RegresarAlMenu()
    {
        SceneManager.LoadScene("Menu_Inicio"); // Carga la escena del men� principal
    }
}
