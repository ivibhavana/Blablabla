using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenduloInfinito : MonoBehaviour
{
    public float velocidadRotacion = 1f;

    void Update()
    {
        // Rotar el objeto alrededor del eje Z
        transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
    }
}
