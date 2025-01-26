using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public GameObject fadePanel; // Panel que se oscurecer�
    public float fadeDuration = 1f; // Duraci�n del desvanecimiento
    public string nextSceneName; // Nombre de la siguiente escena
    private CanvasGroup canvasGroup; // Controla la opacidad del fadePanel

    void Start()
    {
        if (fadePanel != null)
        {
            canvasGroup = fadePanel.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = fadePanel.AddComponent<CanvasGroup>();
            }

            canvasGroup.alpha = 1f; // Inicia el panel completamente opaco
            StartCoroutine(FadeIn()); // Inicia la transici�n de entrada
        }
    }

    // M�todo para iniciar la transici�n de salida 
    public void StartTransition()
    {
        if (fadePanel != null)
        {
            StartCoroutine(FadeOutAndChangeScene(nextSceneName));
        }
    }

    // M�todo para desvanecer el panel al inicio (fade in)
    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        // Transici�n desde opaco (alpha = 1) a transparente (alpha = 0)
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = 1f - Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }
    }

    // M�todo para desvanecer el panel antes de cambiar de escena (fade out)
    private IEnumerator FadeOutAndChangeScene(string sceneName)
    {
        float elapsedTime = 0f;

        // Transici�n desde transparente (alpha = 0) a opaco (alpha = 1)
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        // Una vez que el fade out ha terminado, cambiamos de escena
        SceneManager.LoadScene(sceneName);
    }
}
