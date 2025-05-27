using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    public float moveSpeed;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform; // Assuming PlayerMovement is the script attached to the player GameObject
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
