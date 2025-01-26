using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoIntroManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Asigna tu componente VideoPlayer en el inspector
    public string nombreEscena; // El nombre de la escena a la que se cambiará al terminar el video

    void Start()
    {
        // Asegúrate de que se llame al método OnVideoFinished cuando termine el video
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // Método que se ejecuta cuando el video termina
    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nombreEscena); // Cambia a la escena deseada
    }
}
