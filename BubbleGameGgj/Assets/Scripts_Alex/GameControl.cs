using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlJuego : MonoBehaviour
{
    public int mueblesLimpios = 0;       
    public int mueblesObjetivo = 7;      
    public float tiempoLimite = 180f;    
    [SerializeField]private float tiempoRestante;        
    [SerializeField]private bool nivelCompletado = false;

    public TextMeshProUGUI tiempoTexto;  
    public TextMeshProUGUI mueblesTexto; 
    public GameObject panelDerrota;      

    void Start()
    {
        tiempoRestante = tiempoLimite; // Inicializamos con el tiempo total 
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
        mueblesTexto.text =  mueblesLimpios + "/" + mueblesObjetivo;
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
        SceneManager.LoadScene("Lost");
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
