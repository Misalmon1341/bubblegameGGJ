using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetosucios : MonoBehaviour
{
    private SpriteRenderer mueble;

    [Header("Vidamueble")]
    public int cantmugre;
    public int cantsuciedad;
    public Color filtro;

    [Header("Sprites")]
    public Sprite mueblelimpio;


    void Start()
    {
        mueble = GetComponent<SpriteRenderer>();
        mueble.color = Color.gray;
    }

    public void Limpiar(int escoba)
    {
        cantmugre -= escoba;
        if (cantmugre < 0)
        {
            mueble.color = Color.white;
        }
    }

    public void Enjabonar(int jabon)
    {
        cantsuciedad -= jabon;
        if (cantsuciedad < 0)
        {
            mueble.sprite = mueblelimpio;
        }
    }
}
