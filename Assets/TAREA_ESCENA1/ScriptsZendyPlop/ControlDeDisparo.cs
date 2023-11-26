using UnityEngine;

public class ControlDeDisparo : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform puntoDeDisparo;
    public float velocidadLaser = 10f;
    public float tiempoDeVida = 2f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DispararLaser();
        }
    }

    void DispararLaser()
    {
        GameObject laser = Instantiate(laserPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Rigidbody rb = laser.GetComponent<Rigidbody>();

        rb.velocity = puntoDeDisparo.forward * velocidadLaser;

        Destroy(laser, tiempoDeVida);
    }

    
    void OnTriggerEnter(Collider other)
    {
        
        Enemigo enemigo = other.GetComponent<Enemigo>();

        if (enemigo != null)
        {
            
            enemigo.QuitarVida(10); 
        }
    }
}
