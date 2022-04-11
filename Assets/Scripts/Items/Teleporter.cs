using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] float forwardForce;
    [SerializeField] float upwardForce;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ThrowTeleporterPad(Vector3 direction)
    {
        rb.AddForce(direction * forwardForce, ForceMode.Impulse);
        rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
       /** else
        {
            if(collision.collider.gameObject.layer != LayerMask.NameToLayer("Player"))
            {
                Destroy(gameObject);
            }
        }*/
    }
}
