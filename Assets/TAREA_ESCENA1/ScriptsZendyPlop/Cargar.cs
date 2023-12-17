using UnityEngine;
using UnityEngine.SceneManagement;

public class Cargar : MonoBehaviour
{
    public void CargarPartida()
    {
        // Cargar datos desde PlayerPrefs
        int cantidadColeccionables = PlayerPrefs.GetInt("Frutas");
        float posX = PlayerPrefs.GetFloat("PosX");
        float posY = PlayerPrefs.GetFloat("PosY");
        string escenaActual = PlayerPrefs.GetString("EscenaActual");

        // Imprimir información sobre los datos cargados
        Debug.Log("Datos cargados - Frutas: " + cantidadColeccionables + ", PosX: " + posX + ", PosY: " + posY + ", EscenaActual: " + escenaActual);

        // Comprobar si el nombre de la escena es válido
        if (!string.IsNullOrEmpty(escenaActual))
        {
            // Cargar la escena
            SceneManager.LoadScene(escenaActual);

            // También puedes ajustar la posición del jugador
            GameObject jugador = GameObject.FindWithTag("Player");
            if (jugador != null)
            {
                jugador.transform.position = new Vector2(posX, posY);
            }

            Debug.Log("Partida cargada - Frutas: " + cantidadColeccionables + ", PosX: " + posX + ", PosY: " + posY + ", EscenaActual: " + escenaActual);
        }
        else
        {
            Debug.LogError("Nombre de escena no válido. La partida no se puede cargar.");
        }
    }
}
