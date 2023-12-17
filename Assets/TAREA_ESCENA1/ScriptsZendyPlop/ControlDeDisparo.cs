using UnityEngine;

public class ControlDeDisparo : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform puntoDeDisparo;
    public float velocidadLaser = 20f;
    public float tiempoDeVida = 0.5f;

    private LaserGun laserGun; // Referencia al script de audio

    void Start()
    {
        // Obtén o añade el componente LaserGun al objeto
        laserGun = GetComponent<LaserGun>();
        if (laserGun == null)
        {
            laserGun = gameObject.AddComponent<LaserGun>();
        }
    }

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

        // Llama a la función de audio al disparar
        laserGun.FireLaser();

        // Añade la lógica para contar los disparos al enemigo
        RaycastHit hit;
        if (Physics.Raycast(puntoDeDisparo.position, puntoDeDisparo.forward, out hit))
        {
            // Asegúrate de que el objeto golpeado tenga el layer "Enemy"
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Enemigo enemigo = hit.collider.GetComponent<Enemigo>();
                if (enemigo != null)
                {
                    enemigo.QuitarVida(1); // Reduces 3 de vida con cada disparo

                    // Comprueba si el enemigo debe ser destruido
                    if (enemigo.ObtenerVidaActual() <= 0)
                    {
                        if (enemigo.ObtenerDisparosNecesarios() <= 0)
                        {
                            Destroy(enemigo.gameObject);
                        }
                        else
                        {
                            enemigo.ReducirDisparosNecesarios();
                        }

                    }
                }
            }
        }
    }
}


    