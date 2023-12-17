using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public float distanciaDeteccion = 5f;
    public float distanciaAtaque = 1f;
    public float radioMovimiento = 5f;
    public int vidaMaxima = 1;
    public float distanciaMinima = 2f;

    private Transform player;
    private Vector3 posicionInicial;
    private int vidaActual;

    private NavMeshAgent navMeshAgent;

    private int disparosNecesarios = 1;

    // Propiedad para la vida
    public int Vida
    {
        get { return vidaActual; }
        set { vidaActual = value; }
    }

    // Función para obtener la vida actual
    public int ObtenerVidaActual()
    {
        return vidaActual;
    }

    // Función para reducir la vida
    public void QuitarVida(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            // El enemigo murió, realizar acciones de muerte si es necesario
        }
    }

    // Función para obtener disparos necesarios
    public int ObtenerDisparosNecesarios()
    {
        return disparosNecesarios;
    }

    // Función para reducir disparos necesarios
    public void ReducirDisparosNecesarios()
    {
        disparosNecesarios--;

        if (disparosNecesarios <= 3)
        {
            // El enemigo está atacando, realizar acciones de ataque si es necesario
        }
        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        posicionInicial = transform.position;
        vidaActual = vidaMaxima;

        // Inicializamos el NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        MoverAleatoriamente();

        if (Vector3.Distance(transform.position, player.position) < distanciaDeteccion)
        {
            SeguirJugador();

            if (Vector3.Distance(transform.position, player.position) < distanciaAtaque)
            {
                // Realizar acciones de ataque si es necesario
            }
        }
    }

    void MoverAleatoriamente()
    {
        Vector3 randomDirection = Random.insideUnitSphere * radioMovimiento;
        randomDirection += posicionInicial;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radioMovimiento, NavMesh.AllAreas);
        Vector3 finalPosition = hit.position;
        navMeshAgent.SetDestination(finalPosition);
    }

    void SeguirJugador()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

        if (distanciaAlJugador > distanciaMinima)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }
}
