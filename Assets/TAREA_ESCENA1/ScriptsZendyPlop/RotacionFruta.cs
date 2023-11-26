using UnityEngine;
using UnityEngine.UI;

public class RotacionFruta : MonoBehaviour
{
    public float velocidadRotacion = 50f;  
    public LayerMask capaFrutas;
    private int contadorFrutas = 0;

    void Update()
    {
        
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (capaFrutas == (capaFrutas | (1 << other.gameObject.layer)))
        {
            
            Destroy(other.gameObject);

           
            contadorFrutas++;

            
            ActualizarContadorFrutas();
        }
    }

    void ActualizarContadorFrutas()
    {
        
    }
}
