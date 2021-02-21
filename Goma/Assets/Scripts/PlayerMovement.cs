using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float rayCastDistance = 1f;
    bool isJumping;
    public float jumpforce = 6f;
    public float walkspeedforce = 10f;
    public Transform groundchecker;
    public LayerMask layerMask;
    bool isStandingOnRotate;
    public Transform playerBody;
   
    void Awake() => rb = GetComponent<Rigidbody>();


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.Raycast(groundchecker.position, Vector3.down, rayCastDistance, layerMask))
            {
                isJumping = true;
            }
        }
    }
    void FixedUpdate()
    {
        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.VelocityChange);
            isJumping = false;
        }
        Movement();

        if (isStandingOnRotate)
        {
            playerBody.Rotate(Vector3.up * 100f * Time.fixedDeltaTime);
        }

    }
   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rotate")
        {
            isStandingOnRotate = true;
        } 
    }
   void OnCollisionExit(Collision collision) => isStandingOnRotate = false;

    void Movement()
    {
       float x = Input.GetAxisRaw("Horizontal") * walkspeedforce;
       float y = Input.GetAxisRaw("Vertical") * walkspeedforce;
       Vector3 movepos = transform.right * x + transform.forward * y;
       Vector3 newmovepos = new Vector3(movepos.x, rb.velocity.y, movepos.z);
       rb.velocity = newmovepos;
    }
        
}

