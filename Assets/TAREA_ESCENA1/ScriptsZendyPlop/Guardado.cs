using UnityEngine;

public class Guardado : MonoBehaviour
{
    public void GuardarPartida()
    {
        // Guardar datos en PlayerPrefs
        PlayerPrefs.SetInt("Frutas", ObtenerCantidadColeccionables());
        PlayerPrefs.SetFloat("PosX", transform.position.x);
        PlayerPrefs.SetFloat("PosY", transform.position.y);
        PlayerPrefs.SetString("EscenaActual", ObtenerNombreEscena());

        // Guardar PlayerPrefs
        PlayerPrefs.Save();

        Debug.Log("Partida guardada");
    }

    private int ObtenerCantidadColeccionables()
    {
        // Cambiar la etiqueta a "Frutas"
        GameObject[] frutas = GameObject.FindGameObjectsWithTag("Frutas");
        return frutas.Length;
    }

    private string ObtenerNombreEscena()
    {
        // Obtener el nombre de la escena actual
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
}
