using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Controller : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Reproducir la música al iniciar la escena del menú
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
    public void IniciarJuego()
    {
        // Detener la música dependiendo la escena
        GameObject musicManager = GameObject.Find("MusicManager");
        if (musicManager != null)
        {
            AudioSource audioSource = musicManager.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop(); 
            }
        }

        SceneManager.LoadScene("NombreDeTuEscenaDeJuego");
    }
}
