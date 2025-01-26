using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetosucios : MonoBehaviour
{
    private SpriteRenderer mueble;

    [Header("Vidamueble")]
    public int cantmugre;
    public int cantsuciedad;

    [Header("Sprites")]
    public Sprite mueblelimpio;

    private bool estaLimpio = false;
    private Color colorOriginal;
    void Start()
    {
        mueble = GetComponent<SpriteRenderer>();
        mueble.color = Color.gray;
        colorOriginal = mueble.color;
    }

    public void Limpiar(int escoba)
    {
        if (!estaLimpio && cantmugre > 0)
        {
            cantmugre -= escoba;
            cantmugre = Mathf.Max(cantmugre, 0);
            float progreso = 1 - (float)cantmugre / 100;
            mueble.color = Color.Lerp(colorOriginal, Color.white, progreso);

            if (cantmugre == 0)
            {
                estaLimpio = true;
            }
        }
    }

    public void Enjabonar(int jabon)
    {
        cantsuciedad -= jabon;
        cantsuciedad = Mathf.Max(cantsuciedad, 0);
        if (cantsuciedad == 0)
        {
            mueble.sprite = mueblelimpio;
        }
    }
}
