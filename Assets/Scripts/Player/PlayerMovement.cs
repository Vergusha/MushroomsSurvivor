using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Movement
        public float moveSpeed;
        
        
        [HideInInspector]
        public float LastHorizontalVector;
        [HideInInspector]
        public float LastVerticalVector;
        [HideInInspector]
        public Vector2 moveDir;
        [HideInInspector]
         public Vector2 lastMovedVector;

//reference 
         Rigidbody2D rb;
         public CharacterScriptableObject characterData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector =  new Vector2(1, 0f); 
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
            lastMovedVector = new Vector2(LastHorizontalVector, 0f);  // Add semicolon here
        }
        if (moveDir.y != 0)
        {
            LastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, LastVerticalVector);
        }
        if(moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(LastHorizontalVector, LastVerticalVector); //While moviing diagonally, the last moved vector will be a combination of both horizontal and vertical vectors
        }
    }

    void Move()
    {
        rb.linearVelocity = new Vector3(moveDir.x * characterData.MoveSpeed, moveDir.y * characterData.MoveSpeed);
    }
}
