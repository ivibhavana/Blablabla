using UnityEngine;

public class Salir : MonoBehaviour
{
    public void CerrarJuego()
    {
        // Esto cerrará la aplicación (funciona en la versión compilada del juego)
#if !UNITY_EDITOR
        Application.Quit();
#endif

        // Si estás en el editor de Unity, esto detendrá la reproducción del juego
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
