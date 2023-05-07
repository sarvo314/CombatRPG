using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public InputAction playerControls;
    Vector2 moveDirection = Vector2.zero;
    Rigidbody rb;
    float moveSpeed = 2f;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(moveDirection.x * moveSpeed * Time.fixedDeltaTime, 0, moveDirection.y * moveSpeed * Time.fixedDeltaTime));
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
}
