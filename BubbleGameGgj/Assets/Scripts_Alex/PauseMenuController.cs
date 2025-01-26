using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject panelPausa; // Panel de pausa
    public GameObject panelConfiguraciones; // Panel de configuraciones

    void Update()
    {
        // Verificar si se presiona ESC y se est� en la pantalla de configuraciones
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelConfiguraciones.activeSelf)
            {
                CerrarConfiguraciones(); 
            }
            else if (!panelPausa.activeSelf)
            {
                PausarJuego(); 
            }
            else
            {
                ReanudarJuego(); 
            }
        }
    }

    // Funci�n para pausar el juego y mostrar el panel de pausa
    public void PausarJuego()
    {
        panelPausa.SetActive(true); 
        Time.timeScale = 0f; 
        JuegoPausado = true;
    }

    // Funci�n para reanudar el juego y cerrar el panel de pausa
    public void ReanudarJuego()
    {
        panelPausa.SetActive(false); 
        Time.timeScale = 1f; 
        JuegoPausado = false;
    }

    // Funci�n para abrir el panel de configuraciones desde el panel de pausa
    public void AbrirConfiguraciones()
    {
        panelPausa.SetActive(false); 
        panelConfiguraciones.SetActive(true); 
    }

    // Funci�n para cerrar el panel de configuraciones y volver al de pausa
    public void CerrarConfiguraciones()
    {
        panelConfiguraciones.SetActive(false); 
        panelPausa.SetActive(true); 
    }

    // Funci�n para salir al men� principal
    public void SalirAlMenuPrincipal()
    {
        Time.timeScale = 1f; 
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal");
    }
}
