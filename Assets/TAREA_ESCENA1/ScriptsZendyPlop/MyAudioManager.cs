using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Asigna tu archivo MP3 desde el Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        PlayBackgroundMusic();
    }

    void Update()
    {
        // Puedes agregar l�gica para detener la m�sica en la muerte del personaje o al finalizar la escena
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopBackgroundMusic();
            // Puedes agregar m�s acciones aqu�, como reiniciar el nivel o salir del juego
        }
    }

    void PlayBackgroundMusic()
    {
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.Play();
        }
    }

    void StopBackgroundMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // Este m�todo se llama cuando el objeto que contiene este script es destruido
    void OnDestroy()
    {
        StopBackgroundMusic();
    }
}
