using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public CharacterController CharacterController;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVel;
    public float speed = 5f;
    public float jumpSpeed = 5f;

    private Vector3 moveDirection = Vector3.zero; // Usaremos esto para el movimiento total
    private Vector3 jumpForce = Vector3.zero;
    public float gravity = 10f;
    public Camera cam;

    // Coyote time
    public float coyoteTime = 0.2f;
    private float coyoteCurrent;

    // Doble salto
    private int jumpsRemaining;
    public int maxJumps = 2;

    void Start()
    {
        coyoteCurrent = coyoteTime;
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        // Obtener ejes horizontal y vertical
        float H_axis = Input.GetAxis("Horizontal");
        float V_axis = Input.GetAxis("Vertical");

        // Vector de direcci�n normalizado
        Vector3 dir = new Vector3(H_axis, 0, V_axis).normalized;

        if (dir.magnitude >= 0.1f)
        {
            // Calcular el �ngulo basado en la direcci�n y la rotaci�n de la c�mara
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;

            // Calcular el �ngulo suavizado
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);

            // Actualizar la rotaci�n del jugador
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Establecer la direcci�n de movimiento total
            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Mover al personaje en la direcci�n calculada
            CharacterController.Move(moveDirection * speed * Time.deltaTime);
        }

        // Aplicar gravedad
        jumpForce.y -= gravity * Time.deltaTime;

        // Verificar si se presiona el bot�n de salto
        bool jumpBtn = Input.GetButtonDown("Jump");

        if (CharacterController.isGrounded)
        {
            // Restablecer los saltos restantes si el personaje est� en el suelo
            jumpsRemaining = maxJumps;
            coyoteCurrent = 0; // Reiniciar el coyote time
        }

        // Verificar el doble salto
        if (jumpBtn && (CharacterController.isGrounded || coyoteCurrent > 0) && jumpsRemaining > 0)
        {
            // Aplicar fuerza de salto si el personaje est� en el suelo o en el coyote time y tiene saltos restantes
            jumpForce.y = jumpSpeed;

            // Reducir los saltos restantes
            jumpsRemaining--;

            // Restablecer el coyote time despu�s de un salto en el aire
            coyoteCurrent = 0;
        }

        // Mover al personaje en la direcci�n vertical (saltar)
        CharacterController.Move(jumpForce * Time.deltaTime);

        // Actualizar el coyote time
        coyoteCurrent += Time.deltaTime;
    }
}
