using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] Transform groundCheck;
    [ReadOnly, SerializeField] bool isGrounded;
    LayerMask groundLayerMask;
    Vector2 horizontalInput;
    Rigidbody playerRigidbody;

    private void Awake()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckSurroundings();
        MovePlayer();
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayerMask);
    }

    private void MovePlayer()
    {
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * walkSpeed;
        
        playerRigidbody.velocity = new Vector3(horizontalVelocity.x, playerRigidbody.velocity.y, horizontalVelocity.z);
    }

    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }
}
