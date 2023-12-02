using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullar2 : MonoBehaviour
{
    public NavMeshAgent agent;
    public string playerName;
    public Transform patrollingZone; // Agrega el objeto que representa la zona de patrulla
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

            // Verificar si el enemigo está dentro de la zona de patrulla
            if (IsInPatrollingZone())
            {
                // Activar el trigger "Patrullar" y resetear otros triggers
                animator.SetTrigger("Patrullar");
            }
        }
    }

    bool IsInPatrollingZone()
    {
        // Verificar si la posición del enemigo está dentro del área de la zona de patrulla
        return patrollingZone && Vector3.Distance(transform.position, patrollingZone.position) < patrollingZone.localScale.x * 0.5f;
    }
}
