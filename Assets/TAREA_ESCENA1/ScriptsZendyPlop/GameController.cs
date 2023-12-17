using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject flag;

    // Cambia el nombre de la siguiente escena según el nombre de tu escena
    public string nextSceneName = "Escena2";

    void Update()
    {
        // Mover al jugador con las teclas de flecha
        float moveSpeed = 5f;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed;
        player.transform.Translate(movement * Time.deltaTime);

        // Debug para imprimir la distancia a la bandera
        float distance = Vector3.Distance(player.transform.position, flag.transform.position);
        Debug.Log("Distancia a la bandera: " + distance);

        // Comprobar si el jugador ha tocado la bandera
        if (distance < 1.0f)
        {
            Debug.Log("¡Has tocado la bandera! Pasando a la siguiente escena.");
            // Cargar la siguiente escena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
