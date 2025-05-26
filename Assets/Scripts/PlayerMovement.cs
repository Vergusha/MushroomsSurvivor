using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Movement
        public float moveSpeed;
        Rigidbody2D rb;
        
        [HideInInspector]
        public float LastHorizontalVector;
        [HideInInspector]
        public float LastVerticalVector;
        [HideInInspector]
        public Vector3 moveDir;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         InputManagment();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagment()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            LastHorizontalVector = moveDir.x;
        }
        if (moveDir.y != 0)
        {
            LastVerticalVector = moveDir.y;
        }
    }

    void Move()
    {
        rb.linearVelocity = new Vector3(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}
