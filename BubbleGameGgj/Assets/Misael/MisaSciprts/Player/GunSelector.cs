using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Limpiador
{
    Escoba,
    Pistola
}
public class GunSelector : MonoBehaviour
{
   
    public RectTransform selector;
    public int escoba1;
    public int pistola2;


    private AudioSource audioSource;

    public AudioClip escoba;
    public AudioClip pistola;

    private Limpiador limpiadorActual = Limpiador.Escoba;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        selector.anchoredPosition = new Vector2(570, 361);
        audioSource = GetComponent<AudioSource>();
       
    }

    void Update()
    {
        CambiarLimpiador();
        DetectarClicEnMueble();  // Llamada para detectar clic en el mueble
    }

    private void CambiarLimpiador()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selector.anchoredPosition = new Vector2(570, 361);
            limpiadorActual = Limpiador.Escoba;
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selector.anchoredPosition = new Vector2(752, 361);
            limpiadorActual = Limpiador.Pistola;
        }
    }

    private void DetectarClicEnMueble()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Lanza un rayo desde la posición del mouse
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Verifica si el objeto tiene el componente "Objetosucios"
                if (hit.collider.TryGetComponent(out Objetosucios objetosucios))
                {
                    switch (limpiadorActual)
                    {
                        case Limpiador.Escoba:
                            animator.SetTrigger("Barrido");
                            objetosucios.Limpiar(escoba1);
                            audioSource.PlayOneShot(escoba);
                            break;
                        case Limpiador.Pistola:
                            animator.SetTrigger("Jabonado");
                            objetosucios.Enjabonar(pistola2);
                            audioSource.PlayOneShot(pistola);
                            break;
                    }
                }
            }
        }
    }
}
