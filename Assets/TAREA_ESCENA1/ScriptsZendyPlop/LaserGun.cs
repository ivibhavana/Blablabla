using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public AudioClip laserSound; // Asigna tu efecto de sonido desde el Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    // Llamado cuando el jugador dispara el arma láser (puedes llamarlo desde tu lógica de disparo)
    public void FireLaser()
    {
        if (audioSource != null && laserSound != null)
        {
            audioSource.PlayOneShot(laserSound);
        }
    }
}
