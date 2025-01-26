using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;

    private Rigidbody2D rb2D;

    private float movimientoX;
    private float movimientoY;
    private Animator animator;

    private AudioSource audioSource;
    public AudioClip sonidoPasos;

    private bool estaCaminando = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        movimientoX = Input.GetAxisRaw("Horizontal");
        movimientoY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("MovimientoX", movimientoX);
        animator.SetFloat("MovimientoY", movimientoY);
        if (movimientoX != 0 || movimientoY != 0)
        {
            animator.SetFloat("UltimoX", movimientoX);
            animator.SetFloat("UltimoY", movimientoY);
            
            if (!estaCaminando) 
            {
                audioSource.clip = sonidoPasos; 
                audioSource.loop = true;        
                audioSource.Play();             
                estaCaminando = true;
            }
        }
        else
        {
            if (estaCaminando) 
            {
                audioSource.Stop();
                estaCaminando = false;
            }
        }
        direccion = new Vector2(movimientoX, movimientoY).normalized;
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }
}
