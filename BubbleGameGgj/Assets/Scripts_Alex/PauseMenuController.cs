using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuPanel; 
    private bool isPaused = false; 

    // Paneles de victoria o derrota, para evitar sobreposiciones
    public GameObject winPanel;
    public GameObject losePanel;

    void Update()
    {
        /*esto solo detecta que no este los dos panels para mandar a llamar el menu de pausa*/
        if (Input.GetKeyDown(KeyCode.Escape) && !IsOtherPanelActive())
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false; 
    }

    void Pause()
    {
        pauseMenuPanel.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true; 
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado.");
    }

    private bool IsOtherPanelActive()
    {
        if ((winPanel != null && winPanel.activeSelf) || (losePanel != null && losePanel.activeSelf))
        {
            return true;
        }

        return false;
    }
}
