using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaController : MonoBehaviour
{
    public AudioSource musicaVictoria; // El AudioSource que contiene la música de victoria

    void Start()
    {
        // Verifica si el AudioSource está asignado
        if (musicaVictoria == null)
        {
            musicaVictoria = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Si la música ha terminado, cargamos el menú principal
        if (!musicaVictoria.isPlaying)
        {
            RegresarAlMenu();
        }
    }

    // Función para regresar al menú principal
    void RegresarAlMenu()
    {
        SceneManager.LoadScene("Menu_Inicio"); // Carga la escena del menú principal
    }
}
