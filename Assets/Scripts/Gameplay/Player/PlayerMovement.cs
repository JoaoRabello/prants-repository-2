using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _cc;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;

    private Vector3 velocity;
    [SerializeField] private float acceleration = 0f;
    [SerializeField] private float accelerationStep = 1f;
    [SerializeField] private float jumpHeight = 3f;
    
    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        //Movement
        if (_cc.isGrounded && velocity.y < 0) velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if ((!Mathf.Approximately(x, 0f) || !Mathf.Approximately(z, 0f)) && acceleration < 1f)
            acceleration += accelerationStep * Time.deltaTime;
        else if (Mathf.Approximately(x, 0f) && Mathf.Approximately(z, 0f) && acceleration > 0f)
            acceleration -= accelerationStep * 10f * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z;

        move = move.normalized;

        _cc.Move(move * (speed * acceleration * Time.deltaTime));
        
        //Jumping
        if (Input.GetButtonDown("Jump") && _cc.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        //Gravity
        velocity.y += gravity * Time.deltaTime;
        _cc.Move(velocity * Time.deltaTime);
        
        
    }
}
