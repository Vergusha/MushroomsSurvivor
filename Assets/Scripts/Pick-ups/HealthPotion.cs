using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectible
{
    public int healthToRestore;

    public void Collect()
    {
        PlayerStats player = FindAnyObjectByType<PlayerStats>();
        player.RestoreHealth(healthToRestore); // Call the method to restore health
        Destroy(gameObject); // Destroy the potion after collection
    }

}
