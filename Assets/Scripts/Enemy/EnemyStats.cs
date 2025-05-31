using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData; // Ссылка на ScriptableObject с данными врага
                                            //Stats
    float currentMoveSpeed; // Текущая скорость движения врага
    float currentHealth; // Текущее здоровье врага
    float currentDamage; // Текущий урон, наносимый врагом

    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed; // Инициализация текущей скорости движения
        currentHealth = enemyData.MaxHealth; // Инициализация текущего здоровья
        currentDamage = enemyData.Damage; // Инициализация текущего урона
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg; // Уменьшение текущего здоровья на полученный урон
        if (currentHealth <= 0)
        {
            Kill(); // Если здоровье меньше или равно нулю, вызываем метод смерти
        }
    }

    public void Kill()
    {
        // Здесь можно добавить логику для уничтожения врага, например, воспроизведение анимации смерти или звука
        Destroy(gameObject); // Уничтожение объекта врага
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        //reference the script from the collided collider and deal damage using TakeDamage method
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = col.gameObject.GetComponent<PlayerStats>();
            playerStats.TakeDamage(currentDamage);
        }
    }

}
