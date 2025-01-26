using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButtons : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bubbleButton;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirAudio()
    {
        audioSource.PlayOneShot(bubbleButton);
    }
}
