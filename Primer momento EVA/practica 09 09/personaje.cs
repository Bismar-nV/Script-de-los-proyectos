using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 55.0f;
    public float forceJump = 55.0f;
    private Rigidbody rig;
    private bool isGrounded;


    void Start()
    {
        rig = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3 (movex,0.0f, movey)*moveSpeed*Time.deltaTime;
        Vector3 newPOs = rig.position + rig.transform.TransformDirection(movimiento);
        rig.MovePosition(newPOs);

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            rig.AddForce(Vector3.up*forceJump, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
