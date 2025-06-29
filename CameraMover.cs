using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 newPosition = rb.position + direction * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }

    // Example wrapper functions for UI Buttons
    public void MoveUp() => Move(Vector3.forward);
    public void MoveDown() => Move(Vector3.back);
    public void MoveLeft() => Move(Vector3.left);
    public void MoveRight() => Move(Vector3.right);
}
