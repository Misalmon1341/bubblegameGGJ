using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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

  

    private Limpiador limpiadorActual = Limpiador.Escoba;

    private Animator animator;
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        selector.anchoredPosition = new Vector2(570, 361);
    }
    void Update()
    {
        CambiarLimpiador();

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
    private float cooldown = 0.4f;
    private float nextActionTime = 0f;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Mueble"))
        {
            if (Time.time >= nextActionTime && Input.GetMouseButtonDown(0)) 
            {
                if (other.TryGetComponent<Objetosucios>(out Objetosucios objetosucios))
                {
                    switch (limpiadorActual)
                    {
                        case Limpiador.Escoba:
                            animator.SetTrigger("Barrido");
                            objetosucios.Limpiar(escoba1);
                            break;
                        case Limpiador.Pistola:
                            animator.SetTrigger("Jabonado");
                            objetosucios.Enjabonar(pistola2);
                            break;
                    }

                    nextActionTime = Time.time + cooldown; 
                }
            }
        }
    }



}
