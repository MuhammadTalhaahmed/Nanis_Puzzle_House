using UnityEngine;

public class PillowDrag: MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.linearVelocity = Vector3.zero; // Stop after drag
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 targetPos = GetMouseWorldPos() + offset;
            Vector3 moveForce = (targetPos - transform.position) * 10f;
            rb.linearVelocity = moveForce;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


}
