using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public EnemyScriptableObject enemyData; // Reference to the ScriptableObject containing enemy data
    Transform player;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform; // Assuming PlayerMovement is the script attached to the player GameObject
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemyData.MoveSpeed * Time.deltaTime);
    }
}
