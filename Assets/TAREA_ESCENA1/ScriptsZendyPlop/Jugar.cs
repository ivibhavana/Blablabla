using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{

    // Este m�todo se llamar� cuando hagas clic en el bot�n
    public void CambiarAEscena1()
    {
        // Cambia el nombre de la escena seg�n tu configuraci�n en Unity
        SceneManager.LoadScene("Escena1");
    }
}
