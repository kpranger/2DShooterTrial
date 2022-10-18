using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Sets initial value for movement speed
    public float moveSpeed = 5f;

    // Enables physics to move and rotate
    public Rigidbody2D rb;

    // Enables camera
    public Camera cam;

    // Sets up a vector to track the movement
    Vector2 movement;

    // Sets up a vector to track the mouse position
    Vector2 mousePos;

    // Update is called once per frame (tracks overall movement every frame / how much has each value changed)
    void Update()
    {
        // Set x and y and get inputs to get movement on the 2D axis
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Gets the mouse position to track to mouse movement
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Similar to update but happens less often; instead of being called every frame it gets called on a fixed time
    // (if a computer is running at a different framerate it makes movement the same)
    private void FixedUpdate()
    {
        // Tracks how much the axis is changing, but doesn't actually move the character; tracks how much movement happens over a set amount of time
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Rotate with mouse
        Vector2 lookDirection = mousePos - rb.position;

        // Tracks how much we've turned the character with the mouse (convert radians to degrees and minus by 90 degrees)
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        
        // Takes the rotation value of the rigid body and changes it to the angle to change the fixed update
        rb.rotation = angle;
    }
}
