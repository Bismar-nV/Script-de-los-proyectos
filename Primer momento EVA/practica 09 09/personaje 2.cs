using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje2 : MonoBehaviour
{
    public float moveSpeed = 55.0f;
    public float forceJump = 55.0f;
    private Rigidbody rig;
    private bool isGrounded;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float movex = 0.0f;
        float movey = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movey = 1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movey = -1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movex = -1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movex = 1.0f;
        }

        Vector3 movimiento = new Vector3(movex, 0.0f, movey).normalized * moveSpeed * Time.deltaTime;
        Vector3 newPos = rig.position + rig.transform.TransformDirection(movimiento);
        rig.MovePosition(newPos);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            rig.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground1"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground1"))
        {
            isGrounded = false;
        }
    }
}
