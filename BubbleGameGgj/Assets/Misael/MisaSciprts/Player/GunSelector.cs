using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GunSelector : MonoBehaviour
{
    public RectTransform selector;

    public int escoba1;
    public int pistola2;

    private bool escoba = true;
    private bool pistola = false;

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
            escoba = true;
            pistola = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selector.anchoredPosition = new Vector2(752, 361);
            escoba = false;
            pistola = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (escoba)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (other.TryGetComponent<Objetosucios>(out Objetosucios objetosucios))
                {
                    objetosucios.Limpiar(escoba1);
                }
            }
        }
        else if (pistola)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (other.TryGetComponent<Objetosucios>(out Objetosucios objetosucios))
                {
                    objetosucios.Enjabonar(pistola2);
                }
            }
        }
    }
 


}
