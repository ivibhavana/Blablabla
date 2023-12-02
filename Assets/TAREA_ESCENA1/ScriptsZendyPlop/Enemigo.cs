using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
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

    private NavMeshAgent navMeshAgent;  // Agregamos un componente NavMeshAgent

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
        // Generamos un nuevo destino aleatorio en cualquier posición dentro del NavMesh
        Vector3 randomDirection = Random.insideUnitSphere * radioMovimiento;
        randomDirection += posicionInicial;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radioMovimiento, NavMesh.AllAreas);  // Usamos NavMesh.AllAreas
        Vector3 finalPosition = hit.position;
        navMeshAgent.SetDestination(finalPosition);
    }

    void SeguirJugador()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

        if (distanciaAlJugador > distanciaMinima)
        {
            // Configuramos el destino del NavMeshAgent al jugador
            navMeshAgent.SetDestination(player.position);
        }
    }

    public void QuitarVida(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            if (--disparosNecesarios <= 1)
            {
                // Realizar acciones al derrotar al enemigo
            }
        }
    }
}
