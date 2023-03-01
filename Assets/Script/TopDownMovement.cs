using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // Movement speed
    [SerializeField] private float turnSpeed = 10.0f; // Turning speed
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Freeze rotation on X and Z axes
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get horizontal input
        float vertical = Input.GetAxis("Vertical"); // Get vertical input

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical); // Create movement vector

        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime); // Move character

        if (direction != Vector3.zero) // Only turn if moving
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction); // Calculate target rotation
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime)); // Turn character
        }
    }
}
