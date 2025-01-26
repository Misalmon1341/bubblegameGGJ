using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetosucios : MonoBehaviour
{
    private SpriteRenderer mueble;
    private ControlJuego controlJuego;  // Referencia al script ControlJuego

    [Header("Vidamueble")]
    public int cantmugre;
    public int cantsuciedad;

    [Header("Sprites")]
    public Sprite mueblelimpio;

    private bool estaLimpio = false;
    private Color colorOriginal;
    public LayerMask layerMuebles;

    void Start()
    {
        mueble = GetComponent<SpriteRenderer>();
        mueble.color = Color.gray;
        colorOriginal = mueble.color;

        // Buscamos el objeto que contiene el script ControlJuego
        controlJuego = FindObjectOfType<ControlJuego>();
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

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMuebles)) // Solo detecta objetos en el Layer de muebles
        {
            Objetosucios objetoS = hit.collider.GetComponent<Objetosucios>();

            if (objetoS != null)
            {
                objetoS.Limpiar(10);
            }
        }
    }

    public void Limpiar(int escoba)
    {
        if (!estaLimpio && cantmugre > 0)
        {
            cantmugre -= escoba;
            cantmugre = Mathf.Max(cantmugre, 0);
            float progreso = 1 - (float)cantmugre / 100;
            mueble.color = Color.Lerp(colorOriginal, Color.white, progreso);

            if (cantmugre == 0 && cantsuciedad == 0)  // Si ambos contadores están en 0
            {
                estaLimpio = true;
                controlJuego.LimpiarMueble();  // Aumentamos el contador de muebles limpios en ControlJuego
            }
        }
    }

    public void Enjabonar(int jabon)
    {
        if (!estaLimpio && cantsuciedad > 0)
        {
            cantsuciedad -= jabon;
            cantsuciedad = Mathf.Max(cantsuciedad, 0);

            if (cantsuciedad == 0)
            {
                mueble.sprite = mueblelimpio;

                if (cantmugre == 0)  // Verificamos si el mueble ya está limpio en cuanto a la mugre
                {
                    estaLimpio = true;
                    controlJuego.LimpiarMueble();  // Aumentamos el contador de muebles limpios en ControlJuego
                }
            }
        }
    }
}