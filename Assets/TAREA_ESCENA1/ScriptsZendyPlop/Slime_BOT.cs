using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiEspacioDeNombres;

public class Slime_BOT : MonoBehaviour, IDamageble
{
    private Transform target;

    public SphereCollider colider;
    public float radius = 1f;
    public float speed = 7f;

    public Transform pivot;
    public float shootSpeed = 5f;
    private float shootCurrent = 0f;

    [Header("Prefs")]
    public GameObject bulletPref;

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPref, pivot.position, pivot.rotation);
        shootCurrent = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        colider.radius = radius / (float)this.transform.localScale.y;

        if (target != null)
        {
            // obtengo vector direccion
            var direction = target.position - transform.position;
            direction.y = 0;

            // temporizador de disparo
            if (shootCurrent >= shootSpeed)
            {
                Shoot();
            }
            shootCurrent += Time.deltaTime;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        }
    }

    public void TakeDamage(int damage)
    {
        // Agrega aquí la lógica para manejar el daño recibido
        Debug.Log($"Slime_BOT ha recibido {damage} de daño.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = (target != null) ? Color.green : Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
