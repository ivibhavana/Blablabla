using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGhost : MonoBehaviour
{
    public NavMeshAgent agent;
    public string playerName;
    private Transform player;
    private Animator animator;

    void Start()
    {
        GameObject playerObject = GameObject.Find(playerName);

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene!");
        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activar el trigger "Atacar" cuando hay colisión con el jugador
            animator.SetTrigger("Atacar");

            // Resetear otros triggers para evitar activaciones acumuladas
            animator.ResetTrigger("Patrullar");
            animator.ResetTrigger("Perseguir");

            // Puedes ajustar esto según la lógica real de tu juego
            Debug.Log("Player entered the enemy's zone!");
        }
    }
}
