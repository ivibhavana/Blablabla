using UnityEngine;
using UnityEngine.UI;

public class RotacionFruta : MonoBehaviour
{
    public float velocidadRotacion = 50f;  // Velocidad de rotación de las frutas
    public LayerMask capaFrutas;
    private int contadorFrutas = 0;

    void Update()
    {
        // Rotar las frutas gradualmente en el eje Y.
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona es una fruta.
        if (capaFrutas == (capaFrutas | (1 << other.gameObject.layer)))
        {
            // Destruye la fruta al ser recolectada.
            Destroy(other.gameObject);

            // Incrementa el contador de frutas.
            contadorFrutas++;

            // Actualiza el texto del contador en el Canvas.
            ActualizarContadorFrutas();
        }
    }

    void ActualizarContadorFrutas()
    {
        // Actualiza el texto del contador en el Canvas.
        // (Tu código de actualización del contador aquí)
    }
}
