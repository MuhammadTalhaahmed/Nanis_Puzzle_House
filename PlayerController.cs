using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    public float speed = 5f;

    Rigidbody rb;
    Vector2 moveInput;

    public Transform cameraTransform;

    private Vector3 lastPosition;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("character");
        rb = GetComponent<Rigidbody>();

        lastPosition = rb.position;
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Movement vector
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y) * speed * Time.fixedDeltaTime;

        // Try to move player
        rb.MovePosition(rb.position + movement);

        // Wait for physics to apply movement, and check actual position
        Vector3 currentPosition = rb.position;
        Vector3 actualMovement = currentPosition - lastPosition;

        // Only move camera if player actually moved
        if (cameraTransform != null && actualMovement.magnitude > 0.001f)
        {
            cameraTransform.position += actualMovement;
        }

        // Update last known position
        lastPosition = currentPosition;
    }
}


