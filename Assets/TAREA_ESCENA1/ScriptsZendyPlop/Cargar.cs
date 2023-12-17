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

        // Imprimir informaci�n sobre los datos cargados
        Debug.Log("Datos cargados - Frutas: " + cantidadColeccionables + ", PosX: " + posX + ", PosY: " + posY + ", EscenaActual: " + escenaActual);

        // Comprobar si el nombre de la escena es v�lido
        if (!string.IsNullOrEmpty(escenaActual))
        {
            // Cargar la escena
            SceneManager.LoadScene(escenaActual);

            // Tambi�n puedes ajustar la posici�n del jugador
            GameObject jugador = GameObject.FindWithTag("Player");
            if (jugador != null)
            {
                jugador.transform.position = new Vector2(posX, posY);
            }

            Debug.Log("Partida cargada - Frutas: " + cantidadColeccionables + ", PosX: " + posX + ", PosY: " + posY + ", EscenaActual: " + escenaActual);
        }
        else
        {
            Debug.LogError("Nombre de escena no v�lido. La partida no se puede cargar.");
        }
    }
}
