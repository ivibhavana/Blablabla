using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObject : MonoBehaviour
{
    public float shootingRange = 10f;
    public LayerMask playerLayer;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float timeBetweenShots = 1f; 
    public float bulletLifetime = 3f; 

    private float timeSinceLastShot;

    void Update()
    {
        DetectAndShoot();
    }

    void DetectAndShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, shootingRange, playerLayer))
        {
            Debug.Log("¡Jugador detectado!");

            
            if (Time.time - timeSinceLastShot > timeBetweenShots)
            {
                Shoot();
                timeSinceLastShot = Time.time; 
            }
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);

            
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            
            if (bulletRigidbody != null)
            {
                
                bulletRigidbody.velocity = transform.forward * bulletSpeed;

                
                Destroy(bullet, bulletLifetime);
            }
            else
            {
                Debug.LogError("El prefab de bala debe tener un componente Rigidbody.");
            }
        }
        else
        {
            Debug.LogError("Prefab de bala no asignado en el inspector.");
        }
    }
}
