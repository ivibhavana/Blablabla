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

    private Vector3 jumpForce = Vector3.zero;
    public float gravity = 10f;
    public Camera cam;
    
    void Start()
    {
        
    }

    void Update()
    {
        //Get axis horizontal y vertical
        float H_axis = Input.GetAxis("Horizontal");
        float V_axis = Input.GetAxis("Vertical");

        //Debug.Log("H: * + H_axis + * V:* + V_axis);

        //Vector3 dir = new Vector3(H_axis, 0 , V_axis);
        Vector3 dir = new Vector3(H_axis, 0 , V_axis).normalized;
        //Debug.Log(dir);

        if(dir.magnitude >= 0.1f)

        float angle = (Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg)
        float angle2 = Mathf SmoothDeepAngle(transform.eulerAngles.y, angl, ref turnSmoothVel, turnSmoothTime)
        {
            //Debug.Log(dir.magnitude);
            var dir2 = Quaternium.Euler(0f, angle, 0f);
            transform rotation = quaternion.Euler(0f, angle, 0f)
            CharacterController.Move(dir * speed * Time.deltaTime);
        }
        jumpForce.y -= gravity * Time.deltaTime;

        bool jumpBtn = Input.GetButtonDown("Jump");

       if(jumpBtn)
       {
        jumpForce.y = jumpSpeed * Time.deltaTime;
       
       }

        CharacterController.Move(jumpForce * Time.deltaTime);


    }
}
