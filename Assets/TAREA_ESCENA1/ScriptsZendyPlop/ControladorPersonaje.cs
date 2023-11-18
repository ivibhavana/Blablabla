using UnityEngine;
using UnityEngine.UI;

public class ControladorPersonaje : MonoBehaviour
{
    public Slider barraVida;
    public float vidaMaxima = 100f;
    private float vidaActual;
    public Text contadorFrutasText;
    public LayerMask capaFrutas;
    private int contadorFrutas = 0;

    void Start()
    {
        
        vidaActual = vidaMaxima;

        
        if (barraVida != null)
        {
            barraVida.value = 1f;  
            ActualizarBarraVida();
        }
    }

    public float VidaNormalizada()
    {
        
        if (vidaMaxima > 0)
        {
            return vidaActual / vidaMaxima;
        }
        else
        {
            
            return 0f;
        }
    }

    public void RecibirDanio()
    {
        
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
        
        if (contadorFrutasText != null)
        {
            contadorFrutasText.text = "Frutas: " + contadorFrutas;
        }
    }

    public void RecibirDanio(float cantidadDanio)
{
    
    vidaActual -= cantidadDanio;

    
    vidaActual = Mathf.Max(vidaActual, 0f);

    
    ActualizarBarraVida();

    
}


    void ActualizarBarraVida()
    {
        
        if (barraVida != null)
        {
            
            float valorRelativo = vidaActual / vidaMaxima;
            barraVida.value = 1 - valorRelativo;  
        }
    }
}
