using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetosucios : MonoBehaviour
{
    private SpriteRenderer mueble;
    private ControlJuego controlJuego; // Referencia al script ControlJuego

    [Header("Vidamueble")]
    public int cantmugre;
    public int cantsuciedad;

    [Header("Sprites")]
    public Sprite mueblelimpio;
    private bool estaLimpio = false;
    private bool suciedadEliminada = false; // Nuevo booleano para controlar el enjabonar
    private Color colorOriginal;

    public ParticleSystem particulas;
    public ParticleSystem particulasS;
    private AudioSource audioSource;
    public AudioClip destello;

    public LayerMask Muebles;

    void Start()
    {
        mueble = GetComponent<SpriteRenderer>();
        mueble.color = Color.gray;
        colorOriginal = mueble.color;
        audioSource = GetComponent<AudioSource>();

        // Aseguramos que obtenemos la referencia al ControlJuego correctamente
        controlJuego = FindObjectOfType<ControlJuego>(); // Asegúrate de que existe un objeto con este script en la escena
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Si se presiona el botón izquierdo del mouse
        {
            DetectarObjetoClicado();
        }
    }

    void DetectarObjetoClicado()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Muebles)) // Solo detecta objetos en el Layer de muebles
        {
            Objetosucios objetoS = hit.collider.GetComponent<Objetosucios>();
            if (objetoS != null)
            {
                // Aquí puedes decidir si enjabonar o limpiar dependiendo del estado del objeto
                if (!objetoS.suciedadEliminada)
                {
                    objetoS.Enjabonar(10); // Primero enjabona
                }
                else
                {
                    objetoS.Limpiar(10); // Solo puedes limpiar después de enjabonar
                }
            }
        }
    }

    public void Enjabonar(int jabon)
    {
        if (!estaLimpio && !suciedadEliminada) // Solo enjabona si el mueble no está limpio y aún hay suciedad
        {
            cantsuciedad -= jabon;
            cantsuciedad = Mathf.Max(cantsuciedad, 0); // Aseguramos que no baje de 0
            particulas.Play();

            // Cambia el color del mueble dependiendo del progreso de enjabonar
            float progreso = 1 - (float)cantsuciedad / 100;
            mueble.color = Color.Lerp(colorOriginal, Color.blue, progreso); // El color azul indica progreso al enjabonar

            if (cantsuciedad == 0)
            {
                suciedadEliminada = true; // Ahora puedes limpiar después de haber enjabonado por completo
                audioSource.PlayOneShot(destello);
                particulasS.Play();
            }
        }
    }

    public void Limpiar(int escoba)
    {
        if (!estaLimpio && suciedadEliminada) // Solo puedes limpiar si ya has eliminado toda la suciedad
        {
            cantmugre -= escoba;
            cantmugre = Mathf.Max(cantmugre, 0); // Aseguramos que no baje de 0
            particulas.Play();

            // Cambia el color del mueble dependiendo del progreso de limpiar
            float progreso = 1 - (float)cantmugre / 100;
            mueble.color = Color.Lerp(Color.blue, Color.white, progreso); // Cambia de azul a blanco al limpiar

            if (cantmugre == 0)
            {
                estaLimpio = true; // Marcamos el mueble como completamente limpio
                mueble.sprite = mueblelimpio; // Cambiamos a sprite de mueble limpio
                audioSource.PlayOneShot(destello);
                particulasS.Play();
                controlJuego.LimpiarMueble(); // Llamamos a la función del ControlJuego para aumentar el contador
            }
        }
    }
}