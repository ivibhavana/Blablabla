using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{

    // Este método se llamará cuando hagas clic en el botón
    public void CambiarAEscena1()
    {
        // Cambia el nombre de la escena según tu configuración en Unity
        SceneManager.LoadScene("Escena1");
    }
}
