using UnityEngine;

public class Script1 : MonoBehaviour
{
    // ---------------- MOVEMENT ----------------
    public float moveSpeed = 2f;          // Movement speed
    public float moveLimit = 5f;          // Max distance before reversing
    private int moveDirection = 1;        // 1 = forward, -1 = backward

    // ---------------- ROTATION ----------------
    public float rotationSpeed = 50f;     // Rotation speed in degrees/sec
    public float rotationLimit = 45f;     // Max rotation angle before reversing
    private int rotationDirection = 1;    // 1 = clockwise, -1 = counterclockwise

    private Vector3 startPos;
    private float currentRotation = 0f;

    void Start()
    {
        // Save the starting position
        startPos = transform.position;
    }

    void Update()
    {
        // ==================================================
        // TASK 1 & 2: MOVEMENT ALONG X AXIS + REVERSE
        // ==================================================

        // Move continuously along X axis
        transform.position += new Vector3(
            moveSpeed * moveDirection * Time.deltaTime,
            0,
            0
        );

        // If object goes too far right or left, reverse direction
        if (transform.position.x > startPos.x + moveLimit)
        {
            moveDirection = -1;
        }
        else if (transform.position.x < startPos.x - moveLimit)
        {
            moveDirection = 1;
        }

        // ==================================================
        // TASK 3: ROTATION + REVERSE ROTATION
        // ==================================================

        // Rotate continuously on Y axis
        float rotationStep = rotationSpeed * rotationDirection * Time.deltaTime;

        transform.Rotate(0, rotationStep, 0);

        // Track total rotation from starting point
        currentRotation += rotationStep;

        // Reverse rotation when exceeding rotation limit
        if (currentRotation > rotationLimit)
        {
            rotationDirection = -1;
        }
        else if (currentRotation < -rotationLimit)
        {
            rotationDirection = 1;
        }
    }
}