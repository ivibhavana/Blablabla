using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CharacterController;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVel;
    static public float speed = 10f;
    public float jumpSpeed = 5f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 jumpForce = Vector3.zero;
    public float gravity = 10f;
    public Camera cam;

    public float coyoteTime = 0.2f;
    private float coyoteCurrent;

    private int jumpsRemaining;
    public int maxJumps = 2;

    private bool isDisabled = false;

    void Start()
    {
        coyoteCurrent = coyoteTime;
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        if (isDisabled)
        {
            StartCoroutine(EnablePlayerAfterDelay(2f));
            return;
        }

        float H_axis = Input.GetAxis("Horizontal");
        float V_axis = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(H_axis, 0, V_axis).normalized;

        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            CharacterController.Move(moveDirection * speed * Time.deltaTime);
        }

        jumpForce.y -= gravity * Time.deltaTime;

        bool jumpBtn = Input.GetButtonDown("Jump");

        if (CharacterController.isGrounded)
        {
            jumpsRemaining = maxJumps;
            coyoteCurrent = 0;
        }

        if (jumpBtn && (CharacterController.isGrounded || coyoteCurrent > 0) && jumpsRemaining > 0)
        {
            jumpForce.y = jumpSpeed;
            jumpsRemaining--;
            coyoteCurrent = 0;
        }

        CharacterController.Move(jumpForce * Time.deltaTime);
        coyoteCurrent += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            isDisabled = true;
            CharacterController.enabled = false;
            StartCoroutine(EnablePlayerAfterDelay(2f));
        }
    }

    private IEnumerator EnablePlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isDisabled = false;
        CharacterController.enabled = true;
    }
}
