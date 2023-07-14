using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public bool walk_bool;
    public bool jump_bool;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        body.velocity = new Vector3(horizontalInput * movementSpeed, body.velocity.y, verticalInput * movementSpeed);

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
           body.velocity = new Vector3(body.velocity.x, jumpForce, body.velocity.z);
        }
  
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(GroundCheck.position, .1f, ground);
    }
       
}
