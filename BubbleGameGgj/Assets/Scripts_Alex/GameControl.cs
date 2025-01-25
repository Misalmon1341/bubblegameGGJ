using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlJuego : MonoBehaviour
{
    public int mueblesLimpios = 0;       // Cuántos muebles has limpiado hasta ahora
    public int mueblesObjetivo = 7;      // Cantidad de muebles que debes limpiar para ganar
    public float tiempoLimite = 180f;    // Tiempo límite en segundos
    private float tiempoRestante;        // Contador de tiempo restante
    private bool nivelCompletado = false; // Para asegurarnos de no ganar/perder el nivel varias veces

    public TextMeshProUGUI tiempoTexto;  // Texto en pantalla que muestra el tiempo restante
    public TextMeshProUGUI mueblesTexto; // Texto en pantalla que muestra los muebles limpiados
    public GameObject panelDerrota;      // Panel que aparece cuando pierdes

    void Start()
    {
        tiempoRestante = tiempoLimite; // Inicializamos con el tiempo total disponible
        panelDerrota.SetActive(false); // Panel de derrota empieza apagado
        ActualizarTextoMuebles();      // Actualizamos el texto de muebles al arrancar
    }

    void Update()
    {
        if (!nivelCompletado) // Solo si no hemos completado el nivel
        {
            tiempoRestante -= Time.deltaTime; 

            // Actualizamos el texto del tiempo restante
            tiempoTexto.text = "Tiempo: " + Mathf.Max(0, Mathf.FloorToInt(tiempoRestante)) + "s";

            // Si se han limpiado los muebles necesarios antes de que se acabe el tiempo, ganaste
            if (mueblesLimpios >= mueblesObjetivo && tiempoRestante > 0)
            {
                GanaNivel();
            }
            // Si el tiempo llegó a cero y no has limpiado lo suficiente
            else if (tiempoRestante <= 0)
            {
                PierdeNivel();
            }
        }
    }

    // Función que se llama cada vez que limpias un mueble
    public void LimpiarMueble()
    {
        mueblesLimpios++; 
        ActualizarTextoMuebles(); 
    }

    // Función para actualizar el texto de los muebles en pantalla
    void ActualizarTextoMuebles()
    {
        mueblesTexto.text = "Muebles Limpiados: " + mueblesLimpios + "/" + mueblesObjetivo;
    }

    // Esta función se llama cuando ganas el nivel
    void GanaNivel()
    {
        nivelCompletado = true; 
        SceneManager.LoadScene("Victoria"); 
    }

    // Esta función se llama cuando pierdes el nivel
    void PierdeNivel()
    {
        nivelCompletado = true; 
        panelDerrota.SetActive(true);  
    }

    // Función para reiniciar el nivel (botón "Reiniciar Nivel")
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

    public void SalirAlMenu()
    {
        SceneManager.LoadScene("Menu_Inicio");  
    }
}
