using UnityEngine;


// <summary>
//Скрипт для управления оружием
// </summary>
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;
    protected PlayerMovement pm;
    protected virtual void Start()
    {
        currentCooldown = cooldownDuration; // Инициализация текущего времени перезарядки
        pm = FindObjectOfType<PlayerMovement>(); // Поиск объекта PlayerMovement в сцене
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime; // Уменьшение времени перезарядки
        if (currentCooldown <= 0f)
        {
            Attack(); // Если время перезарядки меньше нуля, вызываем атаку
        }
    }

    protected virtual void Attack()
    {
        // Сброс времени перезарядки
        currentCooldown = cooldownDuration;
        
    }
}
