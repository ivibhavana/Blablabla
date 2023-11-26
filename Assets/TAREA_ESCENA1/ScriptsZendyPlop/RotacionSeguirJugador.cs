using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionSeguirJugador : MonoBehaviour
{
    public Transform jugador;

    void Update()
    {
        if (jugador != null)
        {
            
            Vector3 direccionAlJugador = jugador.position - transform.position;

            
            transform.rotation = Quaternion.LookRotation(direccionAlJugador);
        }
    }
}
