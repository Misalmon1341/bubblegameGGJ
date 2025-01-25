using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlAudio : MonoBehaviour
{
    public AudioSource musicaFondo; // La música de fondo del juego
    public AudioSource efectosSonido; // Los efectos de sonido del juego
    public AudioMixer mixer; // AudioMixer para controlar volúmenes

    private float volumenMusica = 1f; // Valor por defecto del volumen de la música
    private float volumenSFX = 1f; // Valor por defecto del volumen de los efectos

    void Start()
    {
        // Cargar los volúmenes guardados al iniciar
        volumenMusica = PlayerPrefs.GetFloat("VolumenMusica", 1f);
        volumenSFX = PlayerPrefs.GetFloat("VolumenSFX", 1f);

        // Aplicar los volúmenes iniciales
        AjustarVolumenMusica(volumenMusica);
        AjustarVolumenSFX(volumenSFX);
    }

    // Función para ajustar el volumen de la música desde un slider
    public void AjustarVolumenMusica(float nuevoVolumen)
    {
        volumenMusica = nuevoVolumen;
        mixer.SetFloat("VolumenMusica", Mathf.Log10(volumenMusica) * 20); 
        PlayerPrefs.SetFloat("VolumenMusica", volumenMusica); 
    }

    // Función para ajustar el volumen de los efectos de sonido desde un slider
    public void AjustarVolumenSFX(float nuevoVolumen)
    {
        volumenSFX = nuevoVolumen;
        mixer.SetFloat("VolumenSFX", Mathf.Log10(volumenSFX) * 20); 
        PlayerPrefs.SetFloat("VolumenSFX", volumenSFX); 
    }
}
