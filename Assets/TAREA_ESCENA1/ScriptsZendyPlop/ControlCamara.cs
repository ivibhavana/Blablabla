using UnityEngine;
using Cinemachine;

public class ControlCamara : MonoBehaviour
{
    public Transform puntoDisparo;
    public float sensibilidadMouse = 0.05f;
    private CinemachineFreeLook freeLookCam;

    void Start()
    {
        // Obtén la referencia de la cámara Cinemachine FreeLook
        freeLookCam = GetComponent<CinemachineFreeLook>();

        // Asegúrate de que el punto de disparo esté configurado correctamente
        if (puntoDisparo == null)
        {
            Debug.LogError("¡Asigna un punto de disparo en el inspector!");
        }
    }

    void Update()
    {
        // Configura el punto de disparo
        if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" según tu configuración de entrada
        {
            Disparar();
        }

        // Mejora la orientación de la cámara
        MejorarOrientacionCamara();
    }

    void MejorarOrientacionCamara()
    {
        // Mira hacia adelante de manera más estable
        Vector3 forwardDirection = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
        transform.forward = Vector3.Slerp(transform.forward, forwardDirection, Time.deltaTime * sensibilidadMouse);
    }

    void Disparar()
    {
        // Coloca aquí tu lógica de disparo, por ejemplo:
        Debug.Log("¡Pew pew! Has disparado hacia " + puntoDisparo.position);
        // Puedes realizar un Raycast o instanciar un proyectil en dirección al punto de disparo
    }
}
