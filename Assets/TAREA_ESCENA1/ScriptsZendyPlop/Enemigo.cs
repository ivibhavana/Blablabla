using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidadMovimiento = 3f;
    public float distanciaDeteccion = 5f;
    public float distanciaAtaque = 1f;
    public float radioMovimiento = 5f;
    public int vidaMaxima = 1;
    public float distanciaMinima = 2f;
    public int danioPorDisparo = 1;
    private int disparosNecesarios = 1;

    private Transform player;
    private Vector3 posicionInicial;
    private int vidaActual;

    // Propiedad para la vida
    public int Vida
    {
        get { return vidaActual; }
        set { vidaActual = value; }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        posicionInicial = transform.position;
        vidaActual = vidaMaxima;
    }

    void Update()
    {
        MoverAleatoriamente();

        if (Vector3.Distance(transform.position, player.position) < distanciaDeteccion)
        {
            SeguirJugador();

            if (Vector3.Distance(transform.position, player.position) < distanciaAtaque)
            {
                
            }
        }
    }

    void MoverAleatoriamente()
    {
        float deltaX = Random.Range(-1f, 1f);
        float deltaZ = Random.Range(-1f, 1f);

        Vector3 nuevaPosicion = transform.position + new Vector3(deltaX, 0f, deltaZ) * velocidadMovimiento * Time.deltaTime;

        Vector3 direccion = nuevaPosicion - posicionInicial;
        if (direccion.magnitude > radioMovimiento)
        {
            direccion = direccion.normalized * radioMovimiento;
            nuevaPosicion = posicionInicial + direccion;
        }

        transform.position = nuevaPosicion;
    }

    void SeguirJugador()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

        if (distanciaAlJugador > distanciaMinima)
        {
            transform.LookAt(player);
            transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);
        }
        
    }

    
    public void QuitarVida(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            
            if (--disparosNecesarios <= 1)
            {
                
            }
        }
    }
}
