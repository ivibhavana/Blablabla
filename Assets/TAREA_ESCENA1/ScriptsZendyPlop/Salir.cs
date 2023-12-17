using UnityEngine;

public class Salir : MonoBehaviour
{
    public void CerrarJuego()
    {
        // Esto cerrar� la aplicaci�n (funciona en la versi�n compilada del juego)
#if !UNITY_EDITOR
        Application.Quit();
#endif

        // Si est�s en el editor de Unity, esto detendr� la reproducci�n del juego
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
