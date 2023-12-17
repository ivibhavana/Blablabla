using UnityEngine;

public class RotacionSeguirJugador : MonoBehaviour
{
    public Transform jugador;

    void Update()
    {
        MirarAlJugador();
    }

    void MirarAlJugador()
    {
        if (jugador != null)
        {
            Vector3 direccionAlJugador = jugador.position - transform.position;
            direccionAlJugador.y = 0f;

            if (direccionAlJugador != Vector3.zero)
            {
                Quaternion rotacionDeseada = Quaternion.LookRotation(direccionAlJugador);
                transform.rotation = rotacionDeseada;
            }
        }
    }
}
