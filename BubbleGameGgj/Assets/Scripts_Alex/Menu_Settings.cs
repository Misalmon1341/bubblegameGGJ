using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class AudioSettingsManager : MonoBehaviour
{
   
   
        public AudioMixer audioMixer; // Asigna aquí tu AudioMixer desde el Inspector
        public Slider musicSlider;    // Slider para controlar la música
        public Slider sfxSlider;      // Slider para controlar los SFX

        void Start()
        {
            // Configuramos los sliders para que reflejen el valor inicial del AudioMixer
            float musicVolume;
            audioMixer.GetFloat("MusicVolume", out musicVolume);
            musicSlider.value = musicVolume;

            float sfxVolume;
            audioMixer.GetFloat("SFXVolume", out sfxVolume);
            sfxSlider.value = sfxVolume;
        }

        public void SetMusicVolume(float volume)
        {
            audioMixer.SetFloat("MusicVolume", volume <= 0.0001f ? -80f : Mathf.Log10(volume) * 20);
        }

        public void SetSFXVolume(float volume)
        {
            audioMixer.SetFloat("SFXVolume", volume <= 0.0001f ? -80f : Mathf.Log10(volume) * 20);
        }

}