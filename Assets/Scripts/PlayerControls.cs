using System;
using System.Timers;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    //public InputAction playerControls;
    Vector2 moveDirection = Vector2.zero;
    Rigidbody rb;
    float moveSpeed;
    [Header("Max speed reacheable by moving")]
    public float maxSpeed;
    public float acceleration;


    public static event Action OnPressLeft;
    public static event Action OnPressRight;
    public static event Action OnPressUp;
    public static event Action OnPressDown;

    AnimationController animationController;

    float velocityX;
    float velocityZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 0f;
        animationController = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        velocityX = moveDirection.x;
        velocityZ = moveDirection.y;

    }
    private void FixedUpdate()
    {
        if (moveDirection.magnitude > 0)
        {
            if (moveSpeed < maxSpeed)
                moveSpeed += Time.fixedDeltaTime * acceleration;
            MovePlayer();


        }
        //deaccelarate
        else
        {

            if (moveSpeed >= 0)
                moveSpeed -= acceleration * Time.fixedDeltaTime;
            else if (moveSpeed < 0) moveSpeed = 0;

            MovePlayer();


        }

    }

    private void MovePlayer()
    {
        rb.MovePosition(transform.position + new Vector3(moveDirection.x * moveSpeed * Time.fixedDeltaTime,
                        0,
                        moveDirection.y * moveSpeed * Time.fixedDeltaTime));
        animationController.PlayAnimation(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
