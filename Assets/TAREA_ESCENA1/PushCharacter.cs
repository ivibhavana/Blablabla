using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCharacter : MonoBehaviour
{
    public float pushForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene CharacterController
        CharacterController characterController = collision.gameObject.GetComponent<CharacterController>();

        if (characterController != null)
        {
            // Calcular la direcci�n del impacto
            Vector3 pushDirection = collision.contacts[0].point - transform.position;
            pushDirection = -pushDirection.normalized; // Invertir la direcci�n para empujar hacia atr�s

            // Aplicar fuerza al objeto con Rigidbody
            GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
