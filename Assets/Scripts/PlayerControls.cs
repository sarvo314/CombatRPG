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
    [Header("Max speed reacheable by moving, should be greater than 2")]
    public float maxSpeed;
    public float acceleration;


    public static event Action OnPressLeft;
    public static event Action OnPressRight;
    public static event Action OnPressUp;
    public static event Action OnPressDown;

    public static event Action OnCastSpell;



    AnimationController animationController;

    float velocityX;
    float velocityZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 1f;
        animationController = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        velocityX = moveDirection.x;
        velocityZ = moveDirection.y;
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveSpeed = 0.4f;
            Debug.Log("PResssed 2 now moving forward");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            OnCastSpell?.Invoke();
            //Debug.Log("Casted spell");
        }
    }
    private void FixedUpdate()
    {

        if (moveDirection.magnitude > 0)
        {
            MovePlayer();
            if (moveSpeed < maxSpeed && Input.GetKey(KeyCode.LeftShift))
            {
                Acceleration(1);
                Debug.Log("Player is moving");
            }

        }
        //deaccelarate
        //if (Input.GetKeyUp(KeyCode.W))
        else
        {
            Debug.Log("Player deaccelarates");

            if (moveSpeed > 0)
                Acceleration(-1);
            else if (moveSpeed < 0)
            {
                moveSpeed = 0;
                return;
            }
            MovePlayer();


        }

    }

    private void Acceleration(int direction)
    {
        moveSpeed += direction * Time.fixedDeltaTime * acceleration;
    }

    private void MovePlayer()
    {
        //if(moveDirection.magnitude > 0)

        rb.MovePosition(transform.position + new Vector3(moveDirection.x * moveSpeed * Time.fixedDeltaTime,
                        0,
                        moveDirection.y * moveSpeed * Time.fixedDeltaTime));
        animationController.PlayAnimation(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
