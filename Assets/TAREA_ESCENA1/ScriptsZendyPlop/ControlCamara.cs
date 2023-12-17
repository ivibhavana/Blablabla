using UnityEngine;
using Cinemachine;

public class ControlCamara : MonoBehaviour
{
    public Transform puntoDisparo;
    public float sensibilidadMouse = 0.05f;
    private CinemachineFreeLook freeLookCam;

    void Start()
    {
        // Obt�n la referencia de la c�mara Cinemachine FreeLook
        freeLookCam = GetComponent<CinemachineFreeLook>();

        // Aseg�rate de que el punto de disparo est� configurado correctamente
        if (puntoDisparo == null)
        {
            Debug.LogError("�Asigna un punto de disparo en el inspector!");
        }
    }

    void Update()
    {
        // Configura el punto de disparo
        if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" seg�n tu configuraci�n de entrada
        {
            Disparar();
        }

        // Mejora la orientaci�n de la c�mara
        MejorarOrientacionCamara();
    }

    void MejorarOrientacionCamara()
    {
        // Mira hacia adelante de manera m�s estable
        Vector3 forwardDirection = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
        transform.forward = Vector3.Slerp(transform.forward, forwardDirection, Time.deltaTime * sensibilidadMouse);
    }

    void Disparar()
    {
        // Coloca aqu� tu l�gica de disparo, por ejemplo:
        Debug.Log("�Pew pew! Has disparado hacia " + puntoDisparo.position);
        // Puedes realizar un Raycast o instanciar un proyectil en direcci�n al punto de disparo
    }
}
