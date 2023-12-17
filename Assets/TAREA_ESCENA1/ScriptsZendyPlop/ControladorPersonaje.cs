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

    public AudioSource audioRecoleccion;
    public AudioClip sonidoRecoleccion;

    void Start()
    {
        vidaActual = vidaMaxima;

        if (barraVida != null)
        {
            ActualizarBarraVida();
        }

        if (audioRecoleccion == null)
        {
            audioRecoleccion = gameObject.AddComponent<AudioSource>();
        }
        audioRecoleccion.clip = sonidoRecoleccion;
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



            if (audioRecoleccion != null && sonidoRecoleccion != null)
            {
                audioRecoleccion.PlayOneShot(sonidoRecoleccion);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider entered: " + other.gameObject.name);

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Enemy detected! Applying damage.");
            RecibirDanio(1f);
        }
    }

    void ActualizarContadorFrutas()
    {
        if (contadorFrutasText != null)
        {
            contadorFrutasText.color = new Color(0.5f, 1f, 0.83f);
            contadorFrutasText.text = "Alimento recolectado: " + contadorFrutas;
        }
    }

    public void RecibirDanio(float cantidadDanio)
    {
        Debug.Log("Recibiendo daño: " + cantidadDanio + " de " + gameObject.name);

        vidaActual -= cantidadDanio;
        vidaActual = Mathf.Max(vidaActual, 0f);

        Debug.Log("Vida actual después de recibir daño: " + vidaActual);

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