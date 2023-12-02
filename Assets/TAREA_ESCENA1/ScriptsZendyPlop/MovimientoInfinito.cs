using UnityEngine;

public class MovimientoInfinito : MonoBehaviour
{
    public float velocidad = 2.0f; // Velocidad de movimiento
    public float yInicial = 0.0f; // Punto inicial en el eje Y
    public float yFinal = 5.0f; // Punto final en el eje Y

    void Update()
    {
        // Calcula el nuevo valor en el eje Y usando un movimiento sinusoidal para que sea suave
        float newY = Mathf.PingPong(Time.time * velocidad, yFinal - yInicial) + yInicial;

        // Aplica la nueva posición al GameObject
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
