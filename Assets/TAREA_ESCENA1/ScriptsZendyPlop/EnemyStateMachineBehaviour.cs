using UnityEngine;

public class EnemyStateMachineBehaviour : StateMachineBehaviour
{
    private Transform player;
    private Transform enemyTransform;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private bool estaDentroDelRango = false;

    public float distanciaDeteccion = 25f;
    public float distanciaAtaque = 1f;
    public float distanciaMinima = 2f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyTransform = animator.transform;
        navMeshAgent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.enabled = true;

        // Desactivar otros triggers al entrar en un nuevo estado
        animator.ResetTrigger("Patrullar");
        animator.ResetTrigger("Perseguir");
        animator.ResetTrigger("Atacar");

        // Determinar si el enemigo está dentro del rango al inicio
        estaDentroDelRango = Vector3.Distance(enemyTransform.position, player.position) < distanciaDeteccion;
        animator.SetBool("Persiguiendo", estaDentroDelRango);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanciaAlJugador = Vector3.Distance(enemyTransform.position, player.position);

        if (stateInfo.IsName("Patrullar"))
        {
            // Realizar acciones de patrulla
            MoverAleatoriamente();

            // Cambiar a perseguir si el jugador entra en el rango de detección
            if (!estaDentroDelRango && distanciaAlJugador < distanciaDeteccion)
            {
                animator.SetTrigger("Perseguir");
                estaDentroDelRango = true;
                animator.SetBool("Persiguiendo", true);
            }
        }
        else if (stateInfo.IsName("Perseguir"))
        {
            // Realizar acciones de persecución
            SeguirJugador();

            // Cambiar a atacar si el jugador está a 1 unidad de distancia
            if (distanciaAlJugador < distanciaMinima)
            {
                animator.SetTrigger("Atacar");
            }

            // Cambiar a patrullar si el jugador está fuera del rango de detección
            if (distanciaAlJugador > distanciaDeteccion)
            {
                animator.SetTrigger("CambiarEstado");
                estaDentroDelRango = false;
                animator.SetBool("Persiguiendo", false);
            }
        }
        else if (stateInfo.IsName("Atacar"))
        {
            // Realizar acciones de ataque
            // Puedes colocar aquí la lógica de ataque, por ejemplo, infligir daño al jugador
        }
    }

    void MoverAleatoriamente()
    {
        // Genera un punto aleatorio en el plano XZ del NavMesh
        Vector3 randomDirection = Random.insideUnitSphere * 5f;
        randomDirection += enemyTransform.position;

        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, 5f, UnityEngine.AI.NavMesh.AllAreas);

        Vector3 finalPosition = hit.position;

        // Configura la nueva posición de destino en el NavMesh
        navMeshAgent.SetDestination(finalPosition);
    }

    void SeguirJugador()
    {
        navMeshAgent.SetDestination(player.position);
    }
}
