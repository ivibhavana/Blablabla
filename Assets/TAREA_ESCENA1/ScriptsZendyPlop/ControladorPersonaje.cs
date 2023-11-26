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

    
    public float radioDelCollider = 0.5f;
    public float alturaDelCollider = 2.0f;

    void Start()
    {
        vidaActual = vidaMaxima;

        if (barraVida != null)
        {
            barraVida.value = 1f;
            ActualizarBarraVida();
        }
    }

    void Update()
    {
        
        Collider[] frutasEnRango = Physics.OverlapCapsule(
            transform.position + Vector3.up * (alturaDelCollider / 2),
            transform.position - Vector3.up * (alturaDelCollider / 2),
            radioDelCollider,
            capaFrutas
        );

        
        foreach (Collider frutaCollider in frutasEnRango)
        {
            Destroy(frutaCollider.gameObject);
            contadorFrutas++;
            ActualizarContadorFrutas();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
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
